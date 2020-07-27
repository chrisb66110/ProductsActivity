// ReSharper disable ConvertToUsingDeclaration

using System.Diagnostics.CodeAnalysis;
using APIBaseTest;
using Autofac.Extras.Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductsActivity.Common.Dtos.ProductViewedDtos;
using ProductsActivity.Dal.Mappings;
using ProductsActivity.Dal.Models;
using ProductsActivity.Helpers.Test;

namespace ProductsActivity.Dal.Test.MappingsTest
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class ProductViewedProfileTest : AutoMapperBaseTest<ProductViewedProfile>
    {
        [TestMethod]
        public void MappingProductViewedDtoToProductViewed()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var sut = GivenTheSystemUnderTest(autoMock);

                var dto = DataTestHelper.GivenTheDefaultProductViewedDto();
                var model = sut.Map<ProductViewedDto, ProductViewed>(dto);

                CheckAllProperties(dto, model);
            }
        }

        [TestMethod]
        public void MappingProductViewedToProductViewedDto()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var sut = GivenTheSystemUnderTest(autoMock);

                var model = DataTestHelper.GivenTheDefaultProductViewed();
                var dto = sut.Map<ProductViewed, ProductViewedDto>(model);

                CheckAllProperties(model, dto);
            }
        }

        [TestMethod]
        public void MappingProductViewedLogToProductViewedLogDto()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var sut = GivenTheSystemUnderTest(autoMock);

                var model = DataTestHelper.GivenTheDefaultProductViewedLog();
                var dto = sut.Map<ProductViewedLog, ProductViewedLogDto>(model);

                CheckAllProperties(model, dto);
            }
        }
    }
}
