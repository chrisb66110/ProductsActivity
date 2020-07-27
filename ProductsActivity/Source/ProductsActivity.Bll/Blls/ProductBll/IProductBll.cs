using System.Collections.Generic;
using System.Threading.Tasks;
using ProductsActivity.Common.Dtos.ProductDtos;

namespace ProductsActivity.Bll.Blls.ProductBll
{
    public interface IProductBll
    {
        Task<List<ProductGirdDto>> GetProductsToGridFromAsync(long lastRead);
        Task<ProductDto> GetProductDetailByIdAsync(long id);
        Task UpdateProductViewedTimeAsync(long id);
    }
}
