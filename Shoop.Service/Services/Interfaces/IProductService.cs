using System;
using Shoop.Core.Dtos;
using Shoop.Core.Entities;

namespace Shoop.Service.Services.Interfaces
{
	public interface IProductService
	{
		public Task CreateAsync(ProductPostDto dto);

		public Task UpdateAsync(ProductUpdateDto dto,Guid id);

		public Task RemoveAsync(Guid id);

		public Task<ProductGetDto> GetAsync(Guid id);
		public Task<IEnumerable<ProductGetDto>> GetAll();
    }
}

