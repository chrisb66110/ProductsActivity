// ReSharper disable ConvertToUsingDeclaration

using System.Diagnostics.CodeAnalysis;
using APIBaseTest;
using Autofac.Extras.Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductsActivity.Common.Dtos.ImageLikeDtos;
using ProductsActivity.Dal.Mappings;
using ProductsActivity.Dal.Models;
using ProductsActivity.Helpers.Test;

namespace ProductsActivity.Dal.Test.MappingsTest
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class ImageLikeProfileTest : AutoMapperBaseTest<ImageLikeProfile>
    {
        [TestMethod]
        public void MappingImageLikeDtoToImageLike()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var sut = GivenTheSystemUnderTest(autoMock);

                var dto = DataTestHelper.GivenTheDefaultImageLikeDto();
                var model = sut.Map<ImageLikeDto, ImageLike>(dto);

                CheckAllProperties(dto, model);
            }
        }

        [TestMethod]
        public void MappingImageLikeToImageLikeDto()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var sut = GivenTheSystemUnderTest(autoMock);

                var model = DataTestHelper.GivenTheDefaultImageLike();
                var dto = sut.Map<ImageLike, ImageLikeDto>(model);

                CheckAllProperties(model, dto);
            }
        }

        [TestMethod]
        public void MappingImageLikeLogToImageLikeLogDto()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var sut = GivenTheSystemUnderTest(autoMock);

                var model = DataTestHelper.GivenTheDefaultImageLikeLog();
                var dto = sut.Map<ImageLikeLog, ImageLikeLogDto>(model);

                CheckAllProperties(model, dto);
            }
        }
    }
}
