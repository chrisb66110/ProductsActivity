using System.Collections.Generic;
using System.Threading.Tasks;
using ProductsActivity.Common.Dtos.ProductLikeDtos;

namespace ProductsActivity.Bll.Blls.ProductLikeBll
{
    public interface IProductLikeBll
    {
        Task<List<ProductLikeDto>> GetAllAsync();
        Task<ProductLikeDto> GetByIdAsync(long id);
        Task<ProductLikeDto> AddAsync(ProductLikeDto productLikeDto);
        Task<ProductLikeDto> UpdateAsync(ProductLikeDto productLikeDto);
        Task<ProductLikeDto> DeleteAsync(ProductLikeDto productLikeDto);
        Task<List<ProductLikeLogDto>> GetLogsAsync();
    }
}
