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
using ProductsActivity.Bll.Blls.ProductColorBll;
using ProductsActivity.Dal.Repositories.ProductColorRepository;
using ProductsActivity.Helpers.Test;
using Npgsql;
using ProductsActivity.Common.Dtos.ProductDtos;

namespace ProductsActivity.Bll.Test.BllsTest.ProductColorBllTest
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class AddAsyncTest : BaseTest<ProductColorBll>
    {
        [TestMethod]
        public async Task AddAsyncHappyPath()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var request = DataTestHelper.GivenTheDefaultProductColorDto();

                var responseRepository = DataTestHelper.GivenTheDefaultProductColorDto();
                AndIMockDependencyMethod<IProductColorRepository, ProductColorDto, ProductColorDto>(autoMock, m => m.AddAsync(It.IsAny<ProductColorDto>()), responseRepository, param =>
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
                var request = DataTestHelper.GivenTheDefaultProductColorDto();

                var responseRepository = new Exception("Repository throw Exception");
                AndIMockDependencyMethod<IProductColorRepository, ProductColorDto, Exception>(autoMock, m => m.AddAsync(It.IsAny<ProductColorDto>()), responseRepository);

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
                var request = DataTestHelper.GivenTheDefaultProductColorDto();

                var innerResponse = new PostgresException("Duplicate throw Exception", null, null, BaseConstants.PG_DUPLICATE_ERROR);
                var responseRepository = new DbUpdateException("Duplicate throw Exception", innerResponse);
                AndIMockDependencyMethod<IProductColorRepository, ProductColorDto, DbUpdateException>(autoMock, m => m.AddAsync(It.IsAny<ProductColorDto>()), responseRepository);

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
                var request = DataTestHelper.GivenTheDefaultProductColorDto();

                var innerResponse = new PostgresException("Duplicate throw Exception", null, null, "No Duplicate Exception");
                var responseRepository = new DbUpdateException("Duplicate throw Exception", innerResponse);
                AndIMockDependencyMethod<IProductColorRepository, ProductColorDto, DbUpdateException>(autoMock, m => m.AddAsync(It.IsAny<ProductColorDto>()), responseRepository);

                var sut = GivenTheSystemUnderTest(autoMock);

                await sut.AddAsync(request);

                Assert.Fail("Test must have failed");
            }
        }
    }
}
