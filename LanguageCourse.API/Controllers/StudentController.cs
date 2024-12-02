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

        public StudentController(IStudentService service)
        {
            _service = service;
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
            var students = await _service.GetAllStudents();
            return Ok(students);
        }

        [HttpPost]
        public async Task<IActionResult> CraeteStudent([FromBody] CreateStudentDTO dto)
        {
            var student = await _service.CreateStudent(dto.Name, dto.Genre, dto.CPF, dto.Email, dto.ClassIds);
            return Ok(student);
        }

        [HttpPost("{id:guid}/enrollments")]
        public async Task<IActionResult> AddEnrollmentToStudent([FromRoute] Guid id, [FromBody] AddEnrollmentDTO dto)
        {
            await _service.AddEnrollmentToStudent(id, dto.ClassId);
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
