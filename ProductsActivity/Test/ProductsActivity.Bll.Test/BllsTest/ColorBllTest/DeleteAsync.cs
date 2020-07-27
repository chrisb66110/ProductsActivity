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
using ProductsActivity.Bll.Blls.ColorBll;
using ProductsActivity.Common.Dtos.ProductDtos;
using ProductsActivity.Dal.Repositories.ColorRepository;
using ProductsActivity.Helpers.Test;

namespace ProductsActivity.Bll.Test.BllsTest.ColorBllTest
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class DeleteAsyncTest : BaseTest<ColorBll>
    {
        [TestMethod]
        public async Task DeleteAsyncHappyPath()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var request = DataTestHelper.GivenTheDefaultColorDto();

                var responseRepository = DataTestHelper.GivenTheDefaultColorDto();
                AndIMockDependencyMethod<IColorRepository, ColorDto, ColorDto>(autoMock, m => m.DeleteAsync(It.IsAny<ColorDto>()), responseRepository, param =>
                {
                    CheckAllProperties(request, param);
                });

                var sut = GivenTheSystemUnderTest(autoMock);
                var response = await sut.DeleteAsync(request);

                CheckAllProperties(responseRepository, response);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public async Task DeleteAsyncErrorPath()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var request = DataTestHelper.GivenTheDefaultColorDto();

                var responseRepository = new Exception("Repository throw Exception");
                AndIMockDependencyMethod<IColorRepository, ColorDto, Exception>(autoMock, m => m.DeleteAsync(It.IsAny<ColorDto>()), responseRepository);

                var sut = GivenTheSystemUnderTest(autoMock);
                await sut.DeleteAsync(request);

                Assert.Fail("Test must have failed");
            }
        }

        [TestMethod]
        public async Task DeleteAsyncDbUpdateConcurrencyExceptionPathDontExist()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var request = DataTestHelper.GivenTheDefaultColorDto();

                var responseRepository = new DbUpdateConcurrencyException(BaseConstants.PG_ERROR_DONT_AFFECT_ENTITY);
                AndIMockDependencyMethod<IColorRepository, ColorDto, DbUpdateConcurrencyException>(autoMock, m => m.DeleteAsync(It.IsAny<ColorDto>()), responseRepository);

                var sut = GivenTheSystemUnderTest(autoMock);

                var response = await sut.DeleteAsync(request);

                Assert.AreEqual(null, response, "response should be null");
            }
        }

        [TestMethod]
        [ExpectedException(typeof(DbUpdateConcurrencyException))]
        public async Task DeleteAsyncDbUpdateConcurrencyExceptionPath()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var request = DataTestHelper.GivenTheDefaultColorDto();

                var responseRepository = new DbUpdateConcurrencyException("Throw Exception");
                AndIMockDependencyMethod<IColorRepository, ColorDto, DbUpdateConcurrencyException>(autoMock, m => m.DeleteAsync(It.IsAny<ColorDto>()), responseRepository);

                var sut = GivenTheSystemUnderTest(autoMock);

                var response = await sut.DeleteAsync(request);

                Assert.AreEqual(null, response, "response should be null");
            }
        }
    }
}
