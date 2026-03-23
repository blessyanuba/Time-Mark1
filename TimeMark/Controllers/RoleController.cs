using Microsoft.AspNetCore.Mvc;
using TimeMark.Interfaces;
using TimeMark.Models;

namespace TimeMark.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class RoleController : ControllerBase
	{
		private readonly IRoleService _service;

		public RoleController(IRoleService service)
		{
			_service = service;
		}

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var result = await _service.GetAllRoles();
			return Ok(result);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var result = await _service.GetRoleById(id);
			if (result == null)
				return NotFound();

			return Ok(result);
		}

		[HttpPost]
		public async Task<IActionResult> Create([FromBody] Role role)
		{
			var result = await _service.CreateRole(role);
			return Ok(result);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Update(int id, [FromBody] Role role)
		{
			var updated = await _service.UpdateRole(id, role);
			if (updated == null)
				return NotFound();

			return Ok(updated);
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			var result = await _service.DeleteRole(id);
			

			return Ok("Role deleted successfully");
		}
	}
}