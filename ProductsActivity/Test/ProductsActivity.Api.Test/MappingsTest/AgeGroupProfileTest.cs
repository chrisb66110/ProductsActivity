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
    public class AgeGroupProfileTest : AutoMapperBaseTest<AgeGroupProfile>
    {
        [TestMethod]
        public void MappingAgeGroupRequestToAgeGroupDto()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var sut = GivenTheSystemUnderTest(autoMock);

                var request = DataTestHelper.GivenTheDefaultAgeGroupRequest();
                var dto = sut.Map<AgeGroupRequest, AgeGroupDto>(request);

                CheckAllProperties(request, dto);
            }
        }

        [TestMethod]
        public void MappingAgeGroupDtoToAgeGroupResponse()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var sut = GivenTheSystemUnderTest(autoMock);

                var dto = DataTestHelper.GivenTheDefaultAgeGroupDto();
                var response = sut.Map<AgeGroupDto, AgeGroupResponse>(dto);

                CheckAllProperties(dto, response);
            }
        }

        [TestMethod]
        public void MappingAgeGroupLogDtoToAgeGroupLogResponse()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var sut = GivenTheSystemUnderTest(autoMock);

                var dto = DataTestHelper.GivenTheDefaultAgeGroupLogDto();
                var response = sut.Map<AgeGroupLogDto, AgeGroupLogResponse>(dto);

                CheckAllProperties(dto, response);
            }
        }
    }
}
