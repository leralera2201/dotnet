using System.Collections.Generic;
using System.Threading.Tasks;
using Lab1.DTOs.TrainDTOs;
using Lab1.Entities;
using Lab1.Interfaces.SqlServices;
using Microsoft.AspNetCore.Mvc;

namespace Lab1.Controllers
{
    [ApiController]
    [Route("api/v1/trains")]
    public class TrainController : ControllerBase
    {
        private readonly ITrainService _service;

        public TrainController(ITrainService service)
        {
            _service = service;
        }

        // GET: Get all entities
        [Route("")]
        [HttpGet]
        public async Task<IEnumerable<Train>> GetAll()
        {
            return await _service.GetAll();
        }

        // GET: Get single entity
        [Route("{id}")]
        [HttpGet]
        public async Task<Train> GetById(int id)
        {
            return await _service.GetOneById(id);
        }

        // POST: Create entity
        [Route("")]
        [HttpPost]
        public async Task<Train> Create([FromBody] TrainRequestDto dto)
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
        public async Task<Train> Update(int id, [FromBody] TrainRequestDto dto)
        {
            return await _service.Update(id, dto);
        }
    }
}