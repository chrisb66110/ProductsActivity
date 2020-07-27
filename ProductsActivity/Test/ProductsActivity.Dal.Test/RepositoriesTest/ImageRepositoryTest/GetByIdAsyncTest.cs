// ReSharper disable ConvertToUsingDeclaration

using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using APIBaseTest;
using Autofac.Extras.Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductsActivity.Dal.Contexts;
using ProductsActivity.Dal.Models;
using ProductsActivity.Dal.Repositories.ImageRepository;
using ProductsActivity.Helpers.Test;

namespace ProductsActivity.Dal.Test.RepositoriesTest.ImageRepositoryTest
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class GetByIdAsyncTest : BaseRepositoryTest<ImageRepository, ProductsActivityContext>
    {
        [TestMethod]
        public async Task GetByIdAsyncHappyPath()
        {
            using (var autoMock = AutoMock.GetStrict(RegisterBasicDependency))
            {
                var entities = DataTestHelper.GivenTheDefaultListImage();
                AndIAddRangeTableData(entities);

                var sut = GivenTheSystemUnderTest(autoMock);

                var entity = entities.First();
                var idRequest = entity.Id;
                var response = await sut.GetByIdAsync(idRequest);

                CheckAllProperties(entity, response);

                var tableData = AndIGetTableData<Image>();
                CheckAllProperties(entities, tableData);
            }
        }
    }
}
