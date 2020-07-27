using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIBase.Common.AuthFunctions;
using APIBase.Dal.Repositories;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProductsActivity.Common.Dtos.ImageLikeDtos;
using ProductsActivity.Dal.Contexts;
using ProductsActivity.Dal.Models;

namespace ProductsActivity.Dal.Repositories.ImageLikeRepository
{
    public class ImageLikeRepository : BaseLogRepository<ProductsActivityContext, ImageLike, long, ImageLikeLog>, IImageLikeRepository
    {
        private readonly IMapper _mapper;

        public ImageLikeRepository(
            DbContextOptions<ProductsActivityContext> options,
            IMapper mapper,
            ITokenFunctions tokenFunctions)
            : base(options, tokenFunctions)
        {
            _mapper = mapper;
        }

        public async Task<List<ImageLikeDto>> GetAllAsync()
        {
            var listImageLike = await _GetAllAsync();

            var response = _mapper.Map<List<ImageLike>, List<ImageLikeDto>>(listImageLike);

            return response;
        }

        public async Task<ImageLikeDto> GetByIdAsync(long id)
        {
            var imageLike = await _GetByIdAsync(id);

            var response = _mapper.Map<ImageLike, ImageLikeDto>(imageLike);

            return response;
        }

        public async Task<Dictionary<(long, long), long>> GetCountByProductIdAsync(List<long> productIds)
        {
            Dictionary<(long, long), long> response;

            using (var context = new ProductsActivityContext(_options))
            {
                response = await context.ImagesLikes.Where(i => productIds.Contains(i.ImageId))
                    .GroupBy(p => new { p.ProductId, p.ImageId }, (key, likes) => new
                    {
                        ProductId = key.ProductId,
                        ImageId = key.ImageId,
                        Likes = likes.LongCount()
                    })
                    .ToDictionaryAsync(x => (x.ProductId, x.ImageId), arg => arg.Likes);
            }

            return response;
        }

        public async Task<Dictionary<(long, long), List<ImageLikeDto>>> GetByProductIdAsync(List<long> productsIds)
        {
            Dictionary<(long, long), List<ImageLikeDto>> response;

            using (var context = new ProductsActivityContext(_options))
            {
                var result = await context.ImagesLikes
                    .Where(i => productsIds.Contains(i.ImageId))
                    .ToListAsync();

                response = result
                    .GroupBy(p => new { p.ProductId, p.ImageId }, (key, likes) => new
                    {
                        ProductId = key.ProductId,
                        ImageId = key.ImageId,
                        Likes = likes.ToList()
                    })
                    .ToDictionary(x => (x.ProductId, x.ImageId), arg => _mapper.Map<List<ImageLike>, List<ImageLikeDto>> (arg.Likes));
            }

            return response;
        }

        public async Task<ImageLikeDto> AddAsync(ImageLikeDto imageLikeDto)
        {
            var imageLike = _mapper.Map<ImageLikeDto, ImageLike>(imageLikeDto);

            var result = await _AddAsync(imageLike);

            var response = _mapper.Map<ImageLike, ImageLikeDto>(result);

            return response;
        }

        public async Task<ImageLikeDto> UpdateAsync(ImageLikeDto imageLikeDto)
        {
            var imageLike = _mapper.Map<ImageLikeDto, ImageLike>(imageLikeDto);

            var result = await _UpdateAsync(imageLike);

            var response = _mapper.Map<ImageLike, ImageLikeDto>(result);

            return response;
        }

        public async Task<ImageLikeDto> DeleteAsync(ImageLikeDto imageLikeDto)
        {
            var imageLike = _mapper.Map<ImageLikeDto, ImageLike>(imageLikeDto);

            var result = await _RemoveAsync(imageLike);

            var response = _mapper.Map<ImageLike, ImageLikeDto>(result);

            return response;
        }

        public async Task<List<ImageLikeLogDto>> GetLogsAsync()
        {
            var listImageLikeLog = await _GetLogsAsync();

            var response = _mapper.Map<List<ImageLikeLog>, List<ImageLikeLogDto>>(listImageLikeLog);

            return response;
        }
    }
}
