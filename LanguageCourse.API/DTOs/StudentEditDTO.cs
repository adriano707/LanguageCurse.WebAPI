using LanguageCourse.Domain.Context.StudentAggregate.Enums;

namespace LanguageCourse.API.DTOs
{
    public class StudentEditDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public GenreEnum Genre { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
    }
}
