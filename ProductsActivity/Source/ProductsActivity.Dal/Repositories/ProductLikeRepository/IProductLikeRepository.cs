using System.Collections.Generic;
using System.Threading.Tasks;
using ProductsActivity.Common.Dtos.ProductLikeDtos;

namespace ProductsActivity.Dal.Repositories.ProductLikeRepository
{
    public interface IProductLikeRepository
    {
        Task<List<ProductLikeDto>> GetAllAsync();
        Task<ProductLikeDto> GetByIdAsync(long id);
        Task<List<ProductLikeDto>> GetByProductIdAsync(long productId);
        Task<Dictionary<long, long>> GetCountByProductIdAsync(List<long> productsId);
        Task<Dictionary<long, List<ProductLikeDto>>> GetByProductIdAsync(List<long> productsId);
        Task<ProductLikeDto> AddAsync(ProductLikeDto productLikeDto);
        Task<ProductLikeDto> UpdateAsync(ProductLikeDto productLikeDto);
        Task<ProductLikeDto> DeleteAsync(ProductLikeDto productLikeDto);
        Task<List<ProductLikeLogDto>> GetLogsAsync();
    }
}
