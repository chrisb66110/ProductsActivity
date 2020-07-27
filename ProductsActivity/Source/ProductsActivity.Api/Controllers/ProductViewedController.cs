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
using ProductsActivity.Bll.Blls.ProductViewedBll;
using ProductsActivity.Common.Dtos.ProductViewedDtos;

namespace ProductsActivity.Api.Controllers
{
    [Authorize]
    [Route("[controller]")]
    public class ProductViewedController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IProductViewedBll _productViewedBll;
        
        public ProductViewedController(
            ILogger<ProductViewedController> logger,
            IMapper mapper,
            IProductViewedBll productViewedBll)
        :base(logger)
        {
            _mapper = mapper;
            _productViewedBll = productViewedBll;
        }

        [HttpGet("GetAll")]
        public async Task<ObjectResult> GetAllAsync()
        {
            ObjectResult response;

            try
            {
                var resultBll = await _productViewedBll.GetAllAsync();

                if(resultBll.Count != 0)
                {
                    var resultResponse = _mapper.Map<List<ProductViewedDto>, List<ProductViewedResponse>>(resultBll);

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
                var resultBll = await _productViewedBll.GetByIdAsync(id);

                if (resultBll != null)
                {
                    var resultResponse = _mapper.Map<ProductViewedDto, ProductViewedResponse>(resultBll);

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
        public async Task<ObjectResult> AddAsync([FromBody] ProductViewedRequest request)
        {
            ObjectResult response;

            try
            {
                if (ModelState.IsValid)
                {
                    var productViewedDto = _mapper.Map<ProductViewedRequest, ProductViewedDto>(request);

                    var resultBll = await _productViewedBll.AddAsync(productViewedDto);

                    if(resultBll != null)
                    {
                        var resultResponse = _mapper.Map<ProductViewedDto, ProductViewedResponse>(resultBll);

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
        public async Task<ObjectResult> UpdateAsync([FromBody] ProductViewedRequest request)
        {
            ObjectResult response;

            try
            {
                if (ModelState.IsValid)
                {
                    var productViewedDto = _mapper.Map<ProductViewedRequest, ProductViewedDto>(request);

                    var resultBll = await _productViewedBll.UpdateAsync(productViewedDto);

                    if (resultBll != null)
                    {
                        var resultResponse = _mapper.Map<ProductViewedDto, ProductViewedResponse>(resultBll);

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
        public async Task<ObjectResult> DeleteAsync([FromBody] ProductViewedRequest request)
        {
            ObjectResult response;

            try
            {
                if (ModelState.IsValid)
                {
                    var productViewedDto = _mapper.Map<ProductViewedRequest, ProductViewedDto>(request);

                    var resultBll = await _productViewedBll.DeleteAsync(productViewedDto);

                    if (resultBll != null)
                    {
                        var resultResponse = _mapper.Map<ProductViewedDto, ProductViewedResponse>(resultBll);

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
                var resultBll = await _productViewedBll.GetLogsAsync();

                if (resultBll.Count != 0)
                {
                    var resultResponse = _mapper.Map<List<ProductViewedLogDto>, List<ProductViewedLogResponse>>(resultBll);

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
