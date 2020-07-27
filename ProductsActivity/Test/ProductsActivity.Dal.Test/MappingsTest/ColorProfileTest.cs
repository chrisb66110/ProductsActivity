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
    public class ColorProfileTest : AutoMapperBaseTest<ColorProfile>
    {
        [TestMethod]
        public void MappingColorDtoToColor()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var sut = GivenTheSystemUnderTest(autoMock);

                var dto = DataTestHelper.GivenTheDefaultColorDto();
                var model = sut.Map<ColorDto, Color>(dto);

                CheckAllProperties(dto, model);
            }
        }

        [TestMethod]
        public void MappingColorToColorDto()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var sut = GivenTheSystemUnderTest(autoMock);

                var model = DataTestHelper.GivenTheDefaultColor();
                var dto = sut.Map<Color, ColorDto>(model);

                CheckAllProperties(model, dto);
            }
        }

        [TestMethod]
        public void MappingColorLogToColorLogDto()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var sut = GivenTheSystemUnderTest(autoMock);

                var model = DataTestHelper.GivenTheDefaultColorLog();
                var dto = sut.Map<ColorLog, ColorLogDto>(model);

                CheckAllProperties(model, dto);
            }
        }
    }
}
