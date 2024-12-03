using FluentValidation;
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
        private readonly IValidator<CreateClasstDTO> _validator;

        public ClassController(IClassService service, IValidator<CreateClasstDTO> validator)
        {
            _service = service;
            _validator = validator;
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
            var validateResult = _validator.Validate(dto);

            if (validateResult.IsValid)
            {
                var classe = await _service.CreateClassAsync(dto.Name, dto.Description);
                return Ok(classe);
            }
            
            return Conflict(validateResult.Errors);
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
