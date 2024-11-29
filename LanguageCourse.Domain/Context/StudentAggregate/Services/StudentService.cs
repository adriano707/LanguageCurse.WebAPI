using LanguageCourse.Domain.Context.StudentAggregate.Entities;
using LanguageCourse.Domain.Context.StudentAggregate.Enums;
using LanguageCourse.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LanguageCourse.Domain.Context.StudentAggregate.Services
{
    public class StudentService : IStudentService
    {
        private readonly IRepository _repository;
        public async Task<Student> GetStudentById(Guid id)
        {
            var student = _repository.Query<Student>().FirstOrDefault(s => s.Id == id);
            return student;
        }

        public async Task<List<Student>> GetAllStudents()
        {
            var students = _repository.Query<Student>().ToList();
            return students;
        }

        public async Task<Student> CreateStudent(string name, GenreEnum genre, string cpf, string email)
        {
            Student student = new Student(name, genre, cpf, email);

            bool cpfExists = await _repository.Query<Student>().AnyAsync(s => s.CPF == cpf);

            if (cpfExists)
                throw new InvalidOperationException("There is already a student with the provided CPF.");

            await _repository.InsertAsync(student);
            await _repository.SaveChangeAsync();

            return student;
        }

        public async Task DeletStudent(Guid id)
        {
            var student = _repository.Query<Student>().FirstOrDefault(s => s.Id == id);

            if (student is not null)
            {
                _repository.Delete(student);
                await _repository.SaveChangeAsync();
            }
        }
    }
}
