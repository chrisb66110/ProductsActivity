// ReSharper disable ConvertToUsingDeclaration

using System.Diagnostics.CodeAnalysis;
using APIBaseTest;
using Autofac.Extras.Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductsActivity.Common.Dtos.ProductLikeDtos;
using ProductsActivity.Dal.Mappings;
using ProductsActivity.Dal.Models;
using ProductsActivity.Helpers.Test;

namespace ProductsActivity.Dal.Test.MappingsTest
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class ProductLikeProfileTest : AutoMapperBaseTest<ProductLikeProfile>
    {
        [TestMethod]
        public void MappingProductLikeDtoToProductLike()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var sut = GivenTheSystemUnderTest(autoMock);

                var dto = DataTestHelper.GivenTheDefaultProductLikeDto();
                var model = sut.Map<ProductLikeDto, ProductLike>(dto);

                CheckAllProperties(dto, model);
            }
        }

        [TestMethod]
        public void MappingProductLikeToProductLikeDto()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var sut = GivenTheSystemUnderTest(autoMock);

                var model = DataTestHelper.GivenTheDefaultProductLike();
                var dto = sut.Map<ProductLike, ProductLikeDto>(model);

                CheckAllProperties(model, dto);
            }
        }

        [TestMethod]
        public void MappingProductLikeLogToProductLikeLogDto()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var sut = GivenTheSystemUnderTest(autoMock);

                var model = DataTestHelper.GivenTheDefaultProductLikeLog();
                var dto = sut.Map<ProductLikeLog, ProductLikeLogDto>(model);

                CheckAllProperties(model, dto);
            }
        }
    }
}
