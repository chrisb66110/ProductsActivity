// ReSharper disable ConvertToUsingDeclaration

using System.Diagnostics.CodeAnalysis;
using APIBaseTest;
using Autofac.Extras.Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductsActivity.Api.Mappings;
using ProductsActivity.Api.Requests;
using ProductsActivity.Api.Responses;
using ProductsActivity.Common.Dtos.ProductDtos;
using ProductsActivity.Helpers.Test;

namespace ProductsActivity.Api.Test.MappingsTest
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class GenderProfileTest : AutoMapperBaseTest<GenderProfile>
    {
        [TestMethod]
        public void MappingGenderRequestToGenderDto()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var sut = GivenTheSystemUnderTest(autoMock);

                var request = DataTestHelper.GivenTheDefaultGenderRequest();
                var dto = sut.Map<GenderRequest, GenderDto>(request);

                CheckAllProperties(request, dto);
            }
        }

        [TestMethod]
        public void MappingGenderDtoToGenderResponse()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var sut = GivenTheSystemUnderTest(autoMock);

                var dto = DataTestHelper.GivenTheDefaultGenderDto();
                var response = sut.Map<GenderDto, GenderResponse>(dto);

                CheckAllProperties(dto, response);
            }
        }

        [TestMethod]
        public void MappingGenderLogDtoToGenderLogResponse()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var sut = GivenTheSystemUnderTest(autoMock);

                var dto = DataTestHelper.GivenTheDefaultGenderLogDto();
                var response = sut.Map<GenderLogDto, GenderLogResponse>(dto);

                CheckAllProperties(dto, response);
            }
        }
    }
}
