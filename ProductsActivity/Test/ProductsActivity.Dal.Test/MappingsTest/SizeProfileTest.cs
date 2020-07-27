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
    public class SizeProfileTest : AutoMapperBaseTest<SizeProfile>
    {
        [TestMethod]
        public void MappingSizeDtoToSize()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var sut = GivenTheSystemUnderTest(autoMock);

                var dto = DataTestHelper.GivenTheDefaultSizeDto();
                var model = sut.Map<SizeDto, Size>(dto);

                CheckAllProperties(dto, model);
            }
        }

        [TestMethod]
        public void MappingSizeToSizeDto()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var sut = GivenTheSystemUnderTest(autoMock);

                var model = DataTestHelper.GivenTheDefaultSize();
                var dto = sut.Map<Size, SizeDto>(model);

                CheckAllProperties(model, dto);
            }
        }

        [TestMethod]
        public void MappingSizeLogToSizeLogDto()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var sut = GivenTheSystemUnderTest(autoMock);

                var model = DataTestHelper.GivenTheDefaultSizeLog();
                var dto = sut.Map<SizeLog, SizeLogDto>(model);

                CheckAllProperties(model, dto);
            }
        }
    }
}
