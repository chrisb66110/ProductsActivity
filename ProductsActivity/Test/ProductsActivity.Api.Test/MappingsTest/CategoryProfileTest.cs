// ReSharper disable ConvertToUsingDeclaration

using System.Diagnostics.CodeAnalysis;
using APIBaseTest;
using Autofac.Extras.Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductsActivity.Api.Mappings;
using ProductsActivity.Api.Requests;
using ProductsActivity.Api.Responses;
using ProductsActivity.Common.Dtos.ProductDtos;
using ProductsActivity.Helpers.Test;

namespace ProductsActivity.Api.Test.MappingsTest
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class CategoryProfileTest : AutoMapperBaseTest<CategoryProfile>
    {
        [TestMethod]
        public void MappingCategoryRequestToCategoryDto()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var sut = GivenTheSystemUnderTest(autoMock);

                var request = DataTestHelper.GivenTheDefaultCategoryRequest();
                var dto = sut.Map<CategoryRequest, CategoryDto>(request);

                CheckAllProperties(request, dto);
            }
        }

        [TestMethod]
        public void MappingCategoryDtoToCategoryResponse()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var sut = GivenTheSystemUnderTest(autoMock);

                var dto = DataTestHelper.GivenTheDefaultCategoryDto();
                var response = sut.Map<CategoryDto, CategoryResponse>(dto);

                CheckAllProperties(dto, response);
            }
        }

        [TestMethod]
        public void MappingCategoryLogDtoToCategoryLogResponse()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var sut = GivenTheSystemUnderTest(autoMock);

                var dto = DataTestHelper.GivenTheDefaultCategoryLogDto();
                var response = sut.Map<CategoryLogDto, CategoryLogResponse>(dto);

                CheckAllProperties(dto, response);
            }
        }
    }
}
