using LanguageCourse.API.DTOs;
using LanguageCourse.Domain.Context.EnrollmentAggregate.Services;
using Microsoft.AspNetCore.Mvc;

namespace LanguageCourse.API.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [Route("api/v{v:apiVersion}/enrollments")]
    public class EnrollmentController : ControllerBase
    {
        private readonly IEnrollmentService _service;

        public EnrollmentController(IEnrollmentService service)
        {
            _service = service;
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetEnrollmentById([FromRoute] Guid id)
        {
            var enrollment = await _service.GetEnrollmentById(id);
            return Ok(enrollment);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEnrollments()
        {
            var enrollments = await _service.GetAllEnrollments();
            return Ok(enrollments);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeletEnrollment([FromRoute] Guid id)
        {
            await _service.DeletEnrollment(id);
            return Ok();
        }
    }
}
