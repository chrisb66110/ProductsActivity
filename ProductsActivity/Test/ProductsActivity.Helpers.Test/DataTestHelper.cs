using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using ProductsActivity.Api.Requests;
using ProductsActivity.Api.Responses;
using ProductsActivity.Common.Dtos.ImageLikeDtos;
using ProductsActivity.Common.Dtos.ProductDtos;
using ProductsActivity.Common.Dtos.ProductLikeDtos;
using ProductsActivity.Common.Dtos.ProductViewedDtos;
using ProductsActivity.Dal.Models;
using Newtonsoft.Json;
using ProductsActivity.Api.Responses.ProductResponses;

namespace ProductsActivity.Helpers.Test
{
    [ExcludeFromCodeCoverage]
    public static class DataTestHelper
    {
        public static DateTime DateTime;

        static DataTestHelper()
        {
            DateTime = DateTime.UtcNow;
        }

        public static AgeGroupDto GivenTheDefaultAgeGroupDto()
        {
            var response = new AgeGroupDto()
            {
                Id = 1,
                Code = "Property",
                Name = "Property",
                Description = "Property",
                Property3 = "Property",
                Property4 = "Property",
                Property5 = "Property",
                Property6 = "Property",
                Property7 = "Property",
                Property8 = "Property",
                Property9 = "Property"
            };

            return response;
        }

        public static List<AgeGroupDto> GivenTheDefaultListAgeGroupDto()
        {
            var dto1 = GivenTheDefaultAgeGroupDto();
            dto1.Id = 1;

            var dto2 = GivenTheDefaultAgeGroupDto();
            dto2.Id = 2;

            var response = new List<AgeGroupDto>()
            {
                dto1,
                dto2
            };

            return response;
        }

        public static AgeGroupResponse GivenTheDefaultAgeGroupResponse()
        {
            var response = new AgeGroupResponse()
            {
                Id = 1,
                Code = "Property",
                Name = "Property",
                Description = "Property",
                Property3 = "Property",
                Property4 = "Property",
                Property5 = "Property",
                Property6 = "Property",
                Property7 = "Property",
                Property8 = "Property",
                Property9 = "Property"
            };

            return response;
        }

        public static List<AgeGroupResponse> GivenTheDefaultListAgeGroupResponse()
        {
            var response1 = GivenTheDefaultAgeGroupResponse();
            response1.Id = 1;

            var response2 = GivenTheDefaultAgeGroupResponse();
            response2.Id = 2;

            var response = new List<AgeGroupResponse>()
            {
                response1,
                response2
            };

            return response;
        }

        public static AgeGroupRequest GivenTheDefaultAgeGroupRequest()
        {
            var response = new AgeGroupRequest()
            {
                Id = 1,
                Property0 = "Property",
                Property1 = "Property",
                Property2 = "Property",
                Property3 = "Property",
                Property4 = "Property",
                Property5 = "Property",
                Property6 = "Property",
                Property7 = "Property",
                Property8 = "Property",
                Property9 = "Property"
            };

            return response;
        }

        public static AgeGroup GivenTheDefaultAgeGroup()
        {
            var response = new AgeGroup()
            {
                Id = 1,
                Code = "Property",
                Name = "Property",
                Description = "Property",
                Products = "Property",
                Property4 = "Property",
                Property5 = "Property",
                Property6 = "Property",
                Property7 = "Property",
                Property8 = "Property",
                Property9 = "Property"
            };

            return response;
        }

        public static List<AgeGroup> GivenTheDefaultListAgeGroup()
        {
            var model1 = GivenTheDefaultAgeGroup();
            model1.Id = 1;

            var model2 = GivenTheDefaultAgeGroup();
            model2.Id = 2;

            var response = new List<AgeGroup>()
            {
                model1,
                model2
            };

            return response;
        }

        public static AgeGroupLog GivenTheDefaultAgeGroupLog()
        {
            var response = new AgeGroupLog()
            {
                Id = 1,
                Username = "Username",
                DateTime = DateTime,
                PreviousValue = "PreviousValue",
                NewValue = "NewValue",
                PreviousEntity = default,
                NewEntity = default,
            };

            return response;
        }

        public static List<AgeGroupLog> GivenTheDefaultListAgeGroupLog()
        {
            var entity = GivenTheDefaultAgeGroup();

            var model1 = GivenTheDefaultAgeGroupLog();
            model1.Id = 1;
            model1.PreviousValue = "null";
            model1.NewValue = JsonConvert.SerializeObject(entity);

            var model2 = GivenTheDefaultAgeGroupLog();
            model2.Id = 2;
            model2.PreviousValue = JsonConvert.SerializeObject(entity);
            model2.NewValue = "null";

            var response = new List<AgeGroupLog>()
            {
                model1,
                model2
            };

            return response;
        }

        public static AgeGroupLogDto GivenTheDefaultAgeGroupLogDto()
        {
            var response = new AgeGroupLogDto()
            {
                Id = 1,
                Username = "Username",
                DateTime = DateTime,
                PreviousEntity = default,
                NewEntity = default,
            };

            return response;
        }

        public static List<AgeGroupLogDto> GivenTheDefaultListAgeGroupLogDto()
        {
            var dto = GivenTheDefaultAgeGroupDto();

            var model1 = GivenTheDefaultAgeGroupLogDto();
            model1.Id = 1;
            model1.PreviousEntity = null;
            model1.NewEntity = dto;

            var model2 = GivenTheDefaultAgeGroupLogDto();
            model2.Id = 2;
            model2.PreviousEntity = dto;
            model2.NewEntity = null;

            var response = new List<AgeGroupLogDto>()
            {
                model1,
                model2
            };

            return response;
        }
        public static CategoryDto GivenTheDefaultCategoryDto()
        {
            var response = new CategoryDto()
            {
                Id = 1,
                Code = "Property",
                Name = "Property",
                Description = "Property",
                Active = "Property",
                Property4 = "Property",
                Property5 = "Property",
                Property6 = "Property",
                Property7 = "Property",
                Property8 = "Property",
                Property9 = "Property"
            };

            return response;
        }

        public static List<CategoryDto> GivenTheDefaultListCategoryDto()
        {
            var dto1 = GivenTheDefaultCategoryDto();
            dto1.Id = 1;

            var dto2 = GivenTheDefaultCategoryDto();
            dto2.Id = 2;

            var response = new List<CategoryDto>()
            {
                dto1,
                dto2
            };

            return response;
        }

        public static CategoryResponse GivenTheDefaultCategoryResponse()
        {
            var response = new CategoryResponse()
            {
                Id = 1,
                Code = "Property",
                Name = "Property",
                Description = "Property",
                Active = "Property",
                Property4 = "Property",
                Property5 = "Property",
                Property6 = "Property",
                Property7 = "Property",
                Property8 = "Property",
                Property9 = "Property"
            };

            return response;
        }

        public static List<CategoryResponse> GivenTheDefaultListCategoryResponse()
        {
            var response1 = GivenTheDefaultCategoryResponse();
            response1.Id = 1;

            var response2 = GivenTheDefaultCategoryResponse();
            response2.Id = 2;

            var response = new List<CategoryResponse>()
            {
                response1,
                response2
            };

            return response;
        }

        public static CategoryRequest GivenTheDefaultCategoryRequest()
        {
            var response = new CategoryRequest()
            {
                Id = 1,
                Property0 = "Property",
                Property1 = "Property",
                Property2 = "Property",
                Property3 = "Property",
                Property4 = "Property",
                Property5 = "Property",
                Property6 = "Property",
                Property7 = "Property",
                Property8 = "Property",
                Property9 = "Property"
            };

            return response;
        }

        public static Category GivenTheDefaultCategory()
        {
            var response = new Category()
            {
                Id = 1,
                Code = "Property",
                Name = "Property",
                Description = "Property",
                Active = "Property",
                Products = "Property",
                Property5 = "Property",
                Property6 = "Property",
                Property7 = "Property",
                Property8 = "Property",
                Property9 = "Property"
            };

            return response;
        }

        public static List<Category> GivenTheDefaultListCategory()
        {
            var model1 = GivenTheDefaultCategory();
            model1.Id = 1;

            var model2 = GivenTheDefaultCategory();
            model2.Id = 2;

            var response = new List<Category>()
            {
                model1,
                model2
            };

            return response;
        }

        public static CategoryLog GivenTheDefaultCategoryLog()
        {
            var response = new CategoryLog()
            {
                Id = 1,
                Username = "Username",
                DateTime = DateTime,
                PreviousValue = "PreviousValue",
                NewValue = "NewValue",
                PreviousEntity = default,
                NewEntity = default,
            };

            return response;
        }

        public static List<CategoryLog> GivenTheDefaultListCategoryLog()
        {
            var entity = GivenTheDefaultCategory();

            var model1 = GivenTheDefaultCategoryLog();
            model1.Id = 1;
            model1.PreviousValue = "null";
            model1.NewValue = JsonConvert.SerializeObject(entity);

            var model2 = GivenTheDefaultCategoryLog();
            model2.Id = 2;
            model2.PreviousValue = JsonConvert.SerializeObject(entity);
            model2.NewValue = "null";

            var response = new List<CategoryLog>()
            {
                model1,
                model2
            };

            return response;
        }

        public static CategoryLogDto GivenTheDefaultCategoryLogDto()
        {
            var response = new CategoryLogDto()
            {
                Id = 1,
                Username = "Username",
                DateTime = DateTime,
                PreviousEntity = default,
                NewEntity = default,
            };

            return response;
        }

        public static List<CategoryLogDto> GivenTheDefaultListCategoryLogDto()
        {
            var dto = GivenTheDefaultCategoryDto();

            var model1 = GivenTheDefaultCategoryLogDto();
            model1.Id = 1;
            model1.PreviousEntity = null;
            model1.NewEntity = dto;

            var model2 = GivenTheDefaultCategoryLogDto();
            model2.Id = 2;
            model2.PreviousEntity = dto;
            model2.NewEntity = null;

            var response = new List<CategoryLogDto>()
            {
                model1,
                model2
            };

            return response;
        }
        public static ColorDto GivenTheDefaultColorDto()
        {
            var response = new ColorDto()
            {
                Id = 1,
                Name = "Property",
                RGB = "Property",
                Property2 = "Property",
                Property3 = "Property",
                Property4 = "Property",
                Property5 = "Property",
                Property6 = "Property",
                Property7 = "Property",
                Property8 = "Property",
                Property9 = "Property"
            };

            return response;
        }

        public static List<ColorDto> GivenTheDefaultListColorDto()
        {
            var dto1 = GivenTheDefaultColorDto();
            dto1.Id = 1;

            var dto2 = GivenTheDefaultColorDto();
            dto2.Id = 2;

            var response = new List<ColorDto>()
            {
                dto1,
                dto2
            };

            return response;
        }

        public static ColorResponse GivenTheDefaultColorResponse()
        {
            var response = new ColorResponse()
            {
                Id = 1,
                Name = "Property",
                RGB = "Property",
                Property2 = "Property",
                Property3 = "Property",
                Property4 = "Property",
                Property5 = "Property",
                Property6 = "Property",
                Property7 = "Property",
                Property8 = "Property",
                Property9 = "Property"
            };

            return response;
        }

        public static List<ColorResponse> GivenTheDefaultListColorResponse()
        {
            var response1 = GivenTheDefaultColorResponse();
            response1.Id = 1;

            var response2 = GivenTheDefaultColorResponse();
            response2.Id = 2;

            var response = new List<ColorResponse>()
            {
                response1,
                response2
            };

            return response;
        }

        public static ColorRequest GivenTheDefaultColorRequest()
        {
            var response = new ColorRequest()
            {
                Id = 1,
                Property0 = "Property",
                Property1 = "Property",
                Property2 = "Property",
                Property3 = "Property",
                Property4 = "Property",
                Property5 = "Property",
                Property6 = "Property",
                Property7 = "Property",
                Property8 = "Property",
                Property9 = "Property"
            };

            return response;
        }

        public static Color GivenTheDefaultColor()
        {
            var response = new Color()
            {
                Id = 1,
                Name = "Property",
                RGB = "Property",
                ProductsColors = "Property",
                Property3 = "Property",
                Property4 = "Property",
                Property5 = "Property",
                Property6 = "Property",
                Property7 = "Property",
                Property8 = "Property",
                Property9 = "Property"
            };

            return response;
        }

        public static List<Color> GivenTheDefaultListColor()
        {
            var model1 = GivenTheDefaultColor();
            model1.Id = 1;

            var model2 = GivenTheDefaultColor();
            model2.Id = 2;

            var response = new List<Color>()
            {
                model1,
                model2
            };

            return response;
        }

        public static ColorLog GivenTheDefaultColorLog()
        {
            var response = new ColorLog()
            {
                Id = 1,
                Username = "Username",
                DateTime = DateTime,
                PreviousValue = "PreviousValue",
                NewValue = "NewValue",
                PreviousEntity = default,
                NewEntity = default,
            };

            return response;
        }

        public static List<ColorLog> GivenTheDefaultListColorLog()
        {
            var entity = GivenTheDefaultColor();

            var model1 = GivenTheDefaultColorLog();
            model1.Id = 1;
            model1.PreviousValue = "null";
            model1.NewValue = JsonConvert.SerializeObject(entity);

            var model2 = GivenTheDefaultColorLog();
            model2.Id = 2;
            model2.PreviousValue = JsonConvert.SerializeObject(entity);
            model2.NewValue = "null";

            var response = new List<ColorLog>()
            {
                model1,
                model2
            };

            return response;
        }

        public static ColorLogDto GivenTheDefaultColorLogDto()
        {
            var response = new ColorLogDto()
            {
                Id = 1,
                Username = "Username",
                DateTime = DateTime,
                PreviousEntity = default,
                NewEntity = default,
            };

            return response;
        }

        public static List<ColorLogDto> GivenTheDefaultListColorLogDto()
        {
            var dto = GivenTheDefaultColorDto();

            var model1 = GivenTheDefaultColorLogDto();
            model1.Id = 1;
            model1.PreviousEntity = null;
            model1.NewEntity = dto;

            var model2 = GivenTheDefaultColorLogDto();
            model2.Id = 2;
            model2.PreviousEntity = dto;
            model2.NewEntity = null;

            var response = new List<ColorLogDto>()
            {
                model1,
                model2
            };

            return response;
        }
        public static GenderDto GivenTheDefaultGenderDto()
        {
            var response = new GenderDto()
            {
                Id = 1,
                Code = "Property",
                Name = "Property",
                Property2 = "Property",
                Property3 = "Property",
                Property4 = "Property",
                Property5 = "Property",
                Property6 = "Property",
                Property7 = "Property",
                Property8 = "Property",
                Property9 = "Property"
            };

            return response;
        }

        public static List<GenderDto> GivenTheDefaultListGenderDto()
        {
            var dto1 = GivenTheDefaultGenderDto();
            dto1.Id = 1;

            var dto2 = GivenTheDefaultGenderDto();
            dto2.Id = 2;

            var response = new List<GenderDto>()
            {
                dto1,
                dto2
            };

            return response;
        }

        public static GenderResponse GivenTheDefaultGenderResponse()
        {
            var response = new GenderResponse()
            {
                Id = 1,
                Code = "Property",
                Name = "Property",
                Property2 = "Property",
                Property3 = "Property",
                Property4 = "Property",
                Property5 = "Property",
                Property6 = "Property",
                Property7 = "Property",
                Property8 = "Property",
                Property9 = "Property"
            };

            return response;
        }

        public static List<GenderResponse> GivenTheDefaultListGenderResponse()
        {
            var response1 = GivenTheDefaultGenderResponse();
            response1.Id = 1;

            var response2 = GivenTheDefaultGenderResponse();
            response2.Id = 2;

            var response = new List<GenderResponse>()
            {
                response1,
                response2
            };

            return response;
        }

        public static GenderRequest GivenTheDefaultGenderRequest()
        {
            var response = new GenderRequest()
            {
                Id = 1,
                Property0 = "Property",
                Property1 = "Property",
                Property2 = "Property",
                Property3 = "Property",
                Property4 = "Property",
                Property5 = "Property",
                Property6 = "Property",
                Property7 = "Property",
                Property8 = "Property",
                Property9 = "Property"
            };

            return response;
        }

        public static Gender GivenTheDefaultGender()
        {
            var response = new Gender()
            {
                Id = 1,
                Code = "Property",
                Name = "Property",
                Products = "Property",
                Property3 = "Property",
                Property4 = "Property",
                Property5 = "Property",
                Property6 = "Property",
                Property7 = "Property",
                Property8 = "Property",
                Property9 = "Property"
            };

            return response;
        }

        public static List<Gender> GivenTheDefaultListGender()
        {
            var model1 = GivenTheDefaultGender();
            model1.Id = 1;

            var model2 = GivenTheDefaultGender();
            model2.Id = 2;

            var response = new List<Gender>()
            {
                model1,
                model2
            };

            return response;
        }

        public static GenderLog GivenTheDefaultGenderLog()
        {
            var response = new GenderLog()
            {
                Id = 1,
                Username = "Username",
                DateTime = DateTime,
                PreviousValue = "PreviousValue",
                NewValue = "NewValue",
                PreviousEntity = default,
                NewEntity = default,
            };

            return response;
        }

        public static List<GenderLog> GivenTheDefaultListGenderLog()
        {
            var entity = GivenTheDefaultGender();

            var model1 = GivenTheDefaultGenderLog();
            model1.Id = 1;
            model1.PreviousValue = "null";
            model1.NewValue = JsonConvert.SerializeObject(entity);

            var model2 = GivenTheDefaultGenderLog();
            model2.Id = 2;
            model2.PreviousValue = JsonConvert.SerializeObject(entity);
            model2.NewValue = "null";

            var response = new List<GenderLog>()
            {
                model1,
                model2
            };

            return response;
        }

        public static GenderLogDto GivenTheDefaultGenderLogDto()
        {
            var response = new GenderLogDto()
            {
                Id = 1,
                Username = "Username",
                DateTime = DateTime,
                PreviousEntity = default,
                NewEntity = default,
            };

            return response;
        }

        public static List<GenderLogDto> GivenTheDefaultListGenderLogDto()
        {
            var dto = GivenTheDefaultGenderDto();

            var model1 = GivenTheDefaultGenderLogDto();
            model1.Id = 1;
            model1.PreviousEntity = null;
            model1.NewEntity = dto;

            var model2 = GivenTheDefaultGenderLogDto();
            model2.Id = 2;
            model2.PreviousEntity = dto;
            model2.NewEntity = null;

            var response = new List<GenderLogDto>()
            {
                model1,
                model2
            };

            return response;
        }
        public static ImageDto GivenTheDefaultImageDto()
        {
            var response = new ImageDto()
            {
                Id = 1,
                ProductId = "Property",
                Url = "Property",
                Active = "Property",
                Property3 = "Property",
                Property4 = "Property",
                Property5 = "Property",
                Property6 = "Property",
                Property7 = "Property",
                Property8 = "Property",
                Property9 = "Property"
            };

            return response;
        }

        public static List<ImageDto> GivenTheDefaultListImageDto()
        {
            var dto1 = GivenTheDefaultImageDto();
            dto1.Id = 1;

            var dto2 = GivenTheDefaultImageDto();
            dto2.Id = 2;

            var response = new List<ImageDto>()
            {
                dto1,
                dto2
            };

            return response;
        }

        public static ImageResponse GivenTheDefaultImageResponse()
        {
            var response = new ImageResponse()
            {
                Id = 1,
                ProductId = "Property",
                Url = "Property",
                Active = "Property",
                Property3 = "Property",
                Property4 = "Property",
                Property5 = "Property",
                Property6 = "Property",
                Property7 = "Property",
                Property8 = "Property",
                Property9 = "Property"
            };

            return response;
        }

        public static List<ImageResponse> GivenTheDefaultListImageResponse()
        {
            var response1 = GivenTheDefaultImageResponse();
            response1.Id = 1;

            var response2 = GivenTheDefaultImageResponse();
            response2.Id = 2;

            var response = new List<ImageResponse>()
            {
                response1,
                response2
            };

            return response;
        }

        public static ImageRequest GivenTheDefaultImageRequest()
        {
            var response = new ImageRequest()
            {
                Id = 1,
                Property0 = "Property",
                Property1 = "Property",
                Property2 = "Property",
                Property3 = "Property",
                Property4 = "Property",
                Property5 = "Property",
                Property6 = "Property",
                Property7 = "Property",
                Property8 = "Property",
                Property9 = "Property"
            };

            return response;
        }

        public static Image GivenTheDefaultImage()
        {
            var response = new Image()
            {
                Id = 1,
                ProductId = "Property",
                Url = "Property",
                Active = "Property",
                Product = "Property",
                Property4 = "Property",
                Property5 = "Property",
                Property6 = "Property",
                Property7 = "Property",
                Property8 = "Property",
                Property9 = "Property"
            };

            return response;
        }

        public static List<Image> GivenTheDefaultListImage()
        {
            var model1 = GivenTheDefaultImage();
            model1.Id = 1;

            var model2 = GivenTheDefaultImage();
            model2.Id = 2;

            var response = new List<Image>()
            {
                model1,
                model2
            };

            return response;
        }

        public static ImageLog GivenTheDefaultImageLog()
        {
            var response = new ImageLog()
            {
                Id = 1,
                Username = "Username",
                DateTime = DateTime,
                PreviousValue = "PreviousValue",
                NewValue = "NewValue",
                PreviousEntity = default,
                NewEntity = default,
            };

            return response;
        }

        public static List<ImageLog> GivenTheDefaultListImageLog()
        {
            var entity = GivenTheDefaultImage();

            var model1 = GivenTheDefaultImageLog();
            model1.Id = 1;
            model1.PreviousValue = "null";
            model1.NewValue = JsonConvert.SerializeObject(entity);

            var model2 = GivenTheDefaultImageLog();
            model2.Id = 2;
            model2.PreviousValue = JsonConvert.SerializeObject(entity);
            model2.NewValue = "null";

            var response = new List<ImageLog>()
            {
                model1,
                model2
            };

            return response;
        }

        public static ImageLogDto GivenTheDefaultImageLogDto()
        {
            var response = new ImageLogDto()
            {
                Id = 1,
                Username = "Username",
                DateTime = DateTime,
                PreviousEntity = default,
                NewEntity = default,
            };

            return response;
        }

        public static List<ImageLogDto> GivenTheDefaultListImageLogDto()
        {
            var dto = GivenTheDefaultImageDto();

            var model1 = GivenTheDefaultImageLogDto();
            model1.Id = 1;
            model1.PreviousEntity = null;
            model1.NewEntity = dto;

            var model2 = GivenTheDefaultImageLogDto();
            model2.Id = 2;
            model2.PreviousEntity = dto;
            model2.NewEntity = null;

            var response = new List<ImageLogDto>()
            {
                model1,
                model2
            };

            return response;
        }
        public static ImageLikeDto GivenTheDefaultImageLikeDto()
        {
            var response = new ImageLikeDto()
            {
                Id = 1,
                ProductId = "Property",
                Url = "Property",
                Username = "Property",
                DateTime = "Property",
                ImageId = "Property",
                Property5 = "Property",
                Property6 = "Property",
                Property7 = "Property",
                Property8 = "Property",
                Property9 = "Property"
            };

            return response;
        }

        public static List<ImageLikeDto> GivenTheDefaultListImageLikeDto()
        {
            var dto1 = GivenTheDefaultImageLikeDto();
            dto1.Id = 1;

            var dto2 = GivenTheDefaultImageLikeDto();
            dto2.Id = 2;

            var response = new List<ImageLikeDto>()
            {
                dto1,
                dto2
            };

            return response;
        }

        public static ImageLikeResponse GivenTheDefaultImageLikeResponse()
        {
            var response = new ImageLikeResponse()
            {
                Id = 1,
                ProductId = "Property",
                Url = "Property",
                Username = "Property",
                DateTime = "Property",
                ImageId = "Property",
                Property5 = "Property",
                Property6 = "Property",
                Property7 = "Property",
                Property8 = "Property",
                Property9 = "Property"
            };

            return response;
        }

        public static List<ImageLikeResponse> GivenTheDefaultListImageLikeResponse()
        {
            var response1 = GivenTheDefaultImageLikeResponse();
            response1.Id = 1;

            var response2 = GivenTheDefaultImageLikeResponse();
            response2.Id = 2;

            var response = new List<ImageLikeResponse>()
            {
                response1,
                response2
            };

            return response;
        }

        public static ImageLikeRequest GivenTheDefaultImageLikeRequest()
        {
            var response = new ImageLikeRequest()
            {
                Id = 1,
                ProductId = "Property",
                Url = "Property",
                Username = "Property",
                DateTime = "Property",
                ImageId = "Property",
                Property5 = "Property",
                Property6 = "Property",
                Property7 = "Property",
                Property8 = "Property",
                Property9 = "Property"
            };

            return response;
        }

        public static ImageLike GivenTheDefaultImageLike()
        {
            var response = new ImageLike()
            {
                Id = 1,
                ProductId = "Property",
                Url = "Property",
                Username = "Property",
                DateTime = "Property",
                ImageId = "Property",
                Property5 = "Property",
                Property6 = "Property",
                Property7 = "Property",
                Property8 = "Property",
                Property9 = "Property"
            };

            return response;
        }

        public static List<ImageLike> GivenTheDefaultListImageLike()
        {
            var model1 = GivenTheDefaultImageLike();
            model1.Id = 1;

            var model2 = GivenTheDefaultImageLike();
            model2.Id = 2;

            var response = new List<ImageLike>()
            {
                model1,
                model2
            };

            return response;
        }

        public static ImageLikeLog GivenTheDefaultImageLikeLog()
        {
            var response = new ImageLikeLog()
            {
                Id = 1,
                Username = "Username",
                DateTime = DateTime,
                PreviousValue = "PreviousValue",
                NewValue = "NewValue",
                PreviousEntity = default,
                NewEntity = default,
            };

            return response;
        }

        public static List<ImageLikeLog> GivenTheDefaultListImageLikeLog()
        {
            var entity = GivenTheDefaultImageLike();

            var model1 = GivenTheDefaultImageLikeLog();
            model1.Id = 1;
            model1.PreviousValue = "null";
            model1.NewValue = JsonConvert.SerializeObject(entity);

            var model2 = GivenTheDefaultImageLikeLog();
            model2.Id = 2;
            model2.PreviousValue = JsonConvert.SerializeObject(entity);
            model2.NewValue = "null";

            var response = new List<ImageLikeLog>()
            {
                model1,
                model2
            };

            return response;
        }

        public static ImageLikeLogDto GivenTheDefaultImageLikeLogDto()
        {
            var response = new ImageLikeLogDto()
            {
                Id = 1,
                Username = "Username",
                DateTime = DateTime,
                PreviousEntity = default,
                NewEntity = default,
            };

            return response;
        }

        public static List<ImageLikeLogDto> GivenTheDefaultListImageLikeLogDto()
        {
            var dto = GivenTheDefaultImageLikeDto();

            var model1 = GivenTheDefaultImageLikeLogDto();
            model1.Id = 1;
            model1.PreviousEntity = null;
            model1.NewEntity = dto;

            var model2 = GivenTheDefaultImageLikeLogDto();
            model2.Id = 2;
            model2.PreviousEntity = dto;
            model2.NewEntity = null;

            var response = new List<ImageLikeLogDto>()
            {
                model1,
                model2
            };

            return response;
        }
        public static ProductDto GivenTheDefaultProductDto()
        {
            var response = new ProductDto()
            {
                Id = 1,
                Title = "Property",
                CategoryId = "Property",
                Code = "Property",
                Price = "Property",
                PriceOld = "Property",
                IncludeShipping = "Property",
                Description = "Property",
                MainImage = "Property",
                Active = "Property",
                AgeGroupId = "Property"
            };

            return response;
        }

        public static List<ProductDto> GivenTheDefaultListProductDto()
        {
            var dto1 = GivenTheDefaultProductDto();
            dto1.Id = 1;

            var dto2 = GivenTheDefaultProductDto();
            dto2.Id = 2;

            var response = new List<ProductDto>()
            {
                dto1,
                dto2
            };

            return response;
        }

        public static ProductResponse GivenTheDefaultProductResponse()
        {
            var response = new ProductResponse()
            {
                Id = 1,
                Title = "Property",
                CategoryId = "Property",
                Code = "Property",
                Price = "Property",
                PriceOld = "Property",
                IncludeShipping = "Property",
                Description = "Property",
                MainImage = "Property",
                Active = "Property",
                AgeGroupId = "Property"
            };

            return response;
        }

        public static List<ProductResponse> GivenTheDefaultListProductResponse()
        {
            var response1 = GivenTheDefaultProductResponse();
            response1.Id = 1;

            var response2 = GivenTheDefaultProductResponse();
            response2.Id = 2;

            var response = new List<ProductResponse>()
            {
                response1,
                response2
            };

            return response;
        }

        public static ProductRequest GivenTheDefaultProductRequest()
        {
            var response = new ProductRequest()
            {
                Id = 1,
                Property0 = "Property",
                Property1 = "Property",
                Property2 = "Property",
                Property3 = "Property",
                Property4 = "Property",
                Property5 = "Property",
                Property6 = "Property",
                Property7 = "Property",
                Property8 = "Property",
                Property9 = "Property"
            };

            return response;
        }

        public static Product GivenTheDefaultProduct()
        {
            var response = new Product()
            {
                Id = 1,
                Title = "Property",
                CategoryId = "Property",
                Code = "Property",
                Price = "Property",
                PriceOld = "Property",
                IncludeShipping = "Property",
                Description = "Property",
                MainImage = "Property",
                Active = "Property",
                Property9 = "Property"
            };

            return response;
        }

        public static List<Product> GivenTheDefaultListProduct()
        {
            var model1 = GivenTheDefaultProduct();
            model1.Id = 1;

            var model2 = GivenTheDefaultProduct();
            model2.Id = 2;

            var response = new List<Product>()
            {
                model1,
                model2
            };

            return response;
        }

        public static ProductLog GivenTheDefaultProductLog()
        {
            var response = new ProductLog()
            {
                Id = 1,
                Username = "Username",
                DateTime = DateTime,
                PreviousValue = "PreviousValue",
                NewValue = "NewValue",
                PreviousEntity = default,
                NewEntity = default,
            };

            return response;
        }

        public static List<ProductLog> GivenTheDefaultListProductLog()
        {
            var entity = GivenTheDefaultProduct();

            var model1 = GivenTheDefaultProductLog();
            model1.Id = 1;
            model1.PreviousValue = "null";
            model1.NewValue = JsonConvert.SerializeObject(entity);

            var model2 = GivenTheDefaultProductLog();
            model2.Id = 2;
            model2.PreviousValue = JsonConvert.SerializeObject(entity);
            model2.NewValue = "null";

            var response = new List<ProductLog>()
            {
                model1,
                model2
            };

            return response;
        }

        public static ProductLogDto GivenTheDefaultProductLogDto()
        {
            var response = new ProductLogDto()
            {
                Id = 1,
                Username = "Username",
                DateTime = DateTime,
                PreviousEntity = default,
                NewEntity = default,
            };

            return response;
        }

        public static List<ProductLogDto> GivenTheDefaultListProductLogDto()
        {
            var dto = GivenTheDefaultProductDto();

            var model1 = GivenTheDefaultProductLogDto();
            model1.Id = 1;
            model1.PreviousEntity = null;
            model1.NewEntity = dto;

            var model2 = GivenTheDefaultProductLogDto();
            model2.Id = 2;
            model2.PreviousEntity = dto;
            model2.NewEntity = null;

            var response = new List<ProductLogDto>()
            {
                model1,
                model2
            };

            return response;
        }
        public static ProductColorDto GivenTheDefaultProductColorDto()
        {
            var response = new ProductColorDto()
            {
                Id = 1,
                Title = "Property",
                CategoryId = "Property",
                Code = "Property",
                Price = "Property",
                PriceOld = "Property",
                IncludeShipping = "Property",
                Description = "Property",
                MainImage = "Property",
                Active = "Property",
                GenderId = "Property"
            };

            return response;
        }

        public static List<ProductColorDto> GivenTheDefaultListProductColorDto()
        {
            var dto1 = GivenTheDefaultProductColorDto();
            dto1.Id = 1;

            var dto2 = GivenTheDefaultProductColorDto();
            dto2.Id = 2;

            var response = new List<ProductColorDto>()
            {
                dto1,
                dto2
            };

            return response;
        }

        public static ProductColorResponse GivenTheDefaultProductColorResponse()
        {
            var response = new ProductColorResponse()
            {
                Id = 1,
                ProductId = "Property",
                ColorId = "Property",
                Property2 = "Property",
                Property3 = "Property",
                Property4 = "Property",
                Property5 = "Property",
                Property6 = "Property",
                Property7 = "Property",
                Property8 = "Property",
                Property9 = "Property"
            };

            return response;
        }

        public static List<ProductColorResponse> GivenTheDefaultListProductColorResponse()
        {
            var response1 = GivenTheDefaultProductColorResponse();
            response1.Id = 1;

            var response2 = GivenTheDefaultProductColorResponse();
            response2.Id = 2;

            var response = new List<ProductColorResponse>()
            {
                response1,
                response2
            };

            return response;
        }

        public static ProductColorRequest GivenTheDefaultProductColorRequest()
        {
            var response = new ProductColorRequest()
            {
                Id = 1,
                Property0 = "Property",
                Property1 = "Property",
                Property2 = "Property",
                Property3 = "Property",
                Property4 = "Property",
                Property5 = "Property",
                Property6 = "Property",
                Property7 = "Property",
                Property8 = "Property",
                Property9 = "Property"
            };

            return response;
        }

        public static ProductColor GivenTheDefaultProductColor()
        {
            var response = new ProductColor()
            {
                Id = 1,
                ProductId = "Property",
                RGB = "Property",
                Property2 = "Property",
                Property3 = "Property",
                Property4 = "Property",
                Property5 = "Property",
                Property6 = "Property",
                Property7 = "Property",
                Property8 = "Property",
                Property9 = "Property"
            };

            return response;
        }

        public static List<ProductColor> GivenTheDefaultListProductColor()
        {
            var model1 = GivenTheDefaultProductColor();
            model1.Id = 1;

            var model2 = GivenTheDefaultProductColor();
            model2.Id = 2;

            var response = new List<ProductColor>()
            {
                model1,
                model2
            };

            return response;
        }

        public static ProductColorLog GivenTheDefaultProductColorLog()
        {
            var response = new ProductColorLog()
            {
                Id = 1,
                Username = "Username",
                DateTime = DateTime,
                PreviousValue = "PreviousValue",
                NewValue = "NewValue",
                PreviousEntity = default,
                NewEntity = default,
            };

            return response;
        }

        public static List<ProductColorLog> GivenTheDefaultListProductColorLog()
        {
            var entity = GivenTheDefaultProductColor();

            var model1 = GivenTheDefaultProductColorLog();
            model1.Id = 1;
            model1.PreviousValue = "null";
            model1.NewValue = JsonConvert.SerializeObject(entity);

            var model2 = GivenTheDefaultProductColorLog();
            model2.Id = 2;
            model2.PreviousValue = JsonConvert.SerializeObject(entity);
            model2.NewValue = "null";

            var response = new List<ProductColorLog>()
            {
                model1,
                model2
            };

            return response;
        }

        public static ProductColorLogDto GivenTheDefaultProductColorLogDto()
        {
            var response = new ProductColorLogDto()
            {
                Id = 1,
                Username = "Username",
                DateTime = DateTime,
                PreviousEntity = default,
                NewEntity = default,
            };

            return response;
        }

        public static List<ProductColorLogDto> GivenTheDefaultListProductColorLogDto()
        {
            var dto = GivenTheDefaultProductColorDto();

            var model1 = GivenTheDefaultProductColorLogDto();
            model1.Id = 1;
            model1.PreviousEntity = null;
            model1.NewEntity = dto;

            var model2 = GivenTheDefaultProductColorLogDto();
            model2.Id = 2;
            model2.PreviousEntity = dto;
            model2.NewEntity = null;

            var response = new List<ProductColorLogDto>()
            {
                model1,
                model2
            };

            return response;
        }
        public static ProductLikeDto GivenTheDefaultProductLikeDto()
        {
            var response = new ProductLikeDto()
            {
                Id = 1,
                ProductId = "Property",
                ProductCode = "Property",
                Username = "Property",
                DateTime = "Property",
                Property4 = "Property",
                Property5 = "Property",
                Property6 = "Property",
                Property7 = "Property",
                Property8 = "Property",
                Property9 = "Property"
            };

            return response;
        }

        public static List<ProductLikeDto> GivenTheDefaultListProductLikeDto()
        {
            var dto1 = GivenTheDefaultProductLikeDto();
            dto1.Id = 1;

            var dto2 = GivenTheDefaultProductLikeDto();
            dto2.Id = 2;

            var response = new List<ProductLikeDto>()
            {
                dto1,
                dto2
            };

            return response;
        }

        public static ProductLikeResponse GivenTheDefaultProductLikeResponse()
        {
            var response = new ProductLikeResponse()
            {
                Id = 1,
                ProductId = "Property",
                ProductCode = "Property",
                Username = "Property",
                DateTime = "Property",
                Property4 = "Property",
                Property5 = "Property",
                Property6 = "Property",
                Property7 = "Property",
                Property8 = "Property",
                Property9 = "Property"
            };

            return response;
        }

        public static List<ProductLikeResponse> GivenTheDefaultListProductLikeResponse()
        {
            var response1 = GivenTheDefaultProductLikeResponse();
            response1.Id = 1;

            var response2 = GivenTheDefaultProductLikeResponse();
            response2.Id = 2;

            var response = new List<ProductLikeResponse>()
            {
                response1,
                response2
            };

            return response;
        }

        public static ProductLikeRequest GivenTheDefaultProductLikeRequest()
        {
            var response = new ProductLikeRequest()
            {
                Id = 1,
                ProductId = "Property",
                ProductCode = "Property",
                Username = "Property",
                DateTime = "Property",
                Property4 = "Property",
                Property5 = "Property",
                Property6 = "Property",
                Property7 = "Property",
                Property8 = "Property",
                Property9 = "Property"
            };

            return response;
        }

        public static ProductLike GivenTheDefaultProductLike()
        {
            var response = new ProductLike()
            {
                Id = 1,
                ProductId = "Property",
                ProductCode = "Property",
                Username = "Property",
                DateTime = "Property",
                Property4 = "Property",
                Property5 = "Property",
                Property6 = "Property",
                Property7 = "Property",
                Property8 = "Property",
                Property9 = "Property"
            };

            return response;
        }

        public static List<ProductLike> GivenTheDefaultListProductLike()
        {
            var model1 = GivenTheDefaultProductLike();
            model1.Id = 1;

            var model2 = GivenTheDefaultProductLike();
            model2.Id = 2;

            var response = new List<ProductLike>()
            {
                model1,
                model2
            };

            return response;
        }

        public static ProductLikeLog GivenTheDefaultProductLikeLog()
        {
            var response = new ProductLikeLog()
            {
                Id = 1,
                Username = "Username",
                DateTime = DateTime,
                PreviousValue = "PreviousValue",
                NewValue = "NewValue",
                PreviousEntity = default,
                NewEntity = default,
            };

            return response;
        }

        public static List<ProductLikeLog> GivenTheDefaultListProductLikeLog()
        {
            var entity = GivenTheDefaultProductLike();

            var model1 = GivenTheDefaultProductLikeLog();
            model1.Id = 1;
            model1.PreviousValue = "null";
            model1.NewValue = JsonConvert.SerializeObject(entity);

            var model2 = GivenTheDefaultProductLikeLog();
            model2.Id = 2;
            model2.PreviousValue = JsonConvert.SerializeObject(entity);
            model2.NewValue = "null";

            var response = new List<ProductLikeLog>()
            {
                model1,
                model2
            };

            return response;
        }

        public static ProductLikeLogDto GivenTheDefaultProductLikeLogDto()
        {
            var response = new ProductLikeLogDto()
            {
                Id = 1,
                Username = "Username",
                DateTime = DateTime,
                PreviousEntity = default,
                NewEntity = default,
            };

            return response;
        }

        public static List<ProductLikeLogDto> GivenTheDefaultListProductLikeLogDto()
        {
            var dto = GivenTheDefaultProductLikeDto();

            var model1 = GivenTheDefaultProductLikeLogDto();
            model1.Id = 1;
            model1.PreviousEntity = null;
            model1.NewEntity = dto;

            var model2 = GivenTheDefaultProductLikeLogDto();
            model2.Id = 2;
            model2.PreviousEntity = dto;
            model2.NewEntity = null;

            var response = new List<ProductLikeLogDto>()
            {
                model1,
                model2
            };

            return response;
        }
        public static ProductSizeDto GivenTheDefaultProductSizeDto()
        {
            var response = new ProductSizeDto()
            {
                Id = 1,
                ProductId = "Property",
                SizeId = "Property",
                QuantityAvailable = "Property",
                Property3 = "Property",
                Property4 = "Property",
                Property5 = "Property",
                Property6 = "Property",
                Property7 = "Property",
                Property8 = "Property",
                Property9 = "Property"
            };

            return response;
        }

        public static List<ProductSizeDto> GivenTheDefaultListProductSizeDto()
        {
            var dto1 = GivenTheDefaultProductSizeDto();
            dto1.Id = 1;

            var dto2 = GivenTheDefaultProductSizeDto();
            dto2.Id = 2;

            var response = new List<ProductSizeDto>()
            {
                dto1,
                dto2
            };

            return response;
        }

        public static ProductSizeResponse GivenTheDefaultProductSizeResponse()
        {
            var response = new ProductSizeResponse()
            {
                Id = 1,
                ProductId = "Property",
                SizeId = "Property",
                QuantityAvailable = "Property",
                Property3 = "Property",
                Property4 = "Property",
                Property5 = "Property",
                Property6 = "Property",
                Property7 = "Property",
                Property8 = "Property",
                Property9 = "Property"
            };

            return response;
        }

        public static List<ProductSizeResponse> GivenTheDefaultListProductSizeResponse()
        {
            var response1 = GivenTheDefaultProductSizeResponse();
            response1.Id = 1;

            var response2 = GivenTheDefaultProductSizeResponse();
            response2.Id = 2;

            var response = new List<ProductSizeResponse>()
            {
                response1,
                response2
            };

            return response;
        }

        public static ProductSizeRequest GivenTheDefaultProductSizeRequest()
        {
            var response = new ProductSizeRequest()
            {
                Id = 1,
                Property0 = "Property",
                Property1 = "Property",
                Property2 = "Property",
                Property3 = "Property",
                Property4 = "Property",
                Property5 = "Property",
                Property6 = "Property",
                Property7 = "Property",
                Property8 = "Property",
                Property9 = "Property"
            };

            return response;
        }

        public static ProductSize GivenTheDefaultProductSize()
        {
            var response = new ProductSize()
            {
                Id = 1,
                ProductId = "Property",
                SizeId = "Property",
                QuantityAvailable = "Property",
                Property3 = "Property",
                Property4 = "Property",
                Property5 = "Property",
                Property6 = "Property",
                Property7 = "Property",
                Property8 = "Property",
                Property9 = "Property"
            };

            return response;
        }

        public static List<ProductSize> GivenTheDefaultListProductSize()
        {
            var model1 = GivenTheDefaultProductSize();
            model1.Id = 1;

            var model2 = GivenTheDefaultProductSize();
            model2.Id = 2;

            var response = new List<ProductSize>()
            {
                model1,
                model2
            };

            return response;
        }

        public static ProductSizeLog GivenTheDefaultProductSizeLog()
        {
            var response = new ProductSizeLog()
            {
                Id = 1,
                Username = "Username",
                DateTime = DateTime,
                PreviousValue = "PreviousValue",
                NewValue = "NewValue",
                PreviousEntity = default,
                NewEntity = default,
            };

            return response;
        }

        public static List<ProductSizeLog> GivenTheDefaultListProductSizeLog()
        {
            var entity = GivenTheDefaultProductSize();

            var model1 = GivenTheDefaultProductSizeLog();
            model1.Id = 1;
            model1.PreviousValue = "null";
            model1.NewValue = JsonConvert.SerializeObject(entity);

            var model2 = GivenTheDefaultProductSizeLog();
            model2.Id = 2;
            model2.PreviousValue = JsonConvert.SerializeObject(entity);
            model2.NewValue = "null";

            var response = new List<ProductSizeLog>()
            {
                model1,
                model2
            };

            return response;
        }

        public static ProductSizeLogDto GivenTheDefaultProductSizeLogDto()
        {
            var response = new ProductSizeLogDto()
            {
                Id = 1,
                Username = "Username",
                DateTime = DateTime,
                PreviousEntity = default,
                NewEntity = default,
            };

            return response;
        }

        public static List<ProductSizeLogDto> GivenTheDefaultListProductSizeLogDto()
        {
            var dto = GivenTheDefaultProductSizeDto();

            var model1 = GivenTheDefaultProductSizeLogDto();
            model1.Id = 1;
            model1.PreviousEntity = null;
            model1.NewEntity = dto;

            var model2 = GivenTheDefaultProductSizeLogDto();
            model2.Id = 2;
            model2.PreviousEntity = dto;
            model2.NewEntity = null;

            var response = new List<ProductSizeLogDto>()
            {
                model1,
                model2
            };

            return response;
        }
        public static ProductViewedDto GivenTheDefaultProductViewedDto()
        {
            var response = new ProductViewedDto()
            {
                Id = 1,
                ProductId = "Property",
                ProductCode = "Property",
                Username = "Property",
                DateTimeInitial = "Property",
                TimeViewed = "Property",
                Property5 = "Property",
                Property6 = "Property",
                Property7 = "Property",
                Property8 = "Property",
                Property9 = "Property"
            };

            return response;
        }

        public static List<ProductViewedDto> GivenTheDefaultListProductViewedDto()
        {
            var dto1 = GivenTheDefaultProductViewedDto();
            dto1.Id = 1;

            var dto2 = GivenTheDefaultProductViewedDto();
            dto2.Id = 2;

            var response = new List<ProductViewedDto>()
            {
                dto1,
                dto2
            };

            return response;
        }

        public static ProductViewedResponse GivenTheDefaultProductViewedResponse()
        {
            var response = new ProductViewedResponse()
            {
                Id = 1,
                ProductId = "Property",
                ProductCode = "Property",
                Username = "Property",
                DateTimeInitial = "Property",
                TimeViewed = "Property",
                Property5 = "Property",
                Property6 = "Property",
                Property7 = "Property",
                Property8 = "Property",
                Property9 = "Property"
            };

            return response;
        }

        public static List<ProductViewedResponse> GivenTheDefaultListProductViewedResponse()
        {
            var response1 = GivenTheDefaultProductViewedResponse();
            response1.Id = 1;

            var response2 = GivenTheDefaultProductViewedResponse();
            response2.Id = 2;

            var response = new List<ProductViewedResponse>()
            {
                response1,
                response2
            };

            return response;
        }

        public static ProductViewedRequest GivenTheDefaultProductViewedRequest()
        {
            var response = new ProductViewedRequest()
            {
                Id = 1,
                ProductId = "Property",
                ProductCode = "Property",
                Username = "Property",
                DateTimeInitial = "Property",
                TimeViewed = "Property",
                Property5 = "Property",
                Property6 = "Property",
                Property7 = "Property",
                Property8 = "Property",
                Property9 = "Property"
            };

            return response;
        }

        public static ProductViewed GivenTheDefaultProductViewed()
        {
            var response = new ProductViewed()
            {
                Id = 1,
                ProductId = "Property",
                ProductCode = "Property",
                Username = "Property",
                DateTimeInitial = "Property",
                TimeViewed = "Property",
                Property5 = "Property",
                Property6 = "Property",
                Property7 = "Property",
                Property8 = "Property",
                Property9 = "Property"
            };

            return response;
        }

        public static List<ProductViewed> GivenTheDefaultListProductViewed()
        {
            var model1 = GivenTheDefaultProductViewed();
            model1.Id = 1;

            var model2 = GivenTheDefaultProductViewed();
            model2.Id = 2;

            var response = new List<ProductViewed>()
            {
                model1,
                model2
            };

            return response;
        }

        public static ProductViewedLog GivenTheDefaultProductViewedLog()
        {
            var response = new ProductViewedLog()
            {
                Id = 1,
                Username = "Username",
                DateTime = DateTime,
                PreviousValue = "PreviousValue",
                NewValue = "NewValue",
                PreviousEntity = default,
                NewEntity = default,
            };

            return response;
        }

        public static List<ProductViewedLog> GivenTheDefaultListProductViewedLog()
        {
            var entity = GivenTheDefaultProductViewed();

            var model1 = GivenTheDefaultProductViewedLog();
            model1.Id = 1;
            model1.PreviousValue = "null";
            model1.NewValue = JsonConvert.SerializeObject(entity);

            var model2 = GivenTheDefaultProductViewedLog();
            model2.Id = 2;
            model2.PreviousValue = JsonConvert.SerializeObject(entity);
            model2.NewValue = "null";

            var response = new List<ProductViewedLog>()
            {
                model1,
                model2
            };

            return response;
        }

        public static ProductViewedLogDto GivenTheDefaultProductViewedLogDto()
        {
            var response = new ProductViewedLogDto()
            {
                Id = 1,
                Username = "Username",
                DateTime = DateTime,
                PreviousEntity = default,
                NewEntity = default,
            };

            return response;
        }

        public static List<ProductViewedLogDto> GivenTheDefaultListProductViewedLogDto()
        {
            var dto = GivenTheDefaultProductViewedDto();

            var model1 = GivenTheDefaultProductViewedLogDto();
            model1.Id = 1;
            model1.PreviousEntity = null;
            model1.NewEntity = dto;

            var model2 = GivenTheDefaultProductViewedLogDto();
            model2.Id = 2;
            model2.PreviousEntity = dto;
            model2.NewEntity = null;

            var response = new List<ProductViewedLogDto>()
            {
                model1,
                model2
            };

            return response;
        }
        public static SizeDto GivenTheDefaultSizeDto()
        {
            var response = new SizeDto()
            {
                Id = 1,
                Code = "Property",
                Name = "Property",
                Description = "Property",
                Property3 = "Property",
                Property4 = "Property",
                Property5 = "Property",
                Property6 = "Property",
                Property7 = "Property",
                Property8 = "Property",
                Property9 = "Property"
            };

            return response;
        }

        public static List<SizeDto> GivenTheDefaultListSizeDto()
        {
            var dto1 = GivenTheDefaultSizeDto();
            dto1.Id = 1;

            var dto2 = GivenTheDefaultSizeDto();
            dto2.Id = 2;

            var response = new List<SizeDto>()
            {
                dto1,
                dto2
            };

            return response;
        }

        public static SizeResponse GivenTheDefaultSizeResponse()
        {
            var response = new SizeResponse()
            {
                Id = 1,
                Code = "Property",
                Name = "Property",
                Description = "Property",
                Property3 = "Property",
                Property4 = "Property",
                Property5 = "Property",
                Property6 = "Property",
                Property7 = "Property",
                Property8 = "Property",
                Property9 = "Property"
            };

            return response;
        }

        public static List<SizeResponse> GivenTheDefaultListSizeResponse()
        {
            var response1 = GivenTheDefaultSizeResponse();
            response1.Id = 1;

            var response2 = GivenTheDefaultSizeResponse();
            response2.Id = 2;

            var response = new List<SizeResponse>()
            {
                response1,
                response2
            };

            return response;
        }

        public static SizeRequest GivenTheDefaultSizeRequest()
        {
            var response = new SizeRequest()
            {
                Id = 1,
                Property0 = "Property",
                Property1 = "Property",
                Property2 = "Property",
                Property3 = "Property",
                Property4 = "Property",
                Property5 = "Property",
                Property6 = "Property",
                Property7 = "Property",
                Property8 = "Property",
                Property9 = "Property"
            };

            return response;
        }

        public static Size GivenTheDefaultSize()
        {
            var response = new Size()
            {
                Id = 1,
                Code = "Property",
                Name = "Property",
                Description = "Property",
                ProductsSizes = "Property",
                Property4 = "Property",
                Property5 = "Property",
                Property6 = "Property",
                Property7 = "Property",
                Property8 = "Property",
                Property9 = "Property"
            };

            return response;
        }

        public static List<Size> GivenTheDefaultListSize()
        {
            var model1 = GivenTheDefaultSize();
            model1.Id = 1;

            var model2 = GivenTheDefaultSize();
            model2.Id = 2;

            var response = new List<Size>()
            {
                model1,
                model2
            };

            return response;
        }

        public static SizeLog GivenTheDefaultSizeLog()
        {
            var response = new SizeLog()
            {
                Id = 1,
                Username = "Username",
                DateTime = DateTime,
                PreviousValue = "PreviousValue",
                NewValue = "NewValue",
                PreviousEntity = default,
                NewEntity = default,
            };

            return response;
        }

        public static List<SizeLog> GivenTheDefaultListSizeLog()
        {
            var entity = GivenTheDefaultSize();

            var model1 = GivenTheDefaultSizeLog();
            model1.Id = 1;
            model1.PreviousValue = "null";
            model1.NewValue = JsonConvert.SerializeObject(entity);

            var model2 = GivenTheDefaultSizeLog();
            model2.Id = 2;
            model2.PreviousValue = JsonConvert.SerializeObject(entity);
            model2.NewValue = "null";

            var response = new List<SizeLog>()
            {
                model1,
                model2
            };

            return response;
        }

        public static SizeLogDto GivenTheDefaultSizeLogDto()
        {
            var response = new SizeLogDto()
            {
                Id = 1,
                Username = "Username",
                DateTime = DateTime,
                PreviousEntity = default,
                NewEntity = default,
            };

            return response;
        }

        public static List<SizeLogDto> GivenTheDefaultListSizeLogDto()
        {
            var dto = GivenTheDefaultSizeDto();

            var model1 = GivenTheDefaultSizeLogDto();
            model1.Id = 1;
            model1.PreviousEntity = null;
            model1.NewEntity = dto;

            var model2 = GivenTheDefaultSizeLogDto();
            model2.Id = 2;
            model2.PreviousEntity = dto;
            model2.NewEntity = null;

            var response = new List<SizeLogDto>()
            {
                model1,
                model2
            };

            return response;
        }
    }
}
