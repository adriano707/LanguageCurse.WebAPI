using LanguageCourse.Domain.Context.EnrollmentAggregate.Entities;

namespace LanguageCourse.API.DTOs
{
    public class ClassDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid StudentId { get; set; }
        public IReadOnlyCollection<EnrollmentDTO> Enrollments { get; set; }
    }
}
