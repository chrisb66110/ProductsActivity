using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using APIBase.Common.AuthFunctions;
using APIBase.Dal.Repositories;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProductsActivity.Common.Dtos.ProductDtos;
using ProductsActivity.Common.Dtos.ProductViewedDtos;
using ProductsActivity.Common.Exception;
using ProductsActivity.Dal.Contexts;
using ProductsActivity.Dal.Models;

namespace ProductsActivity.Dal.Repositories.ProductViewedRepository
{
    public class ProductViewedRepository : BaseLogRepository<ProductsActivityContext, ProductViewed, long, ProductViewedLog>, IProductViewedRepository
    {
        private readonly IMapper _mapper;

        public ProductViewedRepository(
            DbContextOptions<ProductsActivityContext> options,
            IMapper mapper,
            ITokenFunctions tokenFunctions)
            : base(options, tokenFunctions)
        {
            _mapper = mapper;
        }

        public async Task<List<ProductViewedDto>> GetAllAsync()
        {
            var listProductViewed = await _GetAllAsync();

            var response = _mapper.Map<List<ProductViewed>, List<ProductViewedDto>>(listProductViewed);

            return response;
        }

        public async Task<ProductViewedDto> GetByIdAsync(long id)
        {
            var productViewed = await _GetByIdAsync(id);

            var response = _mapper.Map<ProductViewed, ProductViewedDto>(productViewed);

            return response;
        }

        public async Task UpsertTimeViewedAsync(long id)
        {
            var productsViewed = await _GetByIdAsync(id);

            if (productsViewed.TimeViewed == TimeSpan.Zero)
            {
                productsViewed.TimeViewed = DateTime.UtcNow - productsViewed.DateTimeInitial;

                await _UpdateAsync(productsViewed, "UpsertTimeViewedAsync");
            }
            else
            {
                throw new ProductsActivityException("The time has already been updated.", HttpStatusCode.Conflict);
            }
        }

        public async Task<ProductViewedDto> AddAsync(ProductViewedDto productViewedDto)
        {
            var productViewed = _mapper.Map<ProductViewedDto, ProductViewed>(productViewedDto);

            var result = await _AddAsync(productViewed);

            var response = _mapper.Map<ProductViewed, ProductViewedDto>(result);

            return response;
        }

        public async Task<ProductViewedDto> UpdateAsync(ProductViewedDto productViewedDto)
        {
            var productViewed = _mapper.Map<ProductViewedDto, ProductViewed>(productViewedDto);

            var result = await _UpdateAsync(productViewed);

            var response = _mapper.Map<ProductViewed, ProductViewedDto>(result);

            return response;
        }

        public async Task<ProductViewedDto> DeleteAsync(ProductViewedDto productViewedDto)
        {
            var productViewed = _mapper.Map<ProductViewedDto, ProductViewed>(productViewedDto);

            var result = await _RemoveAsync(productViewed);

            var response = _mapper.Map<ProductViewed, ProductViewedDto>(result);

            return response;
        }

        public async Task<List<ProductViewedLogDto>> GetLogsAsync()
        {
            var listProductViewedLog = await _GetLogsAsync();

            var response = _mapper.Map<List<ProductViewedLog>, List<ProductViewedLogDto>>(listProductViewedLog);

            return response;
        }
    }
}
