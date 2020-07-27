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
using ProductsActivity.Bll.Blls.CategoryBll;
using ProductsActivity.Common.Dtos.ProductDtos;
using ProductsActivity.Dal.Repositories.CategoryRepository;
using ProductsActivity.Helpers.Test;

namespace ProductsActivity.Bll.Test.BllsTest.CategoryBllTest
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class UpdateAsyncTest : BaseTest<CategoryBll>
    {
        [TestMethod]
        public async Task UpdateAsyncHappyPath()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var request = DataTestHelper.GivenTheDefaultCategoryDto();

                var responseRepository = DataTestHelper.GivenTheDefaultCategoryDto();
                AndIMockDependencyMethod<ICategoryRepository, CategoryDto, CategoryDto>(autoMock, m => m.UpdateAsync(It.IsAny<CategoryDto>()), responseRepository, param =>
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
                var request = DataTestHelper.GivenTheDefaultCategoryDto();

                var responseRepository = new Exception("Repository throw Exception");
                AndIMockDependencyMethod<ICategoryRepository, CategoryDto, Exception>(autoMock, m => m.UpdateAsync(It.IsAny<CategoryDto>()), responseRepository);

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
                var request = DataTestHelper.GivenTheDefaultCategoryDto();

                var responseRepository = new DbUpdateConcurrencyException(BaseConstants.PG_ERROR_DONT_AFFECT_ENTITY);
                AndIMockDependencyMethod<ICategoryRepository, CategoryDto, DbUpdateConcurrencyException>(autoMock, m => m.UpdateAsync(It.IsAny<CategoryDto>()), responseRepository);

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
                var request = DataTestHelper.GivenTheDefaultCategoryDto();

                var responseRepository = new DbUpdateConcurrencyException("Throw Exception");
                AndIMockDependencyMethod<ICategoryRepository, CategoryDto, DbUpdateConcurrencyException>(autoMock, m => m.UpdateAsync(It.IsAny<CategoryDto>()), responseRepository);

                var sut = GivenTheSystemUnderTest(autoMock);

                var response = await sut.UpdateAsync(request);

                Assert.AreEqual(null, response, "response should be null");
            }
        }
    }
}
