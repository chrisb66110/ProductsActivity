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
using ProductsActivity.Bll.Blls.ImageLikeBll;
using ProductsActivity.Common.Dtos.ImageLikeDtos;

namespace ProductsActivity.Api.Controllers
{
    [Authorize]
    [Route("[controller]")]
    public class ImageLikeController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IImageLikeBll _imageLikeBll;
        
        public ImageLikeController(
            ILogger<ImageLikeController> logger,
            IMapper mapper,
            IImageLikeBll imageLikeBll)
        :base(logger)
        {
            _mapper = mapper;
            _imageLikeBll = imageLikeBll;
        }

        [HttpGet("GetAll")]
        public async Task<ObjectResult> GetAllAsync()
        {
            ObjectResult response;

            try
            {
                var resultBll = await _imageLikeBll.GetAllAsync();

                if(resultBll.Count != 0)
                {
                    var resultResponse = _mapper.Map<List<ImageLikeDto>, List<ImageLikeResponse>>(resultBll);

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
                var resultBll = await _imageLikeBll.GetByIdAsync(id);

                if (resultBll != null)
                {
                    var resultResponse = _mapper.Map<ImageLikeDto, ImageLikeResponse>(resultBll);

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
        public async Task<ObjectResult> AddAsync([FromBody] ImageLikeRequest request)
        {
            ObjectResult response;

            try
            {
                if (ModelState.IsValid)
                {
                    var imageLikeDto = _mapper.Map<ImageLikeRequest, ImageLikeDto>(request);

                    var resultBll = await _imageLikeBll.AddAsync(imageLikeDto);

                    if(resultBll != null)
                    {
                        var resultResponse = _mapper.Map<ImageLikeDto, ImageLikeResponse>(resultBll);

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
        public async Task<ObjectResult> UpdateAsync([FromBody] ImageLikeRequest request)
        {
            ObjectResult response;

            try
            {
                if (ModelState.IsValid)
                {
                    var imageLikeDto = _mapper.Map<ImageLikeRequest, ImageLikeDto>(request);

                    var resultBll = await _imageLikeBll.UpdateAsync(imageLikeDto);

                    if (resultBll != null)
                    {
                        var resultResponse = _mapper.Map<ImageLikeDto, ImageLikeResponse>(resultBll);

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
        public async Task<ObjectResult> DeleteAsync([FromBody] ImageLikeRequest request)
        {
            ObjectResult response;

            try
            {
                if (ModelState.IsValid)
                {
                    var imageLikeDto = _mapper.Map<ImageLikeRequest, ImageLikeDto>(request);

                    var resultBll = await _imageLikeBll.DeleteAsync(imageLikeDto);

                    if (resultBll != null)
                    {
                        var resultResponse = _mapper.Map<ImageLikeDto, ImageLikeResponse>(resultBll);

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
                var resultBll = await _imageLikeBll.GetLogsAsync();

                if (resultBll.Count != 0)
                {
                    var resultResponse = _mapper.Map<List<ImageLikeLogDto>, List<ImageLikeLogResponse>>(resultBll);

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
