// ReSharper disable ConvertToUsingDeclaration

using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using APIBaseTest;
using Autofac.Extras.Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ProductsActivity.Bll.Blls.ImageBll;
using ProductsActivity.Common.Dtos.ProductDtos;
using ProductsActivity.Dal.Repositories.ImageRepository;
using ProductsActivity.Helpers.Test;

namespace ProductsActivity.Bll.Test.BllsTest.ImageBllTest
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class GetByIdAsyncTest : BaseTest<ImageBll>
    {
        [TestMethod]
        public async Task GetByIdAsyncHappyPath()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var responseRepository = DataTestHelper.GivenTheDefaultImageDto();
                var idRequest = responseRepository.Id;
                AndIMockDependencyMethod<IImageRepository, long, ImageDto>(autoMock, m => m.GetByIdAsync(It.IsAny<long>()), responseRepository, param =>
                {
                    Assert.AreEqual(idRequest, param, "Param is not correct");
                });

                var sut = GivenTheSystemUnderTest(autoMock);
                var response = await sut.GetByIdAsync(idRequest);

                CheckAllProperties(responseRepository, response);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public async Task GetByIdAsyncErrorPath()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var responseRepository = new Exception("Repository throw Exception");
                var idRequest = DataTestHelper.GivenTheDefaultImageDto().Id;
                AndIMockDependencyMethod<IImageRepository, ImageDto, Exception>(autoMock, m => m.GetByIdAsync(It.IsAny<long>()), responseRepository);

                var sut = GivenTheSystemUnderTest(autoMock);
                await sut.GetByIdAsync(idRequest);

                Assert.Fail("Test must have failed");
            }
        }
    }
}
