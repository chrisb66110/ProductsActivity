// ReSharper disable ConvertToUsingDeclaration

using System;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Threading.Tasks;
using APIBase.Common.Constants;
using APIBaseTest;
using Autofac.Extras.Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ProductsActivity.Api.Controllers;
using ProductsActivity.Api.Responses;
using ProductsActivity.Bll.Blls.ImageLikeBll;
using ProductsActivity.Common.Dtos.ImageLikeDtos;
using ProductsActivity.Helpers.Test;

namespace ProductsActivity.Api.Test.ControllersTest.ImageLikeControllerTest
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class GetByIdAsyncTest : BaseTest<ImageLikeController>
    {
        [TestMethod]
        public async Task GetByIdAsyncHappyPath()
        {
            using (var autoMock = AutoMock.GetStrict(RegisterBasicDependency))
            {
                var responseBll = DataTestHelper.GivenTheDefaultImageLikeDto();
                var idRequest = responseBll.Id;
                AndIMockDependencyMethod<IImageLikeBll, long, ImageLikeDto>(autoMock, m => m.GetByIdAsync(It.IsAny<long>()), responseBll, param =>
                {
                    Assert.AreEqual(idRequest, param, "Param is not correct");
                });

                var sut = GivenTheSystemUnderTest(autoMock);
                var response = await sut.GetByIdAsync(idRequest);

                Assert.AreEqual((int)HttpStatusCode.OK, response.StatusCode, "StatusCode is not correct");

                var responseObject = (ImageLikeResponse)response.Value;
                CheckAllProperties(responseBll, responseObject);
            }
        }

        [TestMethod]
        public async Task GetByIdAsyncNoContentPath()
        {
            using (var autoMock = AutoMock.GetStrict(RegisterBasicDependency))
            {
                var idRequest = 1;

                AndIMockDependencyMethod<IImageLikeBll, long, ImageLikeDto>(autoMock, m => m.GetByIdAsync(It.IsAny<long>()), null, param =>
                {
                    Assert.AreEqual(idRequest, param, "Param is not correct");
                });

                var sut = GivenTheSystemUnderTest(autoMock);
                var response = await sut.GetByIdAsync(idRequest);

                Assert.AreEqual((int)HttpStatusCode.NoContent, response.StatusCode, "StatusCode is not correct");
            }
        }

        [TestMethod]
        public async Task GetByIdAsyncErrorPath()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var idRequest = DataTestHelper.GivenTheDefaultImageLikeDto().Id;
                var exception = new Exception("BLL throw Exception");
                AndIMockDependencyMethod<IImageLikeBll, ImageLikeDto, Exception>(autoMock, m => m.GetByIdAsync(It.IsAny<long>()), exception);

                AndIMockILogger(autoMock);

                var sut = GivenTheSystemUnderTest(autoMock);
                var response = await sut.GetByIdAsync(idRequest);

                Assert.AreEqual((int)HttpStatusCode.InternalServerError, response.StatusCode, "StatusCode is not correct");
                Assert.AreEqual(BaseConstants.ERROR_MESSAGE, response.Value, "Message is not correct");
            }
        }
    }
}
