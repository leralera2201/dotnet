using System.Collections.Generic;
using System.Threading.Tasks;
using Lab1.DTOs.OrderDTOs;
using Lab1.Entities;
using Lab1.Interfaces.SqlServices;
using Microsoft.AspNetCore.Mvc;
using Lab1.Entities.Parameters;

namespace Lab1.Controllers
{
    [ApiController]
    [Route("api/v1/orders")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _service;

        public OrderController(IOrderService service)
        {
            _service = service;
        }

        // GET: Get all entities
        [Route("")]
        [HttpGet]
        public async Task<IEnumerable<Order>> GetAll([FromQuery] OrderParameters parameters)
        {
            return await _service.GetAll(parameters);
        }

        // GET: Get single entity
        [Route("{id}")]
        [HttpGet]
        public async Task<Order> GetById(int id)
        {
            return await _service.GetOneById(id);
        }

        // POST: Create entity
        [Route("")]
        [HttpPost]
        public async Task<Order> Create([FromBody] OrderRequestDto dto)
        {
            return await _service.Create(dto);
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
        public async Task<Order> Update(int id, [FromBody] OrderRequestDto dto)
        {
            return await _service.Update(id, dto);
        }
    }
}