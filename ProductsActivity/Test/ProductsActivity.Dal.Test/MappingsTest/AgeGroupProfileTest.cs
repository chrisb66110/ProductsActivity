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
    public class AgeGroupProfileTest : AutoMapperBaseTest<AgeGroupProfile>
    {
        [TestMethod]
        public void MappingAgeGroupDtoToAgeGroup()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var sut = GivenTheSystemUnderTest(autoMock);

                var dto = DataTestHelper.GivenTheDefaultAgeGroupDto();
                var model = sut.Map<AgeGroupDto, AgeGroup>(dto);

                CheckAllProperties(dto, model);
            }
        }

        [TestMethod]
        public void MappingAgeGroupToAgeGroupDto()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var sut = GivenTheSystemUnderTest(autoMock);

                var model = DataTestHelper.GivenTheDefaultAgeGroup();
                var dto = sut.Map<AgeGroup, AgeGroupDto>(model);

                CheckAllProperties(model, dto);
            }
        }

        [TestMethod]
        public void MappingAgeGroupLogToAgeGroupLogDto()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var sut = GivenTheSystemUnderTest(autoMock);

                var model = DataTestHelper.GivenTheDefaultAgeGroupLog();
                var dto = sut.Map<AgeGroupLog, AgeGroupLogDto>(model);

                CheckAllProperties(model, dto);
            }
        }
    }
}
