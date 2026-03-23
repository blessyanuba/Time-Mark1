using Microsoft.AspNetCore.Mvc;
using Time.Application.Interfaces;
using Time.Application.Interfaces;
using Time.Domain.Entity;
using TimeMark.Interfaces;
using TimeMark.Models;

namespace TimeMark.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		private readonly IUserService _service;

		public UserController(IUserService service)
		{
			_service = service;
		}

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var users = await _service.GetAll();
			return Ok(users);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var user = await _service.GetById(id);
			if (user == null)
				return NotFound();

			return Ok(user);
		}

		[HttpPost]
		public async Task<IActionResult> Create([FromBody] User user)
		{
			var createdUser = await _service.Add(user);
			return Ok(createdUser);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Update(int id, [FromBody] User user)
		{
			var updatedUser = await _service.Update( user);
			if (updatedUser == null)
				return NotFound();

			return Ok(updatedUser);
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			var deleted = await _service.Delete(id);
			if (!deleted)
				return NotFound();

			return Ok("User deleted successfully");
		}
	}
}