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
    public class SizeProfileTest : AutoMapperBaseTest<SizeProfile>
    {
        [TestMethod]
        public void MappingSizeRequestToSizeDto()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var sut = GivenTheSystemUnderTest(autoMock);

                var request = DataTestHelper.GivenTheDefaultSizeRequest();
                var dto = sut.Map<SizeRequest, SizeDto>(request);

                CheckAllProperties(request, dto);
            }
        }

        [TestMethod]
        public void MappingSizeDtoToSizeResponse()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var sut = GivenTheSystemUnderTest(autoMock);

                var dto = DataTestHelper.GivenTheDefaultSizeDto();
                var response = sut.Map<SizeDto, SizeResponse>(dto);

                CheckAllProperties(dto, response);
            }
        }

        [TestMethod]
        public void MappingSizeLogDtoToSizeLogResponse()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var sut = GivenTheSystemUnderTest(autoMock);

                var dto = DataTestHelper.GivenTheDefaultSizeLogDto();
                var response = sut.Map<SizeLogDto, SizeLogResponse>(dto);

                CheckAllProperties(dto, response);
            }
        }
    }
}
