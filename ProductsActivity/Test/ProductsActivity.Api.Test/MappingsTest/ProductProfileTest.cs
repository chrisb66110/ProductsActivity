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
    public class ProductProfileTest : AutoMapperBaseTest<ProductProfile>
    {
        [TestMethod]
        public void MappingProductRequestToProductDto()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var sut = GivenTheSystemUnderTest(autoMock);

                var request = DataTestHelper.GivenTheDefaultProductRequest();
                var dto = sut.Map<ProductRequest, ProductDto>(request);

                CheckAllProperties(request, dto);
            }
        }

        [TestMethod]
        public void MappingProductDtoToProductResponse()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var sut = GivenTheSystemUnderTest(autoMock);

                var dto = DataTestHelper.GivenTheDefaultProductDto();
                var response = sut.Map<ProductDto, ProductResponse>(dto);

                CheckAllProperties(dto, response);
            }
        }

        [TestMethod]
        public void MappingProductLogDtoToProductLogResponse()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var sut = GivenTheSystemUnderTest(autoMock);

                var dto = DataTestHelper.GivenTheDefaultProductLogDto();
                var response = sut.Map<ProductLogDto, ProductLogResponse>(dto);

                CheckAllProperties(dto, response);
            }
        }
    }
}
