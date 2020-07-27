// ReSharper disable ConvertToUsingDeclaration

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using APIBaseTest;
using Autofac.Extras.Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductsActivity.Bll.Blls.ProductBll;
using ProductsActivity.Common.Dtos.ProductDtos;
using ProductsActivity.Dal.Repositories.ProductRepository;
using ProductsActivity.Helpers.Test;

namespace ProductsActivity.Bll.Test.BllsTest.ProductBllTest
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class GetAllAsyncTest : BaseTest<ProductBll>
    {
        [TestMethod]
        public async Task GetAllAsyncHappyPath()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var responseRepository = DataTestHelper.GivenTheDefaultListProductDto();

                AndIMockDependencyMethod<IProductRepository, List<ProductDto>>(autoMock, m => m.GetAllAsync(), responseRepository);

                var sut = GivenTheSystemUnderTest(autoMock);
                var response = await sut.GetProductsToGridFromAsync();

                CheckAllProperties(responseRepository, response);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public async Task GetAllAsyncErrorPath()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var responseRepository = new Exception("Repository throw Exception");
                AndIMockDependencyMethod<IProductRepository, List<ProductDto>, Exception>(autoMock, m => m.GetAllAsync(), responseRepository);

                var sut = GivenTheSystemUnderTest(autoMock);
                await sut.GetProductsToGridFromAsync();

                Assert.Fail("Test must have failed");
            }
        }
    }
}
