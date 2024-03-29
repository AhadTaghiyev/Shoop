using System;
using Microsoft.EntityFrameworkCore;
using Shoop.Core.Dtos;
using Shoop.Core.Entities;
using Shoop.Core.Exceptions;
using Shoop.Data.Contexts;
using Shoop.Data.Repositories.Interfaces;
using Shoop.Service.Services.Interfaces;

namespace Shoop.Service.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        readonly ICategoryRepository _repository;

        public CategoryService(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task CreateAsync(CategoryPostDto dto)
        {
            if (await _repository.IsExsist(x=>x.Name.Trim().ToLower()== dto.Name.Trim().ToLower()))
            {
                throw new AlreadyExist("Already Exsist");
            }
            Category category = new Category
            {
                Name = dto.Name
            };

            await _repository.AddAsync(category);

            await _repository.SaveAsync();
        }

        public async Task<IEnumerable<CategoryGetDto>> GetAll()
        {
            IQueryable<Category> query =await _repository.GetQuery(x=>!x.IsDeleted);

            IEnumerable<CategoryGetDto> categories =await
                query.Select(category=>new CategoryGetDto
                {
                    Id= category.Id,
                    Name= category.Name
                }).ToListAsync();

            return categories;
        }

        public async Task<CategoryGetDto> GetAsync(Guid id)
        {
            //Category category =await _repository.GetAsync(x=>!x.IsDeleted&&x.Id==id);

            IQueryable<Category> query = await _repository.GetQuery(x => !x.IsDeleted && x.Id == id);

            CategoryGetDto? category = await
                query.Select(category => new CategoryGetDto
                {
                    Id = category.Id,
                    Name = category.Name
                }).FirstOrDefaultAsync();

            if(category == null)
            {
                throw new NotFoundException("Item Not Found");
            }

            return category;
        }

        public async Task RemoveAsync(Guid id)
        {
            Category category =await _repository.GetAsync(x=>!x.IsDeleted&&x.Id==id);

            category.IsDeleted = true;

           await _repository.UpdateAsync(category);
            await _repository.SaveAsync();

        }

        public async Task UpdateAsync(CategoryPostDto dto, Guid id)
        {
            Category category = await _repository.GetAsync(x => !x.IsDeleted && x.Id == id);

            category.Name = dto.Name;

            await _repository.UpdateAsync(category);
            await _repository.SaveAsync();
        }
    }
}

