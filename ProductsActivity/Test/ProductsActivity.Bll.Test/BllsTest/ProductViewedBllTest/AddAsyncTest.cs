// ReSharper disable ConvertToUsingDeclaration

using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using APIBase.Common.Constants;
using APIBaseTest;
using Autofac.Extras.Moq;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ProductsActivity.Bll.Blls.ProductViewedBll;
using ProductsActivity.Common.Dtos.ProductViewedDtos;
using ProductsActivity.Dal.Repositories.ProductViewedRepository;
using ProductsActivity.Helpers.Test;
using Npgsql;

namespace ProductsActivity.Bll.Test.BllsTest.ProductViewedBllTest
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class AddAsyncTest : BaseTest<ProductViewedBll>
    {
        [TestMethod]
        public async Task AddAsyncHappyPath()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var request = DataTestHelper.GivenTheDefaultProductViewedDto();

                var responseRepository = DataTestHelper.GivenTheDefaultProductViewedDto();
                AndIMockDependencyMethod<IProductViewedRepository, ProductViewedDto, ProductViewedDto>(autoMock, m => m.AddAsync(It.IsAny<ProductViewedDto>()), responseRepository, param =>
                {
                    CheckAllProperties(request, param);
                });

                var sut = GivenTheSystemUnderTest(autoMock);
                var response = await sut.AddAsync(request);

                CheckAllProperties(responseRepository, response);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public async Task AddAsyncErrorPath()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var request = DataTestHelper.GivenTheDefaultProductViewedDto();

                var responseRepository = new Exception("Repository throw Exception");
                AndIMockDependencyMethod<IProductViewedRepository, ProductViewedDto, Exception>(autoMock, m => m.AddAsync(It.IsAny<ProductViewedDto>()), responseRepository);

                var sut = GivenTheSystemUnderTest(autoMock);
                await sut.AddAsync(request);

                Assert.Fail("Test must have failed");
            }
        }

        [TestMethod]
        public async Task AddAsyncDbUpdateExceptionPathDuplicate()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var request = DataTestHelper.GivenTheDefaultProductViewedDto();

                var innerResponse = new PostgresException("Duplicate throw Exception", null, null, BaseConstants.PG_DUPLICATE_ERROR);
                var responseRepository = new DbUpdateException("Duplicate throw Exception", innerResponse);
                AndIMockDependencyMethod<IProductViewedRepository, ProductViewedDto, DbUpdateException>(autoMock, m => m.AddAsync(It.IsAny<ProductViewedDto>()), responseRepository);

                var sut = GivenTheSystemUnderTest(autoMock);

                var response = await sut.AddAsync(request);

                Assert.AreEqual(null, response, "response should be null");
            }
        }

        [TestMethod]
        [ExpectedException(typeof(DbUpdateException))]
        public async Task AddAsyncDbUpdateExceptionPath()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var request = DataTestHelper.GivenTheDefaultProductViewedDto();

                var innerResponse = new PostgresException("Duplicate throw Exception", null, null, "No Duplicate Exception");
                var responseRepository = new DbUpdateException("Duplicate throw Exception", innerResponse);
                AndIMockDependencyMethod<IProductViewedRepository, ProductViewedDto, DbUpdateException>(autoMock, m => m.AddAsync(It.IsAny<ProductViewedDto>()), responseRepository);

                var sut = GivenTheSystemUnderTest(autoMock);

                await sut.AddAsync(request);

                Assert.Fail("Test must have failed");
            }
        }
    }
}
