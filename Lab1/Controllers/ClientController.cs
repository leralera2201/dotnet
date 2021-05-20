using System.Collections.Generic;
using System.Threading.Tasks;
using Lab1.DTOs.ClientDTOs;
using Lab1.Entities;
using Lab1.Interfaces.SqlServices;
using Microsoft.AspNetCore.Mvc;
using Lab1.Entities.Parameters;

namespace Lab1.Controllers
{
    [ApiController]
    [Route("api/v1/clients")]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _service;

        public ClientController(IClientService service)
        {
            _service = service;
        }

        // GET: Get all entities
        [Route("")]
        [HttpGet]
        public async Task<IEnumerable<Client>> GetAll([FromQuery] ClientParameters parameters)
        {
            return await _service.GetAll(parameters);
        }

        // GET: Get single entity
        [Route("{id}")]
        [HttpGet]
        public async Task<Client> GetById(int id)
        {
            return await _service.GetOneById(id);
        }

        // POST: Create entity
        [Route("")]
        [HttpPost]
        public async Task<Client> Create([FromBody] ClientRequestDto dto)
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
        public async Task<Client> Update(int id, [FromBody] ClientRequestDto dto)
        {
            return await _service.Update(id, dto);
        }
    }
}