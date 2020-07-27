using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIBase.Common.AuthFunctions;
using APIBase.Dal.Repositories;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProductsActivity.Common.Dtos.ProductLikeDtos;
using ProductsActivity.Dal.Contexts;
using ProductsActivity.Dal.Models;

namespace ProductsActivity.Dal.Repositories.ProductLikeRepository
{
    public class ProductLikeRepository : BaseLogRepository<ProductsActivityContext, ProductLike, long, ProductLikeLog>, IProductLikeRepository
    {
        private readonly IMapper _mapper;

        public ProductLikeRepository(
            DbContextOptions<ProductsActivityContext> options,
            IMapper mapper,
            ITokenFunctions tokenFunctions)
            : base(options, tokenFunctions)
        {
            _mapper = mapper;
        }

        public async Task<List<ProductLikeDto>> GetAllAsync()
        {
            var listProductLike = await _GetAllAsync();

            var response = _mapper.Map<List<ProductLike>, List<ProductLikeDto>>(listProductLike);

            return response;
        }

        public async Task<ProductLikeDto> GetByIdAsync(long id)
        {
            var productLike = await _GetByIdAsync(id);

            var response = _mapper.Map<ProductLike, ProductLikeDto>(productLike);

            return response;
        }

        public async Task<List<ProductLikeDto>> GetByProductIdAsync(long productId)
        {
            List<ProductLike> productLikes;

            using (var context = new ProductsActivityContext(_options))
            {
                productLikes = await context.ProductsLikes.Where(p => p.ProductId == productId).ToListAsync();
            }

            var response = _mapper.Map<List<ProductLike>, List<ProductLikeDto>>(productLikes);

            return response;
        }

        public async Task<Dictionary<long, long>> GetCountByProductIdAsync(List<long> productsId)
        {
            Dictionary<long, long> response;

            using (var context = new ProductsActivityContext(_options))
            {
                response = await context.ProductsLikes
                    .Where(p => productsId.Contains(p.ProductId))
                    .GroupBy(p => p.ProductId, (productId, likes) => new
                    {
                        ProductId = productId,
                        Likes = likes.LongCount()
                    })
                    .ToDictionaryAsync(x => x.ProductId, arg => arg.Likes);
            }

            return response;
        }

        public async Task<Dictionary<long, List<ProductLikeDto>>> GetByProductIdAsync(List<long> productsId)
        {
            Dictionary<long, List<ProductLikeDto>> response;

            using (var context = new ProductsActivityContext(_options))
            {
                var result = await context.ProductsLikes
                    .Where(p => productsId.Contains(p.ProductId))
                    .ToListAsync();

                response = result
                    .GroupBy(r => r.ProductId, (key, group) => new
                    {
                        ProductId = key,
                        Likes = group.ToList()
                    })
                    .ToDictionary(p => p.ProductId, value => _mapper.Map<List<ProductLike>, List<ProductLikeDto>>(value.Likes));
            }

            return response;
        }

        public async Task<ProductLikeDto> AddAsync(ProductLikeDto productLikeDto)
        {
            var productLike = _mapper.Map<ProductLikeDto, ProductLike>(productLikeDto);

            var result = await _AddAsync(productLike);

            var response = _mapper.Map<ProductLike, ProductLikeDto>(result);

            return response;
        }

        public async Task<ProductLikeDto> UpdateAsync(ProductLikeDto productLikeDto)
        {
            var productLike = _mapper.Map<ProductLikeDto, ProductLike>(productLikeDto);

            var result = await _UpdateAsync(productLike);

            var response = _mapper.Map<ProductLike, ProductLikeDto>(result);

            return response;
        }

        public async Task<ProductLikeDto> DeleteAsync(ProductLikeDto productLikeDto)
        {
            var productLike = _mapper.Map<ProductLikeDto, ProductLike>(productLikeDto);

            var result = await _RemoveAsync(productLike);

            var response = _mapper.Map<ProductLike, ProductLikeDto>(result);

            return response;
        }

        public async Task<List<ProductLikeLogDto>> GetLogsAsync()
        {
            var listProductLikeLog = await _GetLogsAsync();

            var response = _mapper.Map<List<ProductLikeLog>, List<ProductLikeLogDto>>(listProductLikeLog);

            return response;
        }
    }
}
