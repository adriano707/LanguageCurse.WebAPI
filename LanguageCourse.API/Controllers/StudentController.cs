using FluentValidation;
using LanguageCourse.API.DTOs;
using LanguageCourse.Domain.Context.StudentAggregate.Services;
using Microsoft.AspNetCore.Mvc;

namespace LanguageCourse.API.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [Route("api/v{v:apiVersion}/students")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _service;
        private readonly IValidator<CreateStudentDTO> _validator;

        public StudentController(IStudentService service, IValidator<CreateStudentDTO> validator)
        {
            _service = service;
            _validator = validator;
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetStudentById([FromRoute] Guid id)
        {
            var student = await _service.GetStudentById(id);
            return Ok(student);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            var students = await _service.GetAllStudentsAsync();
            return Ok(students);
        }

        [HttpPost]
        public async Task<IActionResult> CraeteStudent([FromBody] CreateStudentDTO dto)
        {
            var validateResult = _validator.Validate(dto);

            if (validateResult.IsValid)
            {
                var student = await _service.CreateStudentAsync(dto.Name, dto.Genre, dto.CPF, dto.Email, dto.ClassIds);
                return Ok(student);
            }

            return Conflict(validateResult.Errors);
        }

        [HttpPost("{id:guid}/enrollments")]
        public async Task<IActionResult> AddEnrollmentToStudent([FromRoute] Guid id, [FromBody] AddEnrollmentDTO dto)
        {
            await _service.AddEnrollmentToStudentAsync(id, dto.ClassId);
            return Ok();
        }


        [HttpPut]
        public async Task<IActionResult> UpdateStudent([FromBody] StudentEditDTO dto)
        {
            var student = await _service.UpdateStudent(dto.Id, dto.Name, dto.Genre, dto.CPF, dto.Email);
            return Ok(student);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteStudent([FromRoute] Guid id)
        {
            await _service.DeletStudent(id);
            return Ok();
        }
    }
}
