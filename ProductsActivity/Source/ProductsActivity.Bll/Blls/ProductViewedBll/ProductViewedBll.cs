using System.Collections.Generic;
using System.Threading.Tasks;
using APIBase.Common.Constants;
using Microsoft.EntityFrameworkCore;
using ProductsActivity.Common.Dtos.ProductViewedDtos;
using ProductsActivity.Dal.Repositories.ProductViewedRepository;
using Npgsql;

namespace ProductsActivity.Bll.Blls.ProductViewedBll
{
    public class ProductViewedBll : IProductViewedBll
    {
        private readonly IProductViewedRepository _productViewedRepository;

        public ProductViewedBll(IProductViewedRepository productViewedRepository)
        {
            _productViewedRepository = productViewedRepository;
        }

        public async Task<List<ProductViewedDto>> GetAllAsync()
        {
            var response = await _productViewedRepository.GetAllAsync();

            return response;
        }

        public async Task<ProductViewedDto> GetByIdAsync(long id)
        {
            var response = await _productViewedRepository.GetByIdAsync(id);

            return response;
        }

        public async Task<ProductViewedDto> AddAsync(ProductViewedDto productViewedDto)
        {
            ProductViewedDto response;

            try
            {
                response = await _productViewedRepository.AddAsync(productViewedDto);
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

        public async Task<ProductViewedDto> UpdateAsync(ProductViewedDto productViewedDto)
        {
            ProductViewedDto response;

            try
            {
                response = await _productViewedRepository.UpdateAsync(productViewedDto);
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

        public async Task<ProductViewedDto> DeleteAsync(ProductViewedDto productViewedDto)
        {
            ProductViewedDto response;

            try
            {
                response = await _productViewedRepository.DeleteAsync(productViewedDto);
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

        public async Task<List<ProductViewedLogDto>> GetLogsAsync()
        {
            var response = await _productViewedRepository.GetLogsAsync();

            return response;
        }
    }
}
