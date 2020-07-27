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
    public class ProductProfileTest : AutoMapperBaseTest<ProductProfile>
    {
        [TestMethod]
        public void MappingProductDtoToProduct()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var sut = GivenTheSystemUnderTest(autoMock);

                var dto = DataTestHelper.GivenTheDefaultProductDto();
                var model = sut.Map<ProductDto, Product>(dto);

                CheckAllProperties(dto, model);
            }
        }

        [TestMethod]
        public void MappingProductToProductDto()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var sut = GivenTheSystemUnderTest(autoMock);

                var model = DataTestHelper.GivenTheDefaultProduct();
                var dto = sut.Map<Product, ProductDto>(model);

                CheckAllProperties(model, dto);
            }
        }

        [TestMethod]
        public void MappingProductLogToProductLogDto()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var sut = GivenTheSystemUnderTest(autoMock);

                var model = DataTestHelper.GivenTheDefaultProductLog();
                var dto = sut.Map<ProductLog, ProductLogDto>(model);

                CheckAllProperties(model, dto);
            }
        }
    }
}
