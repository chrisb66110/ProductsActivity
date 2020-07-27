using System.Collections.Generic;
using System.Threading.Tasks;
using ProductsActivity.Common.Dtos.ProductDtos;

namespace ProductsActivity.Dal.Repositories.ProductRepository
{
    public interface IProductRepository
    {
        Task<List<ProductGirdDto>> GetFromAsync(long from, int take);
        Task<ProductDto> GetByIdAsync(long id);
    }
}
