using LanguageCourse.Domain.Context.ClassAggregate.Entities;
using LanguageCourse.Domain.Context.StudentAggregate.Entities;
using LanguageCourse.Domain.Context.StudentAggregate.Enums;

namespace LanguageCourse.Domain.Context.StudentAggregate.Services
{
    public interface IStudentService
    {
        Task<Student> GetStudentById(Guid id);
        Task<List<Student>> GetAllStudents();
        Task<Student> CreateStudent(string name, GenreEnum genre, string cpf, string email, IReadOnlyCollection<Class> classes);
        Task DeletStudent(Guid id);
    }
}
