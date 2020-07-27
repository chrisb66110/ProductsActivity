// ReSharper disable ConvertToUsingDeclaration

using System.Diagnostics.CodeAnalysis;
using APIBaseTest;
using Autofac.Extras.Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductsActivity.Api.Mappings;
using ProductsActivity.Api.Requests;
using ProductsActivity.Api.Responses;
using ProductsActivity.Api.Responses.ProductResponses;
using ProductsActivity.Common.Dtos.ProductDtos;
using ProductsActivity.Helpers.Test;

namespace ProductsActivity.Api.Test.MappingsTest
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class ProductColorProfileTest : AutoMapperBaseTest<ProductColorProfile>
    {
        [TestMethod]
        public void MappingProductColorRequestToProductColorDto()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var sut = GivenTheSystemUnderTest(autoMock);

                var request = DataTestHelper.GivenTheDefaultProductColorRequest();
                var dto = sut.Map<ProductColorRequest, ProductColorDto>(request);

                CheckAllProperties(request, dto);
            }
        }

        [TestMethod]
        public void MappingProductColorDtoToProductColorResponse()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var sut = GivenTheSystemUnderTest(autoMock);

                var dto = DataTestHelper.GivenTheDefaultProductColorDto();
                var response = sut.Map<ProductColorDto, ProductColorResponse>(dto);

                CheckAllProperties(dto, response);
            }
        }

        [TestMethod]
        public void MappingProductColorLogDtoToProductColorLogResponse()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var sut = GivenTheSystemUnderTest(autoMock);

                var dto = DataTestHelper.GivenTheDefaultProductColorLogDto();
                var response = sut.Map<ProductColorLogDto, ProductColorLogResponse>(dto);

                CheckAllProperties(dto, response);
            }
        }
    }
}
