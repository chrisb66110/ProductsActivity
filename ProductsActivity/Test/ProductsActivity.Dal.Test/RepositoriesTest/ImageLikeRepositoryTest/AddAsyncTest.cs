// ReSharper disable ConvertToUsingDeclaration

using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using APIBase.Common.AuthFunctions;
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
    public class AddAsyncTest : BaseRepositoryTest<ImageLikeRepository, ProductsActivityContext>
    {
        [TestMethod]
        public async Task AddAsyncHappyPath()
        {
            using (var autoMock = AutoMock.GetStrict(RegisterBasicDependency))
            {
                AndIMockDependencyMethod<ITokenFunctions, string>(autoMock, t => t.GetUsername(), "Username");

                var entities = DataTestHelper.GivenTheDefaultListImageLike();
                AndIAddRangeTableData(entities);

                var newId = 3;
                var newDto = DataTestHelper.GivenTheDefaultImageLikeDto();
                newDto.Id = newId;

                var newRecord = DataTestHelper.GivenTheDefaultImageLike();
                newRecord.Id = newId;
                entities.Add(newRecord);

                var sut = GivenTheSystemUnderTest(autoMock);
                var response = await sut.AddAsync(newDto);

                CheckAllProperties(newDto, response);

                var tableData = AndIGetTableData<ImageLike>();
                CheckAllProperties(entities, tableData);
            }
        }
    }
}
