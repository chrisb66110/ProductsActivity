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
    public class ImageProfileTest : AutoMapperBaseTest<ImageProfile>
    {
        [TestMethod]
        public void MappingImageDtoToImage()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var sut = GivenTheSystemUnderTest(autoMock);

                var dto = DataTestHelper.GivenTheDefaultImageDto();
                var model = sut.Map<ImageDto, Image>(dto);

                CheckAllProperties(dto, model);
            }
        }

        [TestMethod]
        public void MappingImageToImageDto()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var sut = GivenTheSystemUnderTest(autoMock);

                var model = DataTestHelper.GivenTheDefaultImage();
                var dto = sut.Map<Image, ImageDto>(model);

                CheckAllProperties(model, dto);
            }
        }

        [TestMethod]
        public void MappingImageLogToImageLogDto()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var sut = GivenTheSystemUnderTest(autoMock);

                var model = DataTestHelper.GivenTheDefaultImageLog();
                var dto = sut.Map<ImageLog, ImageLogDto>(model);

                CheckAllProperties(model, dto);
            }
        }
    }
}
