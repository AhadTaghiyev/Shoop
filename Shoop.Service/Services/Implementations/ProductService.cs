using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Shoop.Core.Dtos;
using Shoop.Core.Entities;
using Shoop.Core.Exceptions;
using Shoop.Data.Contexts;
using Shoop.Data.Repositories.Interfaces;
using Shoop.Service.Services.Interfaces;

namespace Shoop.Service.Services.Implementations
{
    public class ProductService : IProductService
    {
        readonly IProductRepository _repository;
        readonly IWebHostEnvironment _env;

        public ProductService(IProductRepository repository, IWebHostEnvironment env)
        {
            _repository = repository;
            _env = env;
        }

        public async Task CreateAsync(ProductPostDto dto)
        {
            if (await _repository.IsExsist(x=>x.Name.Trim().ToLower()== dto.Name.Trim().ToLower()))
            {
                throw new AlreadyExist("Already Exsist");
            }
            Product Product = new Product
            {
                Name = dto.Name,
                Storage="wwwroot",
                CategoryId=dto.CategoryId,
                Description=dto.Description,
                Price=dto.Price
            };

           if (!dto.Image.ContentType.Contains("image/"))
            {
                throw new BadRequestException("Please choose image file");
            }

            var filesize = dto.Image.Length/1024/1024;
            if (filesize>2)
            {
                throw new BadRequestException("Max image size 2mb");
            }

            string wwwroot = _env.WebRootPath;
            string FileName = Guid.NewGuid().ToString()+dto.Image.FileName;

            string FullPath = Path.Combine(wwwroot,"Images",FileName);

            using(FileStream fileStream=new FileStream(FullPath,FileMode.Create))
            {
                dto.Image.CopyTo(fileStream);
            }
            Product.Image = FileName;
            Product.ImagePath = $"/images/{FileName}";



            await _repository.AddAsync(Product);

            await _repository.SaveAsync();
        }

        public async Task<IEnumerable<ProductGetDto>> GetAll()
        {
            IQueryable<Product> query =await _repository.GetQuery(x=>!x.IsDeleted);

            IEnumerable<ProductGetDto> categories =await
                query.Select(Product=>new ProductGetDto
                {
                    Id = Product.Id,
                    Name = Product.Name,
                    Storga = Product.Storage,
                    CategoryId = Product.CategoryId,
                    Description = Product.Description,
                    Image = Product.Image,
                    ImagePath = Product.ImagePath,
                    Price = Product.Price
                }).ToListAsync();

            return categories;
        }

        public async Task<ProductGetDto> GetAsync(Guid id)
        {
            //Product Product =await _repository.GetAsync(x=>!x.IsDeleted&&x.Id==id);

            IQueryable<Product> query = await _repository.GetQuery(x => !x.IsDeleted && x.Id == id);

            ProductGetDto? Product = await
                query.Select(Product => new ProductGetDto
                {
                    Id = Product.Id,
                    Name = Product.Name,
                    Storga=Product.Storage,
                    CategoryId=Product.CategoryId,
                    Description=Product.Description,
                    Image=Product.Image,
                    ImagePath=Product.ImagePath,
                    Price=Product.Price
                }).FirstOrDefaultAsync();

            if(Product == null)
            {
                throw new NotFoundException("Item Not Found");
            }

            return Product;
        }

        public async Task RemoveAsync(Guid id)
        {
            Product Product =await _repository.GetAsync(x=>!x.IsDeleted&&x.Id==id);

            Product.IsDeleted = true;

           await _repository.UpdateAsync(Product);
            await _repository.SaveAsync();

        }

        public async Task UpdateAsync(ProductUpdateDto dto, Guid id)
        {
            Product Product = await _repository.GetAsync(x => !x.IsDeleted && x.Id == id);

            Product.Name = dto.Name;
            Product.Description = dto.Description;
            Product.Price = dto.Price;
            Product.CategoryId = dto.CategoryId;
            if (dto.Image != null)
            {
                if (!dto.Image.ContentType.Contains("image/"))
                {
                    throw new BadRequestException("Please choose image file");
                }

                var filesize = dto.Image.Length / 1024 / 1024;
                if (filesize > 2)
                {
                    throw new BadRequestException("Max image size 2mb");
                }

                string wwwroot = _env.WebRootPath;
                string FileName = Guid.NewGuid().ToString() + dto.Image.FileName;

                string FullPath = Path.Combine(wwwroot, "Images", FileName);

                using (FileStream fileStream = new FileStream(FullPath, FileMode.Create))
                {
                    dto.Image.CopyTo(fileStream);
                }
                Product.Image = FileName;
                Product.ImagePath = $"/images/{FileName}";
            }

            await _repository.UpdateAsync(Product);
            await _repository.SaveAsync();
        }
    }
}

