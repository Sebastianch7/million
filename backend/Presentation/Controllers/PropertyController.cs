using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Application.Exceptions;


namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PropertyController : ControllerBase
    {
        private readonly IPropertyService _service;

        public PropertyController(IPropertyService service)
        {
            _service = service;
        }        

        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id) =>
            Ok(await _service.GetByIdAsync(id));
    }
}
