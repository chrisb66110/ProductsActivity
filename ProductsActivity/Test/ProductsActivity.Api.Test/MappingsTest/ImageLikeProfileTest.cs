// ReSharper disable ConvertToUsingDeclaration

using System.Diagnostics.CodeAnalysis;
using APIBaseTest;
using Autofac.Extras.Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductsActivity.Api.Mappings;
using ProductsActivity.Api.Requests;
using ProductsActivity.Api.Responses;
using ProductsActivity.Common.Dtos.ImageLikeDtos;
using ProductsActivity.Helpers.Test;

namespace ProductsActivity.Api.Test.MappingsTest
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class ImageLikeProfileTest : AutoMapperBaseTest<ImageLikeProfile>
    {
        [TestMethod]
        public void MappingImageLikeRequestToImageLikeDto()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var sut = GivenTheSystemUnderTest(autoMock);

                var request = DataTestHelper.GivenTheDefaultImageLikeRequest();
                var dto = sut.Map<ImageLikeRequest, ImageLikeDto>(request);

                CheckAllProperties(request, dto);
            }
        }

        [TestMethod]
        public void MappingImageLikeDtoToImageLikeResponse()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var sut = GivenTheSystemUnderTest(autoMock);

                var dto = DataTestHelper.GivenTheDefaultImageLikeDto();
                var response = sut.Map<ImageLikeDto, ImageLikeResponse>(dto);

                CheckAllProperties(dto, response);
            }
        }

        [TestMethod]
        public void MappingImageLikeLogDtoToImageLikeLogResponse()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var sut = GivenTheSystemUnderTest(autoMock);

                var dto = DataTestHelper.GivenTheDefaultImageLikeLogDto();
                var response = sut.Map<ImageLikeLogDto, ImageLikeLogResponse>(dto);

                CheckAllProperties(dto, response);
            }
        }
    }
}
