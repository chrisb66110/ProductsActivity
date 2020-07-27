// ReSharper disable ConvertToUsingDeclaration

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using APIBaseTest;
using Autofac.Extras.Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductsActivity.Bll.Blls.SizeBll;
using ProductsActivity.Dal.Repositories.SizeRepository;
using ProductsActivity.Helpers.Test;

namespace ProductsActivity.Bll.Test.BllsTest.SizeBllTest
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class GetLogsAsyncTest : BaseTest<SizeBll>
    {
        [TestMethod]
        public async Task GetLogsAsyncHappyPath()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var responseRepository = DataTestHelper.GivenTheDefaultListSizeLogDto();

                AndIMockDependencyMethod<ISizeRepository, List<SizeLogDto>>(autoMock, m => m.GetLogsAsync(), responseRepository);

                var sut = GivenTheSystemUnderTest(autoMock);
                var response = await sut.GetLogsAsync();

                for (int index = 0; index < responseRepository.Count; index++)
                {
                    Assert.AreEqual(responseRepository[index].Id, response[index].Id, $"[{index}].Id is not correct");
                    Assert.AreEqual(responseRepository[index].Username, response[index].Username, $"[{index}].Username is not correct");
                    Assert.AreEqual(responseRepository[index].DateTime, response[index].DateTime, $"[{index}].DateTime is not correct");

                    CheckAllProperties(responseRepository[index].PreviousEntity, response[index].PreviousEntity);

                    CheckAllProperties(responseRepository[index].NewEntity, response[index].NewEntity);
                }
            }
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public async Task GetLogsAsyncErrorPath()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var responseRepository = new Exception("Repository throw Exception");
                AndIMockDependencyMethod<ISizeRepository, List<SizeLogDto>, Exception>(autoMock, m => m.GetLogsAsync(), responseRepository);

                var sut = GivenTheSystemUnderTest(autoMock);
                await sut.GetLogsAsync();

                Assert.Fail("Test must have failed");
            }
        }
    }
}

