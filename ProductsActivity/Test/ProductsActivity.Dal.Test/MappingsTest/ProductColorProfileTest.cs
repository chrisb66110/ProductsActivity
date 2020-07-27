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
    public class ProductColorProfileTest : AutoMapperBaseTest<ProductColorProfile>
    {
        [TestMethod]
        public void MappingProductColorDtoToProductColor()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var sut = GivenTheSystemUnderTest(autoMock);

                var dto = DataTestHelper.GivenTheDefaultProductColorDto();
                var model = sut.Map<ProductColorDto, ProductColor>(dto);

                CheckAllProperties(dto, model);
            }
        }

        [TestMethod]
        public void MappingProductColorToProductColorDto()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var sut = GivenTheSystemUnderTest(autoMock);

                var model = DataTestHelper.GivenTheDefaultProductColor();
                var dto = sut.Map<ProductColor, ProductColorDto>(model);

                CheckAllProperties(model, dto);
            }
        }

        [TestMethod]
        public void MappingProductColorLogToProductColorLogDto()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var sut = GivenTheSystemUnderTest(autoMock);

                var model = DataTestHelper.GivenTheDefaultProductColorLog();
                var dto = sut.Map<ProductColorLog, ProductColorLogDto>(model);

                CheckAllProperties(model, dto);
            }
        }
    }
}
