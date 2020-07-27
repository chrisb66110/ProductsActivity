using System.Collections.Generic;
using System.Threading.Tasks;
using ProductsActivity.Common.Dtos.ImageLikeDtos;

namespace ProductsActivity.Dal.Repositories.ImageLikeRepository
{
    public interface IImageLikeRepository
    {
        Task<List<ImageLikeDto>> GetAllAsync();
        Task<ImageLikeDto> GetByIdAsync(long id);
        Task<Dictionary<(long, long), long>> GetCountByProductIdAsync(List<long> productIds);
        Task<Dictionary<(long, long), List<ImageLikeDto>>> GetByProductIdAsync(List<long> productsIds);
        Task<ImageLikeDto> AddAsync(ImageLikeDto imageLikeDto);
        Task<ImageLikeDto> UpdateAsync(ImageLikeDto imageLikeDto);
        Task<ImageLikeDto> DeleteAsync(ImageLikeDto imageLikeDto);
        Task<List<ImageLikeLogDto>> GetLogsAsync();
    }
}
