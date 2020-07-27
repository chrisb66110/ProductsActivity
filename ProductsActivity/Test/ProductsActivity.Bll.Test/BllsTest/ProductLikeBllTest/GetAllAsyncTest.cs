// ReSharper disable ConvertToUsingDeclaration

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using APIBaseTest;
using Autofac.Extras.Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductsActivity.Bll.Blls.ProductLikeBll;
using ProductsActivity.Common.Dtos.ProductLikeDtos;
using ProductsActivity.Dal.Repositories.ProductLikeRepository;
using ProductsActivity.Helpers.Test;

namespace ProductsActivity.Bll.Test.BllsTest.ProductLikeBllTest
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class GetAllAsyncTest : BaseTest<ProductLikeBll>
    {
        [TestMethod]
        public async Task GetAllAsyncHappyPath()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var responseRepository = DataTestHelper.GivenTheDefaultListProductLikeDto();

                AndIMockDependencyMethod<IProductLikeRepository, List<ProductLikeDto>>(autoMock, m => m.GetAllAsync(), responseRepository);

                var sut = GivenTheSystemUnderTest(autoMock);
                var response = await sut.GetAllAsync();

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
                AndIMockDependencyMethod<IProductLikeRepository, List<ProductLikeDto>, Exception>(autoMock, m => m.GetAllAsync(), responseRepository);

                var sut = GivenTheSystemUnderTest(autoMock);
                await sut.GetAllAsync();

                Assert.Fail("Test must have failed");
            }
        }
    }
}
