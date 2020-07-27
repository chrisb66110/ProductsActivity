using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIBase.Api.Controllers;
using APIBase.Common.Constants;
using APIBase.Common.Exceptions;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProductsActivity.Api.Requests;
using ProductsActivity.Api.Responses.ProductResponses;
using ProductsActivity.Bll.Blls.ProductBll;
using ProductsActivity.Common.Dtos.ProductDtos;

namespace ProductsActivity.Api.Controllers
{
    //[Authorize]
    [Route("[controller]")]
    public class ProductController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IProductBll _productBll;
        
        public ProductController(
            ILogger<ProductController> logger,
            IMapper mapper,
            IProductBll productBll)
        :base(logger)
        {
            _mapper = mapper;
            _productBll = productBll;
        }

        [HttpPost("GetProductsToGrid")]
        public async Task<ObjectResult> GetProductsToGridFromAsync([FromBody] ProductsToGridRequest request)
        {
            ObjectResult response;

            try
            {
                if (ModelState.IsValid)
                {
                    var resultBll = await _productBll.GetProductsToGridFromAsync(request.LastRead);

                    if (resultBll.Count != 0)
                    {
                        var resultResponse = _mapper.Map<List<ProductGirdDto>, List<ProductGirdResponse>>(resultBll);

                        response = CreateOkResponse(resultResponse);
                    }
                    else
                    {
                        response = CreateNoContentResponse();
                    }
                }
                else
                {
                    var errors = ModelState.Values.SelectMany(v => v.Errors)
                        .Select(e => e.ErrorMessage);

                    var messageErrors = string.Join("\n", errors);

                    response = CreateInvalidDataResponse(messageErrors);
                }
            }
            catch (Exception ex)
            {
                var errorMessage = $"{BaseConstants.ERROR_MESSAGE} Exception = {ex}";
                _logger.LogError(errorMessage);

                response = CreateInternalServerErrorResponse(BaseConstants.ERROR_MESSAGE);
            }

            return response;
        }

        [HttpGet("GetProductDetail/{id}")]
        public async Task<ObjectResult> GetProductDetailByIdAsync(long id)
        {
            ObjectResult response;

            try
            {
                var resultBll = await _productBll.GetProductDetailByIdAsync(id);

                if (resultBll != null)
                {
                    var resultResponse = _mapper.Map<ProductDto, ProductResponse>(resultBll);

                    response = CreateOkResponse(resultResponse);
                }
                else
                {
                    response = CreateNoContentResponse();
                }
            }
            catch (Exception ex)
            {
                var errorMessage = $"{BaseConstants.ERROR_MESSAGE} Exception = {ex}";
                _logger.LogError(errorMessage);

                response = CreateInternalServerErrorResponse(BaseConstants.ERROR_MESSAGE);
            }

            return response;
        }
        
        [HttpPut("UpdateProductViewedTime")]
        public async Task<ObjectResult> UpdateProductViewedTimeAsync([FromBody] ProductViewedUpdateTimeRequest request)
        {
            ObjectResult response;

            try
            {
                if (ModelState.IsValid)
                {
                    await _productBll.UpdateProductViewedTimeAsync(request.ProductViewedId);
                    
                    response = CreateOkResponse();
                }
                else
                {
                    var errors = ModelState.Values.SelectMany(v => v.Errors)
                        .Select(e => e.ErrorMessage);

                    var messageErrors = string.Join("\n", errors);

                    response = CreateInvalidDataResponse(messageErrors);
                }
            }
            catch (BaseException ex)
            {
                var errorMessage = $"{BaseConstants.ERROR_MESSAGE} {ex.Message}";
                _logger.LogError($"{errorMessage} StatusCode: {ex.StatusCode}.");

                response = new ObjectResult(errorMessage)
                {
                    StatusCode = (int)ex.StatusCode
                };
            }
            catch (Exception ex)
            {
                var errorMessage = $"{BaseConstants.ERROR_MESSAGE} Exception = {ex}";
                _logger.LogError(errorMessage);

                response = CreateInternalServerErrorResponse(BaseConstants.ERROR_MESSAGE);
            }

            return response;
        }
    }
}
