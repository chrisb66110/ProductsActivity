using System.Collections.Generic;
using System.Threading.Tasks;
using ProductsActivity.Common.Dtos.ProductViewedDtos;

namespace ProductsActivity.Bll.Blls.ProductViewedBll
{
    public interface IProductViewedBll
    {
        Task<List<ProductViewedDto>> GetAllAsync();
        Task<ProductViewedDto> GetByIdAsync(long id);
        Task<ProductViewedDto> AddAsync(ProductViewedDto productViewedDto);
        Task<ProductViewedDto> UpdateAsync(ProductViewedDto productViewedDto);
        Task<ProductViewedDto> DeleteAsync(ProductViewedDto productViewedDto);
        Task<List<ProductViewedLogDto>> GetLogsAsync();
    }
}
