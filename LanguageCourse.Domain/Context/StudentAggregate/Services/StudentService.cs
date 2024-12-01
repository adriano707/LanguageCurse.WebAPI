using LanguageCourse.Domain.Context.ClassAggregate.Entities;
using LanguageCourse.Domain.Context.ClassAggregate.Exceptions;
using LanguageCourse.Domain.Context.EnrollmentAggregate.Entities;
using LanguageCourse.Domain.Context.StudentAggregate.Entities;
using LanguageCourse.Domain.Context.StudentAggregate.Enums;
using LanguageCourse.Domain.Context.StudentAggregate.Exceptions;
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

        public async Task<Student> CreateStudent(string name, GenreEnum genre, string cpf, string email, List<Guid> classIds)
        {
            Student student = new Student(name, genre, cpf, email);

            if (await _repository.Query<Student>().AnyAsync(s => s.CPF == cpf))
                throw new AlreadyRegisteredStudentException(cpf);

            foreach (var idClass in classIds)
            {
                await CheckNumberOfEnrollmentsByClass(idClass);

                Enrollment enrollment = new Enrollment(idClass);

                student.AddEnrollment(enrollment);
            }

            await _repository.InsertAsync(student);
            await _repository.SaveChangeAsync();

            return student;
        }

        private async Task CheckNumberOfEnrollmentsByClass(Guid idClass)
        {
            var numbeOfEnrollmentsPerCass = await _repository.Query<Class>()
                .Include(c => c.Enrollments).CountAsync(c => c.Id == idClass);

            if (numbeOfEnrollmentsPerCass >= 5) throw new MaximumNumberOfStudentsPerClassExceededException();
        }

        public async Task<Student> UpdateStudent(Guid id, string name, GenreEnum genre, string cpf, string email)
        {
            var student = _repository.Query<Student>().FirstOrDefault(s => s.Id == id);

            if (student is not null)
            {
                student.UpdateStudent(name, genre, cpf, email);

                _repository.Update(student);
                await _repository.SaveChangeAsync();
            }
            
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
