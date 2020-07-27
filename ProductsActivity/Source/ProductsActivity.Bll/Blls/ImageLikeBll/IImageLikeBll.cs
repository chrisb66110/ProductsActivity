using System.Collections.Generic;
using System.Threading.Tasks;
using ProductsActivity.Common.Dtos.ImageLikeDtos;

namespace ProductsActivity.Bll.Blls.ImageLikeBll
{
    public interface IImageLikeBll
    {
        Task<List<ImageLikeDto>> GetAllAsync();
        Task<ImageLikeDto> GetByIdAsync(long id);
        Task<ImageLikeDto> AddAsync(ImageLikeDto imageLikeDto);
        Task<ImageLikeDto> UpdateAsync(ImageLikeDto imageLikeDto);
        Task<ImageLikeDto> DeleteAsync(ImageLikeDto imageLikeDto);
        Task<List<ImageLikeLogDto>> GetLogsAsync();
    }
}
