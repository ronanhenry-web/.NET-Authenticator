using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services.Model;
using WebApplication1.Services.ServiceType;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServiceTypeController : ControllerBase
    {
        private readonly IServiceTypeService _service;

        public ServiceTypeController(IServiceTypeService service)
        {
            _service = service;
        }

        [HttpGet]
        [Authorize(Roles = "admin,technicien,client")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Create(ServiceTypeCreateModel model)
        {
            var created = await _service.CreateAsync(model);
            return CreatedAtAction(nameof(GetAll), new { id = created.Id }, created);
        }
    }
}
