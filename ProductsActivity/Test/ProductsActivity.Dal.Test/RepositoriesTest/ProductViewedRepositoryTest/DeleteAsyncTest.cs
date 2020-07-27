// ReSharper disable ConvertToUsingDeclaration

using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using APIBase.Common.AuthFunctions;
using APIBaseTest;
using Autofac.Extras.Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductsActivity.Dal.Contexts;
using ProductsActivity.Dal.Models;
using ProductsActivity.Dal.Repositories.ProductViewedRepository;
using ProductsActivity.Helpers.Test;

namespace ProductsActivity.Dal.Test.RepositoriesTest.ProductViewedRepositoryTest
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class DeleteAsyncTest : BaseRepositoryTest<ProductViewedRepository, ProductsActivityContext>
    {
        [TestMethod]
        public async Task DeleteAsyncHappyPath()
        {
            using (var autoMock = AutoMock.GetStrict(RegisterBasicDependency))
            {
                AndIMockDependencyMethod<ITokenFunctions, string>(autoMock, t => t.GetUsername(), "Username");

                var entities = DataTestHelper.GivenTheDefaultListProductViewed();
                AndIAddRangeTableData(entities);

                var deletedDto = DataTestHelper.GivenTheDefaultListProductViewedDto().First();

                var deletedEntity = entities.First(e => e.Id == deletedDto.Id);
                entities.Remove(deletedEntity);

                var sut = GivenTheSystemUnderTest(autoMock);
                var response = await sut.DeleteAsync(deletedDto);

                CheckAllProperties(deletedDto, response);

                var tableData = AndIGetTableData<ProductViewed>();
                CheckAllProperties(entities, tableData);
            }
        }
    }
}
