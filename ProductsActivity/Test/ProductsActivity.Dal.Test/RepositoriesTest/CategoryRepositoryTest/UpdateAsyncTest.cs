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
using ProductsActivity.Dal.Repositories.CategoryRepository;
using ProductsActivity.Helpers.Test;

namespace ProductsActivity.Dal.Test.RepositoriesTest.CategoryRepositoryTest
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class UpdateAsyncTest : BaseRepositoryTest<CategoryRepository, ProductsActivityContext>
    {
        [TestMethod]
        public async Task UpdateAsyncHappyPath()
        {
            using (var autoMock = AutoMock.GetStrict(RegisterBasicDependency))
            {
                AndIMockDependencyMethod<ITokenFunctions, string>(autoMock, t => t.GetUsername(), "Username");

                var entities = DataTestHelper.GivenTheDefaultListCategory();
                AndIAddRangeTableData(entities);

                var updatedProperty = "Property3";
                var updatedDto = DataTestHelper.GivenTheDefaultListCategoryDto().First();
                updatedDto.Code = updatedProperty;

                entities.First(e => e.Id == updatedDto.Id).Code = updatedProperty;

                var sut = GivenTheSystemUnderTest(autoMock);
                var response = await sut.UpdateAsync(updatedDto);

                CheckAllProperties(updatedDto, response);

                var tableData = AndIGetTableData<Category>();
                CheckAllProperties(entities, tableData);
            }
        }
    }
}
