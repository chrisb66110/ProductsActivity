// ReSharper disable ConvertToUsingDeclaration

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Threading.Tasks;
using APIBase.Common.Constants;
using APIBaseTest;
using Autofac.Extras.Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductsActivity.Api.Controllers;
using ProductsActivity.Api.Responses;
using ProductsActivity.Bll.Blls.ProductBll;
using ProductsActivity.Common.Dtos.ProductDtos;
using ProductsActivity.Helpers.Test;

namespace ProductsActivity.Api.Test.ControllersTest.ProductControllerTest
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class GetLogsAsyncTest : BaseTest<ProductController>
    {
        [TestMethod]
        public async Task GetLogsAsyncHappyPath()
        {
            using (var autoMock = AutoMock.GetStrict(RegisterBasicDependency))
            {
                var responseBll = DataTestHelper.GivenTheDefaultListProductLogDto();
                AndIMockDependencyMethod<IProductBll, List<ProductLogDto>>(autoMock, m => m.GetLogsAsync(), responseBll);

                var sut = GivenTheSystemUnderTest(autoMock);
                var response = await sut.GetLogsAsync();

                Assert.AreEqual((int)HttpStatusCode.OK, response.StatusCode, "StatusCode is not correct");

                var responseObject = (List<ProductLogResponse>)response.Value;

                for (int index = 0; index < responseBll.Count; index++)
                {
                    Assert.AreEqual(responseBll[index].Id, responseObject[index].Id, $"[{index}].Id is not correct");
                    Assert.AreEqual(responseBll[index].Username, responseObject[index].Username, $"[{index}].Username is not correct");
                    Assert.AreEqual(responseBll[index].DateTime, responseObject[index].DateTime, $"[{index}].DateTime is not correct");

                    CheckAllProperties(responseBll[index].PreviousEntity, responseObject[index].PreviousEntity);

                    CheckAllProperties(responseBll[index].NewEntity, responseObject[index].NewEntity);
                }
            }
        }

        [TestMethod]
        public async Task GetLogsAsyncNoContentPath()
        {
            using (var autoMock = AutoMock.GetStrict(RegisterBasicDependency))
            {
                var responseBll = new List<ProductLogDto>();
                AndIMockDependencyMethod<IProductBll, List<ProductLogDto>>(autoMock, m => m.GetLogsAsync(), responseBll);

                var sut = GivenTheSystemUnderTest(autoMock);
                var response = await sut.GetLogsAsync();

                Assert.AreEqual((int)HttpStatusCode.NoContent, response.StatusCode, "StatusCode is not correct");
            }
        }

        [TestMethod]
        public async Task GetLogsAsyncErrorPath()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var exception = new Exception("BLL throw Exception");
                AndIMockDependencyMethod<IProductBll, List<ProductLogDto>, Exception>(autoMock, m => m.GetLogsAsync(), exception);

                AndIMockILogger(autoMock);

                var sut = GivenTheSystemUnderTest(autoMock);
                var response = await sut.GetLogsAsync();

                Assert.AreEqual((int)HttpStatusCode.InternalServerError, response.StatusCode, "StatusCode is not correct");
                Assert.AreEqual(BaseConstants.ERROR_MESSAGE, response.Value, "Message is not correct");
            }
        }
    }
}

