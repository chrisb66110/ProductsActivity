using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIBase.Common.AuthFunctions;
using APIBase.Common.Constants;
using APIBase.Common.Exceptions;
using APIBase.Common.Extensions;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ProductsActivity.Common.Dtos.ImageLikeDtos;
using ProductsActivity.Common.Dtos.ProductDtos;
using ProductsActivity.Common.Dtos.ProductLikeDtos;
using ProductsActivity.Dal.Repositories.ProductRepository;
using ProductsActivity.Common.Dtos.ProductViewedDtos;
using ProductsActivity.Dal.Repositories.ImageLikeRepository;
using ProductsActivity.Dal.Repositories.ProductLikeRepository;
using ProductsActivity.Dal.Repositories.ProductViewedRepository;

namespace ProductsActivity.Bll.Blls.ProductBll
{
    public class ProductBll : IProductBll
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductViewedRepository _productViewedRepository;
        private readonly IProductLikeRepository _productLikeRepository;
        private readonly IImageLikeRepository _imageLikeRepository;
        private readonly ITokenFunctions _tokenFunctions;
        private readonly ILogger<ProductBll> _logger;

        public ProductBll(
            IProductRepository productRepository,
            IProductViewedRepository productViewedRepository,
            IProductLikeRepository productLikeRepository,
            IImageLikeRepository imageLikeRepository,
            ITokenFunctions tokenFunctions,
            ILogger<ProductBll> logger)
        {
            _productRepository = productRepository;
            _productViewedRepository = productViewedRepository;
            _productLikeRepository = productLikeRepository;
            _imageLikeRepository = imageLikeRepository;
            _tokenFunctions = tokenFunctions;
            _logger = logger;
        }

        public async Task<List<ProductGirdDto>> GetProductsToGridFromAsync(long lastRead)
        {
            var response = await _productRepository.GetFromAsync(lastRead, 9);

            var productsIds = response.Select(p => p.Id).ToList();

            var productsLikeCount = await _productLikeRepository.GetCountByProductIdAsync(productsIds);

            //Add Likes per product
            foreach (var product in response)
            {
                var existLikes = productsLikeCount.TryGetValue(product.Id, out var likes);
                product.Likes = existLikes? likes : 0;
            }

            return response;
        }

        public async Task<ProductDto> GetProductDetailByIdAsync(long id)
        {
            var response = await _productRepository.GetByIdAsync(id);

            var productsLikes = await _productLikeRepository.GetByProductIdAsync(new List<long> { id });

            var imagesLikes = await _imageLikeRepository.GetByProductIdAsync(new List<long> { id });

            if (response != null)
            {
                //Add Log Viewed
                var productViewed = new ProductViewedDto
                {
                    ProductId = response.Id,
                    ProductCode = response.Code,
                    Username = _tokenFunctions.GetUsername() ?? BaseConstants.AUTH_USER_NO_LOGIN,
                    DateTimeInitial = DateTime.UtcNow,
                    TimeViewed = TimeSpan.Zero
                };

                var productViewedResult = await _productViewedRepository.AddAsync(productViewed).ContinueWith(task =>
                {
                    if (task.IsFaulted)
                    {
                        var errorMessage = BaseConstants.ERROR_MESSAGE + " Exception Null";

                        if (task.Exception != null)
                        {
                            errorMessage = task.Exception.ToStringException();
                        }

                        _logger.LogError(errorMessage);

                        return null;
                    }

                    return task.Result;
                });

                response.ProductViewedId = productViewedResult.Id;

                //Add Product Likes
                var existProductLikes = productsLikes.TryGetValue(response.Id, out var likesProduct);
                response.Likes = existProductLikes ? likesProduct : new List<ProductLikeDto>();
                
                //Add Image Likes
                foreach (var image in response.Images)
                {
                    var existImageLikes = imagesLikes.TryGetValue((response.Id, image.Id), out var likesImage);
                    image.Likes = existImageLikes ? likesImage : new List<ImageLikeDto>();
                }
            }

            return response;
        }

        public async Task UpdateProductViewedTimeAsync(long id)
        {
            try
            {
                await _productViewedRepository.UpsertTimeViewedAsync(id);
            }
            catch (BaseException e)
            {
                var username = _tokenFunctions.GetUsername() ?? BaseConstants.AUTH_USER_NO_LOGIN;

                var errorMessage = "Error update time viewed.\n" +
                                        $"Username: {username}.\n" +
                                        $"id: {id}.\n" +
                                        $"DateTime: {DateTime.UtcNow}.\n" +
                                        $"ExceptionMessage: {e.Message}.";

                _logger.LogError(errorMessage);

                throw;
            }
        }
    }
}
