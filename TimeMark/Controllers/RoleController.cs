using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Time.Domain.Interface;
using Time.Application.DTOs;
using TimeMark.Models;

namespace Time.API.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class RoleController : ControllerBase
	{
		private readonly IRoleService _service;

		public RoleController(IRoleService service)
		{
			_service = service;
		}

		// GET ALL
		[HttpGet]
		public async Task<ActionResult<IEnumerable<RoleDto>>> GetRoles()
		{
			var roles = await _service.GetAllRoles();

			var result = roles.Select(r => new RoleDto
			{
				RoleId = r.RoleId,
				RoleName = r.RoleName,
				Description = r.Description
			});

			return Ok(result);
		}

		// GET BY ID
		[HttpGet("{id}")]
		public async Task<ActionResult<RoleDto>> GetRole(int id)
		{
			var role = await _service.GetRoleById(id);

			if (role == null)
				return NotFound();

			var result = new RoleDto
			{
				RoleId = role.RoleId,
				RoleName = role.RoleName,
				Description = role.Description
			};

			return Ok(result);
		}

		// CREATE
		[HttpPost]
		public async Task<ActionResult<RoleDto>> CreateRole([FromBody] CreateRoleDto dto)
		{
			if (dto == null)
				return BadRequest();

			var role = new Role
			{
				RoleName = dto.RoleName,
				Description = dto.Description
			};

			var created = await _service.CreateRole(role);

			var result = new RoleDto
			{
				RoleId = created.RoleId,
				RoleName = created.RoleName,
				Description = created.Description
			};

			return CreatedAtAction(nameof(GetRole), new { id = result.RoleId }, result);
		}

		// UPDATE
		[HttpPut("{id}")]
		public async Task<ActionResult<RoleDto>> UpdateRole(int id, [FromBody] CreateRoleDto dto)
		{
			if (dto == null)
				return BadRequest();

			var role = new Role
			{
				RoleId = id,
				RoleName = dto.RoleName,
				Description = dto.Description
			};

			var updated = await _service.UpdateRole(role);

			if (updated == null)
				return NotFound();

			var result = new RoleDto
			{
				RoleId = updated.RoleId,
				RoleName = updated.RoleName,
				Description = updated.Description
			};

			return Ok(result);
		}

		// DELETE
		[HttpDelete("{id}")]
		public async Task<ActionResult> DeleteRole(int id)
		{
			var result = await _service.DeleteRole(id);

			if (!result)
				return NotFound();

			return NoContent();
		}
	}
}