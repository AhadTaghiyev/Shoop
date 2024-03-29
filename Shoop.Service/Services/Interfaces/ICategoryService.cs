using System;
using Shoop.Core.Dtos;
using Shoop.Core.Entities;

namespace Shoop.Service.Services.Interfaces
{
	public interface ICategoryService
	{
		public Task CreateAsync(CategoryPostDto dto);

		public Task UpdateAsync(CategoryPostDto dto,Guid id);

		public Task RemoveAsync(Guid id);

		public Task<CategoryGetDto> GetAsync(Guid id);
		public Task<IEnumerable<CategoryGetDto>> GetAll();
    }
}

