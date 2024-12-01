using LanguageCourse.Domain.Context.EnrollmentAggregate.Entities;
using LanguageCourse.Domain.Context.StudentAggregate.Enums;

namespace LanguageCourse.API.DTOs
{
    public class StudentDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public GenreEnum Genre { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public IReadOnlyCollection<EnrollmentDTO> Enrollments { get; set; }
    }
}
