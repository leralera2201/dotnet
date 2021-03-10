using System.Collections.Generic;
using Lab1.Entities;
using Lab1.Interfaces.SqlServices;
using Microsoft.AspNetCore.Mvc;

namespace Lab1.Controllers
{
    [ApiController]
    [Route("api/v1/users")]
    public class UserController : ControllerBase
    {
        private IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        // GET: Get all entities
        [Route("")]
        [HttpGet]
        public IEnumerable<UserEntity> GetAll()
        {
            return _service.GetAll();
        }

        // GET: Get single entity
        [Route("{id}")]
        [HttpGet]
        public UserEntity GetById(int id)
        {
            return _service.GetOneById(id);
        }

        // POST: Create entity
        [Route("")]
        [HttpPost]
        public void Create([FromBody] UserEntity entity)
        {
            _service.Create(entity);
        }

        // DELETE: Delete single entity by id
        [Route("{id}")]
        [HttpDelete]
        public void DeleteById(int id)
        {
            _service.DeleteById(id);
        }

        // PUT: Update single entity
        [Route("")]
        [HttpPut]
        public void Update([FromBody] UserEntity entity)
        {
            _service.Update(entity);
        }
    }
}