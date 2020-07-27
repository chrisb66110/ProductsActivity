using System.Collections.Generic;
using System.Threading.Tasks;
using APIBase.Common.Constants;
using Microsoft.EntityFrameworkCore;
using ProductsActivity.Common.Dtos.ImageLikeDtos;
using ProductsActivity.Dal.Repositories.ImageLikeRepository;
using Npgsql;

namespace ProductsActivity.Bll.Blls.ImageLikeBll
{
    public class ImageLikeBll : IImageLikeBll
    {
        private readonly IImageLikeRepository _imageLikeRepository;

        public ImageLikeBll(IImageLikeRepository imageLikeRepository)
        {
            _imageLikeRepository = imageLikeRepository;
        }

        public async Task<List<ImageLikeDto>> GetAllAsync()
        {
            var response = await _imageLikeRepository.GetAllAsync();

            return response;
        }

        public async Task<ImageLikeDto> GetByIdAsync(long id)
        {
            var response = await _imageLikeRepository.GetByIdAsync(id);

            return response;
        }

        public async Task<ImageLikeDto> AddAsync(ImageLikeDto imageLikeDto)
        {
            ImageLikeDto response;

            try
            {
                response = await _imageLikeRepository.AddAsync(imageLikeDto);
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

        public async Task<ImageLikeDto> UpdateAsync(ImageLikeDto imageLikeDto)
        {
            ImageLikeDto response;

            try
            {
                response = await _imageLikeRepository.UpdateAsync(imageLikeDto);
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

        public async Task<ImageLikeDto> DeleteAsync(ImageLikeDto imageLikeDto)
        {
            ImageLikeDto response;

            try
            {
                response = await _imageLikeRepository.DeleteAsync(imageLikeDto);
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

        public async Task<List<ImageLikeLogDto>> GetLogsAsync()
        {
            var response = await _imageLikeRepository.GetLogsAsync();

            return response;
        }
    }
}
