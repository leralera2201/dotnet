using System.Collections.Generic;
using System.Threading.Tasks;
using Lab1.DTOs.CategoryDTOs;
using Lab1.Entities;
using Lab1.Interfaces.SqlServices;
using Microsoft.AspNetCore.Mvc;
using Lab1.Validators;
using Lab1.Entities.Parameters;
using Microsoft.AspNetCore.Cors;

namespace Lab1.Controllers
{
    [ApiController]
    [Route("api/v1/categories")]
    [EnableCors("MyPolicy")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _service;

        public CategoryController(ICategoryService service)
        {
            _service = service;
        }

        // GET: Get all entities
        [Route("")]
        [HttpGet]
        public async Task<IEnumerable<Category>> GetAll([FromQuery] CategoryParameters parameters)
        {
            return await _service.GetAll(parameters);
        }

        // GET: Get single entity
        [Route("{id}")]
        [HttpGet]
        public async Task<Category> GetById(int id)
        {
            return await _service.GetOneById(id);
        }

        // POST: Create entity
        [Route("")]
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CategoryRequestDto dto)
        {
            var validator = new CategoryValidator();
            var result = await validator.ValidateAsync(dto);
            if (!result.IsValid) return BadRequest(result.Errors);
            return Ok(await _service.Create(dto));
        }

        // DELETE: Delete single entity by id
        [Route("{id}")]
        [HttpDelete]
        public async Task<int> DeleteById(int id)
        {
            return await _service.DeleteById(id);
        }

        // PUT: Update single entity
        [Route("{id}")]
        [HttpPut]
        public async Task<ActionResult> Update(int id, [FromBody] CategoryRequestDto dto)
        {
            var validator = new CategoryValidator();
            var result = await validator.ValidateAsync(dto);
            if (!result.IsValid) return BadRequest(result.Errors);
            return Ok(await _service.Update(id, dto));
        }
    }
}