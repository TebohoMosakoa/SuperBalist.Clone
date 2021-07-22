using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using User.Api.Models;
using User.Api.Repositories;

namespace User.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserRepository _repository;

        public UsersController(UserManager<ApplicationUser> userManager, IUserRepository repository)
        {
            _userManager = userManager;
            _repository = repository;
        }

        // GET: api/[controller]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ApplicationUser>>> Get()
        {
            return await _repository.GetAll();
        }

        // GET: api/[controller]/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ApplicationUser>> Get(string id)
        {
            var item = await _repository.Get(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        // PUT: api/[controller]/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, ApplicationUser item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }
            await _repository.Update(item);
            return NoContent();
        }

        // POST: api/[controller]
        [HttpPost]
        public async Task<ActionResult<ApplicationUser>> Post(ApplicationUser item)
        {
            await _repository.Add(item);
            await _userManager.AddToRoleAsync(item, "User");
            return CreatedAtAction("Get", new { id = item.Id }, item);
        }

        // DELETE: api/[controller]/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ApplicationUser>> Delete(string id)
        {
            var item = await _repository.Delete(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }
    }
}
