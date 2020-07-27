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
using ProductsActivity.Bll.Blls.GenderBll;
using ProductsActivity.Common.Dtos.ProductDtos;
using ProductsActivity.Dal.Repositories.GenderRepository;
using ProductsActivity.Helpers.Test;

namespace ProductsActivity.Bll.Test.BllsTest.GenderBllTest
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class UpdateAsyncTest : BaseTest<GenderBll>
    {
        [TestMethod]
        public async Task UpdateAsyncHappyPath()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var request = DataTestHelper.GivenTheDefaultGenderDto();

                var responseRepository = DataTestHelper.GivenTheDefaultGenderDto();
                AndIMockDependencyMethod<IGenderRepository, GenderDto, GenderDto>(autoMock, m => m.UpdateAsync(It.IsAny<GenderDto>()), responseRepository, param =>
                {
                    CheckAllProperties(request, param);
                });

                var sut = GivenTheSystemUnderTest(autoMock);
                var response = await sut.UpdateAsync(request);

                CheckAllProperties(responseRepository, response);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public async Task UpdateAsyncErrorPath()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var request = DataTestHelper.GivenTheDefaultGenderDto();

                var responseRepository = new Exception("Repository throw Exception");
                AndIMockDependencyMethod<IGenderRepository, GenderDto, Exception>(autoMock, m => m.UpdateAsync(It.IsAny<GenderDto>()), responseRepository);

                var sut = GivenTheSystemUnderTest(autoMock);
                await sut.UpdateAsync(request);

                Assert.Fail("Test must have failed");
            }
        }

        [TestMethod]
        public async Task UpdateAsyncDbUpdateConcurrencyExceptionPathDontExist()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var request = DataTestHelper.GivenTheDefaultGenderDto();

                var responseRepository = new DbUpdateConcurrencyException(BaseConstants.PG_ERROR_DONT_AFFECT_ENTITY);
                AndIMockDependencyMethod<IGenderRepository, GenderDto, DbUpdateConcurrencyException>(autoMock, m => m.UpdateAsync(It.IsAny<GenderDto>()), responseRepository);

                var sut = GivenTheSystemUnderTest(autoMock);

                var response = await sut.UpdateAsync(request);

                Assert.AreEqual(null, response, "response should be null");
            }
        }

        [TestMethod]
        [ExpectedException(typeof(DbUpdateConcurrencyException))]
        public async Task UpdateAsyncDbUpdateConcurrencyExceptionPath()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var request = DataTestHelper.GivenTheDefaultGenderDto();

                var responseRepository = new DbUpdateConcurrencyException("Throw Exception");
                AndIMockDependencyMethod<IGenderRepository, GenderDto, DbUpdateConcurrencyException>(autoMock, m => m.UpdateAsync(It.IsAny<GenderDto>()), responseRepository);

                var sut = GivenTheSystemUnderTest(autoMock);

                var response = await sut.UpdateAsync(request);

                Assert.AreEqual(null, response, "response should be null");
            }
        }
    }
}
