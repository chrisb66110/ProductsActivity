using System.Collections.Generic;
using System.Threading.Tasks;
using APIBase.Common.Constants;
using Microsoft.EntityFrameworkCore;
using ProductsActivity.Common.Dtos.ProductLikeDtos;
using ProductsActivity.Dal.Repositories.ProductLikeRepository;
using Npgsql;

namespace ProductsActivity.Bll.Blls.ProductLikeBll
{
    public class ProductLikeBll : IProductLikeBll
    {
        private readonly IProductLikeRepository _productLikeRepository;

        public ProductLikeBll(IProductLikeRepository productLikeRepository)
        {
            _productLikeRepository = productLikeRepository;
        }

        public async Task<List<ProductLikeDto>> GetAllAsync()
        {
            var response = await _productLikeRepository.GetAllAsync();

            return response;
        }

        public async Task<ProductLikeDto> GetByIdAsync(long id)
        {
            var response = await _productLikeRepository.GetByIdAsync(id);

            return response;
        }

        public async Task<ProductLikeDto> AddAsync(ProductLikeDto productLikeDto)
        {
            ProductLikeDto response;

            try
            {
                response = await _productLikeRepository.AddAsync(productLikeDto);
            }
            catch (DbUpdateException ex) when (ex.InnerException is PostgresException inner)
            {
                if (inner.SqlState == BaseConstants.PG_DUPLICATE_ERROR)
                {
                    response = null;
                }
                else
                {
                    throw;
                }
            }

            return response;
        }

        public async Task<ProductLikeDto> UpdateAsync(ProductLikeDto productLikeDto)
        {
            ProductLikeDto response;

            try
            {
                response = await _productLikeRepository.UpdateAsync(productLikeDto);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (ex.Message.Contains(BaseConstants.PG_ERROR_DONT_AFFECT_ENTITY))
                {
                    response = null;
                }
                else
                {
                    throw;
                }
            }

            return response;
        }

        public async Task<ProductLikeDto> DeleteAsync(ProductLikeDto productLikeDto)
        {
            ProductLikeDto response;

            try
            {
                response = await _productLikeRepository.DeleteAsync(productLikeDto);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (ex.Message.Contains(BaseConstants.PG_ERROR_DONT_AFFECT_ENTITY))
                {
                    response = null;
                }
                else
                {
                    throw;
                }
            }

            return response;
        }

        public async Task<List<ProductLikeLogDto>> GetLogsAsync()
        {
            var response = await _productLikeRepository.GetLogsAsync();

            return response;
        }
    }
}
