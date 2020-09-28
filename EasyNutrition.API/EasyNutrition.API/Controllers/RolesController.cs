using AutoMapper;
using EasyNutrition.API.Domain.Models;
using EasyNutrition.API.Domain.Services;
using EasyNutrition.API.Extensions;
using EasyNutrition.API.Resources;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyNutrition.API.Controllers
{

    [Route("api/[controller]")]
    public class RolesController : ControllerBase
    {

        private readonly IRoleService _roleService;
        private readonly IMapper _mapper;

        public RolesController(IRoleService roleService, IMapper mapper)
        {
            _roleService = roleService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<RoleResource>> GetAllAsync()
        {
            var roles = await _roleService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Role>, IEnumerable<RoleResource>>(roles);
            return resources;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveRoleResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetMessages());
            var role = _mapper.Map<SaveRoleResource, Role>(resource);
            var result = await _roleService.SaveAsync(role);

            if (!result.Success)
                return BadRequest(result.Message);

            var roleResource = _mapper.Map<Role, RoleResource>(result.Resource);
            return Ok(roleResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveRoleResource resource)
        {
            var role = _mapper.Map<SaveRoleResource, Role>(resource);
            var result = await _roleService.UpdateAsync(id, role);

            if (!result.Success)
                return BadRequest(result.Message);
            var roleResource = _mapper.Map<Role, RoleResource>(result.Resource);
            return Ok(roleResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _roleService.DeleteAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var roleResource = _mapper.Map<Role, RoleResource>(result.Resource);
            return Ok(roleResource);

        }
    }
}
