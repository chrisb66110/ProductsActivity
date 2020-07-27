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
using ProductsActivity.Bll.Blls.ImageLikeBll;
using ProductsActivity.Common.Dtos.ImageLikeDtos;
using ProductsActivity.Dal.Repositories.ImageLikeRepository;
using ProductsActivity.Helpers.Test;
using Npgsql;

namespace ProductsActivity.Bll.Test.BllsTest.ImageLikeBllTest
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class AddAsyncTest : BaseTest<ImageLikeBll>
    {
        [TestMethod]
        public async Task AddAsyncHappyPath()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var request = DataTestHelper.GivenTheDefaultImageLikeDto();

                var responseRepository = DataTestHelper.GivenTheDefaultImageLikeDto();
                AndIMockDependencyMethod<IImageLikeRepository, ImageLikeDto, ImageLikeDto>(autoMock, m => m.AddAsync(It.IsAny<ImageLikeDto>()), responseRepository, param =>
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
                var request = DataTestHelper.GivenTheDefaultImageLikeDto();

                var responseRepository = new Exception("Repository throw Exception");
                AndIMockDependencyMethod<IImageLikeRepository, ImageLikeDto, Exception>(autoMock, m => m.AddAsync(It.IsAny<ImageLikeDto>()), responseRepository);

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
                var request = DataTestHelper.GivenTheDefaultImageLikeDto();

                var innerResponse = new PostgresException("Duplicate throw Exception", null, null, BaseConstants.PG_DUPLICATE_ERROR);
                var responseRepository = new DbUpdateException("Duplicate throw Exception", innerResponse);
                AndIMockDependencyMethod<IImageLikeRepository, ImageLikeDto, DbUpdateException>(autoMock, m => m.AddAsync(It.IsAny<ImageLikeDto>()), responseRepository);

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
                var request = DataTestHelper.GivenTheDefaultImageLikeDto();

                var innerResponse = new PostgresException("Duplicate throw Exception", null, null, "No Duplicate Exception");
                var responseRepository = new DbUpdateException("Duplicate throw Exception", innerResponse);
                AndIMockDependencyMethod<IImageLikeRepository, ImageLikeDto, DbUpdateException>(autoMock, m => m.AddAsync(It.IsAny<ImageLikeDto>()), responseRepository);

                var sut = GivenTheSystemUnderTest(autoMock);

                await sut.AddAsync(request);

                Assert.Fail("Test must have failed");
            }
        }
    }
}
