using Microsoft.AspNetCore.Mvc;
using Shoop.Core.Dtos;
using Shoop.Service.Services.Interfaces;

namespace Shoop.Api.Controllers
{
    [Route("api/v1/[Controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        readonly ICategoryService _service;

        public CategoriesController(ICategoryService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryPostDto dto)
        {
            await _service.CreateAsync(dto);

            return StatusCode(201);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(CategoryPostDto dto,Guid id)
        {
            await _service.UpdateAsync(dto,id);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete( Guid id)
        {
            await _service.RemoveAsync(id);
            return NoContent();
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            return StatusCode(200, await _service.GetAsync(id));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return StatusCode(200, await _service.GetAll());
        }
    }
}

