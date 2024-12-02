using LanguageCourse.API.DTOs;
using LanguageCourse.Domain.Context.ClassAggregate.Services;
using Microsoft.AspNetCore.Mvc;

namespace LanguageCourse.API.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [Route("api/v{v:apiVersion}/classes")]
    public class ClassController : ControllerBase
    {
        private readonly IClassService _service;

        public ClassController(IClassService service)
        {
            _service = service;
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetClassById([FromRoute] Guid id)
        {
            var classe = await _service.GetClassByIdAsync(id);
            return Ok(classe);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllClasses()
        {
            var classes = await _service.GetAllSClassesAsync();
            return Ok(classes);
        }

        [HttpPost]
        public async Task<IActionResult> CreateClass([FromBody] CreateClasstDTO dto)
        {
            var classe = await _service.CreateClassAsync(dto.Name, dto.Description);
            return Ok(classe);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateClass(ClassEditDTO dto)
        {
            var classe = await _service.UpdateClassAsync(dto.Id, dto.Name, dto.Description);
            return Ok(classe);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteClass([FromRoute] Guid id)
        {
            await _service.DeleteClassAsync(id);
            return Ok();
        }
    }
}
