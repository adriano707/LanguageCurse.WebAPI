using LanguageCourse.API.DTOs;
using LanguageCourse.Domain.Context.ClassAggregate.Services;
using Microsoft.AspNetCore.Mvc;

namespace LanguageCourse.API.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [Route("classes")]
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
            var classe = _service.GetClassById(id);
            return Ok(classe);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllClasses()
        {
            var classes = _service.GetAllSClassies();
            return Ok(classes);
        }

        [HttpPost]
        public async Task<IActionResult> CreateClass([FromBody] CreateClasstDTO dto)
        {
            var classe = await _service.CreateClass(dto.Name);
            return Ok(classe);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateClass(ClassEditDTO dto)
        {
            var classe = await _service.UpdateClass(dto.Id, dto.Name);
            return Ok(classe);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteClass([FromRoute] Guid id)
        {
            await _service.DeleteClass(id);
            return Ok();
        }
    }
}
