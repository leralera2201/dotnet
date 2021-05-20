using System.Collections.Generic;
using System.Threading.Tasks;
using Lab1.DTOs.ProductDTOs;
using Lab1.Entities;
using Lab1.Interfaces.SqlServices;
using Microsoft.AspNetCore.Mvc;
using Lab1.Validators;
using Lab1.Entities.Parameters;

namespace Lab1.Controllers
{
    [ApiController]
    [Route("api/v1/products")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }

        // GET: Get all entities
        [Route("")]
        [HttpGet]
        public async Task<ActionResult> GetAll([FromQuery] ProductParameters parameters)
        {
            if (parameters.MinPrice > parameters.MaxPrice) return BadRequest("Max price should be greater than min");
            return Ok(await _service.GetAll(parameters));
        }

        // GET: Get single entity
        [Route("{id}")]
        [HttpGet]
        public async Task<Product> GetById(int id)
        {
            return await _service.GetOneById(id);
        }

        // POST: Create entity
        [Route("")]
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] ProductRequestDto dto)
        {
            var validator = new ProductValidator();
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
        public async Task<ActionResult> Update(int id, [FromBody] ProductRequestDto dto)
        {
            var validator = new ProductValidator();
            var result = await validator.ValidateAsync(dto);
            if (!result.IsValid) return BadRequest(result.Errors);
            return Ok(await _service.Update(id, dto));
        }
    }
}