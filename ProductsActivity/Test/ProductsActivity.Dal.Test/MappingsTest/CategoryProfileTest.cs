// ReSharper disable ConvertToUsingDeclaration

using System.Diagnostics.CodeAnalysis;
using APIBaseTest;
using Autofac.Extras.Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductsActivity.Common.Dtos.ProductDtos;
using ProductsActivity.Dal.Mappings;
using ProductsActivity.Dal.Models;
using ProductsActivity.Helpers.Test;

namespace ProductsActivity.Dal.Test.MappingsTest
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class CategoryProfileTest : AutoMapperBaseTest<CategoryProfile>
    {
        [TestMethod]
        public void MappingCategoryDtoToCategory()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var sut = GivenTheSystemUnderTest(autoMock);

                var dto = DataTestHelper.GivenTheDefaultCategoryDto();
                var model = sut.Map<CategoryDto, Category>(dto);

                CheckAllProperties(dto, model);
            }
        }

        [TestMethod]
        public void MappingCategoryToCategoryDto()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var sut = GivenTheSystemUnderTest(autoMock);

                var model = DataTestHelper.GivenTheDefaultCategory();
                var dto = sut.Map<Category, CategoryDto>(model);

                CheckAllProperties(model, dto);
            }
        }

        [TestMethod]
        public void MappingCategoryLogToCategoryLogDto()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var sut = GivenTheSystemUnderTest(autoMock);

                var model = DataTestHelper.GivenTheDefaultCategoryLog();
                var dto = sut.Map<CategoryLog, CategoryLogDto>(model);

                CheckAllProperties(model, dto);
            }
        }
    }
}
