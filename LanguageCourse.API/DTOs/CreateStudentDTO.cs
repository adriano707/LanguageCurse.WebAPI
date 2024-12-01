using LanguageCourse.Domain.Context.StudentAggregate.Enums;

namespace LanguageCourse.API.DTOs
{
    public class CreateStudentDTO
    {
        public string Name { get; set; }
        public GenreEnum Genre { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public List<Guid> ClassIds { get; set; }
    }
}
