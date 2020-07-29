using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIBase.Dal.Repositories;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProductsActivity.Common.Dtos.ProductDtos;
using ProductsActivity.Dal.Contexts;
using ProductsActivity.Dal.Models;

namespace ProductsActivity.Dal.Repositories.ProductRepository
{
    public class ProductRepository : BaseRepository<CatalogueContext, Product, long>, IProductRepository
    {
        private readonly IMapper _mapper;

        public ProductRepository(
            DbContextOptions<CatalogueContext> options,
            IMapper mapper)
            : base(options)
        {
            _mapper = mapper;
        }

        public async Task<List<ProductGirdDto>> GetFromAsync(long from, int take)
        {
            List<ProductGirdDto> response;
            using (var context = new CatalogueContext(_options))
            {
                response = await context.Products
                    .Where(p => p.Id > from)
                    .Where(p => p.Category.Active && p.Active)
                    .OrderBy(p => p.Id)
                    .Select(p => new ProductGirdDto
                    {
                        Id = p.Id,
                        MainImage = p.MainImage,
                        Price = p.Price
                    })
                    .Take(take)
                    .ToListAsync();
            }

            return response;
        }

        public async Task<ProductDto> GetByIdAsync(long id)
        {
            ProductDto response;

            using (var context = new CatalogueContext(_options))
            {
                response = await context.Products
                    .Where(p => p.Category.Active && p.Active)
                    .Include(p => p.ProductsSizes)
                        .ThenInclude(s => s.Size)
                    .Include(p => p.ProductsColors)
                        .ThenInclude(s => s.Color)
                    .Include(p => p.Images)
                    .Select(p => new ProductDto
                    {
                        Id = p.Id,
                        Title = p.Title,
                        Code = p.Code,
                        Price = p.Price,
                        PriceOld = p.PriceOld,
                        IncludeShipping = p.IncludeShipping,
                        Description = p.Description,
                        MainImage = p.MainImage,
                        ProductsSizes = p.ProductsSizes.Select(ps => new ProductSizeDto
                            {
                                QuantityAvailable = ps.QuantityAvailable,
                                Size = new SizeDto
                                    {
                                        Code = ps.Size.Code,
                                        Name = ps.Size.Name
                                    }
                            }).ToList(),
                        ProductsColors = p.ProductsColors.Select(pc => new ProductColorDto
                            {
                                Color = new ColorDto
                                {
                                    Name = pc.Color.Name,
                                    RGB = pc.Color.RGB
                                }
                            }).ToList(),
                        Images = p.Images.Where(i => i.Active).Select(i => new ImageDto
                            {
                                Id = i.Id,
                                ProductId = i.ProductId,
                                Url = i.Url
                            }).ToList()
                    })
                    .FirstOrDefaultAsync(p => p.Id == id);
            }

            return response;
        }
    }
}
