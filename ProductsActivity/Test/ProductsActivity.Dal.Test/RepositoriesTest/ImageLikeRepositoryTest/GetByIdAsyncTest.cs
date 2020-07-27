// ReSharper disable ConvertToUsingDeclaration

using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using APIBaseTest;
using Autofac.Extras.Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductsActivity.Dal.Contexts;
using ProductsActivity.Dal.Models;
using ProductsActivity.Dal.Repositories.ImageLikeRepository;
using ProductsActivity.Helpers.Test;

namespace ProductsActivity.Dal.Test.RepositoriesTest.ImageLikeRepositoryTest
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class GetByIdAsyncTest : BaseRepositoryTest<ImageLikeRepository, ProductsActivityContext>
    {
        [TestMethod]
        public async Task GetByIdAsyncHappyPath()
        {
            using (var autoMock = AutoMock.GetStrict(RegisterBasicDependency))
            {
                var entities = DataTestHelper.GivenTheDefaultListImageLike();
                AndIAddRangeTableData(entities);

                var sut = GivenTheSystemUnderTest(autoMock);

                var entity = entities.First();
                var idRequest = entity.Id;
                var response = await sut.GetByIdAsync(idRequest);

                CheckAllProperties(entity, response);

                var tableData = AndIGetTableData<ImageLike>();
                CheckAllProperties(entities, tableData);
            }
        }
    }
}
