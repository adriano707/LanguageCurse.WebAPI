namespace LanguageCourse.API.DTOs
{
    public class EnrollmentDTO
    {
        public Guid Id { get; set; }
        public string Number { get; set; }
        public StudentDTO Student { get; set; }
        public Guid StudentId { get; set; }
        public ClassDTO Class { get; set; }
        public Guid ClassId { get; set; }
    }
}
