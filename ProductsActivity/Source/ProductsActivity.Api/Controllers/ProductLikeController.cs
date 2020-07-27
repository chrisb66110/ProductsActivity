using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIBase.Api.Controllers;
using APIBase.Common.Constants;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProductsActivity.Api.Requests;
using ProductsActivity.Api.Responses;
using ProductsActivity.Bll.Blls.ProductLikeBll;
using ProductsActivity.Common.Dtos.ProductLikeDtos;

namespace ProductsActivity.Api.Controllers
{
    [Authorize]
    [Route("[controller]")]
    public class ProductLikeController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IProductLikeBll _productLikeBll;
        
        public ProductLikeController(
            ILogger<ProductLikeController> logger,
            IMapper mapper,
            IProductLikeBll productLikeBll)
        :base(logger)
        {
            _mapper = mapper;
            _productLikeBll = productLikeBll;
        }

        [HttpGet("GetAll")]
        public async Task<ObjectResult> GetAllAsync()
        {
            ObjectResult response;

            try
            {
                var resultBll = await _productLikeBll.GetAllAsync();

                if(resultBll.Count != 0)
                {
                    var resultResponse = _mapper.Map<List<ProductLikeDto>, List<ProductLikeResponse>>(resultBll);

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

        [HttpGet("GetById/{id}")]
        public async Task<ObjectResult> GetByIdAsync(long id)
        {
            ObjectResult response;

            try
            {
                var resultBll = await _productLikeBll.GetByIdAsync(id);

                if (resultBll != null)
                {
                    var resultResponse = _mapper.Map<ProductLikeDto, ProductLikeResponse>(resultBll);

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

        [HttpPost("Add")]
        public async Task<ObjectResult> AddAsync([FromBody] ProductLikeRequest request)
        {
            ObjectResult response;

            try
            {
                if (ModelState.IsValid)
                {
                    var productLikeDto = _mapper.Map<ProductLikeRequest, ProductLikeDto>(request);

                    var resultBll = await _productLikeBll.AddAsync(productLikeDto);

                    if(resultBll != null)
                    {
                        var resultResponse = _mapper.Map<ProductLikeDto, ProductLikeResponse>(resultBll);

                        response = CreateOkResponse(resultResponse);
                    }
                    else
                    {
                        response = CreateConflictResponse(BaseConstants.ERROR_MESSAGE_DUPLICATE);
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

        [HttpPut("Update")]
        public async Task<ObjectResult> UpdateAsync([FromBody] ProductLikeRequest request)
        {
            ObjectResult response;

            try
            {
                if (ModelState.IsValid)
                {
                    var productLikeDto = _mapper.Map<ProductLikeRequest, ProductLikeDto>(request);

                    var resultBll = await _productLikeBll.UpdateAsync(productLikeDto);

                    if (resultBll != null)
                    {
                        var resultResponse = _mapper.Map<ProductLikeDto, ProductLikeResponse>(resultBll);

                        response = CreateOkResponse(resultResponse);
                    }
                    else
                    {
                        response = CreateConflictResponse(BaseConstants.ERROR_MESSAGE_ENTITY_DONT_EXIST);
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

        [HttpDelete("Delete")]
        public async Task<ObjectResult> DeleteAsync([FromBody] ProductLikeRequest request)
        {
            ObjectResult response;

            try
            {
                if (ModelState.IsValid)
                {
                    var productLikeDto = _mapper.Map<ProductLikeRequest, ProductLikeDto>(request);

                    var resultBll = await _productLikeBll.DeleteAsync(productLikeDto);

                    if (resultBll != null)
                    {
                        var resultResponse = _mapper.Map<ProductLikeDto, ProductLikeResponse>(resultBll);

                        response = CreateOkResponse(resultResponse);
                    }
                    else
                    {
                        response = CreateConflictResponse(BaseConstants.ERROR_MESSAGE_ENTITY_DONT_EXIST);
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

        [HttpGet("GetLogsAsync")]
        public async Task<ObjectResult> GetLogsAsync()
        {
            ObjectResult response;

            try
            {
                var resultBll = await _productLikeBll.GetLogsAsync();

                if (resultBll.Count != 0)
                {
                    var resultResponse = _mapper.Map<List<ProductLikeLogDto>, List<ProductLikeLogResponse>>(resultBll);

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
    }
}
