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
    public class GenderProfileTest : AutoMapperBaseTest<GenderProfile>
    {
        [TestMethod]
        public void MappingGenderDtoToGender()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var sut = GivenTheSystemUnderTest(autoMock);

                var dto = DataTestHelper.GivenTheDefaultGenderDto();
                var model = sut.Map<GenderDto, Gender>(dto);

                CheckAllProperties(dto, model);
            }
        }

        [TestMethod]
        public void MappingGenderToGenderDto()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var sut = GivenTheSystemUnderTest(autoMock);

                var model = DataTestHelper.GivenTheDefaultGender();
                var dto = sut.Map<Gender, GenderDto>(model);

                CheckAllProperties(model, dto);
            }
        }

        [TestMethod]
        public void MappingGenderLogToGenderLogDto()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var sut = GivenTheSystemUnderTest(autoMock);

                var model = DataTestHelper.GivenTheDefaultGenderLog();
                var dto = sut.Map<GenderLog, GenderLogDto>(model);

                CheckAllProperties(model, dto);
            }
        }
    }
}
