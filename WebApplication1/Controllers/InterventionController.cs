using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services.Model;
using System.Security.Claims;
using WebApplication1.Services.Intervention;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InterventionController : ControllerBase
    {
        private readonly IInterventionService _service;

        public InterventionController(IInterventionService service)
        {
            _service = service;
        }

        [HttpGet]
        [Authorize(Roles = "admin,technicien,client")]
        public async Task<IActionResult> GetAll()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var isAdmin = User.IsInRole("admin");

            var interventions = await _service.GetAllAsync(userId, isAdmin);
            return Ok(interventions);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "admin,technicien")]
        public async Task<IActionResult> GetById(int id)
        {
            var intervention = await _service.GetByIdAsync(id);
            return intervention == null ? NotFound() : Ok(intervention);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Create(InterventionCreateModel model)
        {
            var created = await _service.CreateAsync(model);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }
    }
}
