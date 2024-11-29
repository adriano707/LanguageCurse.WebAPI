using LanguageCourse.Domain.Context.ClassAggregate.Entities;
using LanguageCourse.Domain.Context.EnrollmentAggregate.Entities;
using LanguageCourse.Domain.Context.StudentAggregate.Entities;
using LanguageCourse.Domain.Repositories;

namespace LanguageCourse.Domain.Context.ClassAggregate.Services
{
    public class ClassService : IClassService
    {
        private readonly IRepository _repository;
        public async Task<Class> GetClassById(Guid id)
        {
            var classStudent = _repository.Query<Class>().FirstOrDefault(c => c.Id == id);
            return classStudent;
        }

        public async Task<List<Class>> GetAllSClassies()
        {
            var classStudent = _repository.Query<Class>().ToList();

            return classStudent;
        }

        public async Task<Class> CreateClass(string name)
        {
            Class classStudent = new Class(name);
            await _repository.InsertAsync(classStudent);
            await _repository.SaveChangeAsync();

            return classStudent;
        }

        public async Task DeletClass(Guid id)
        {
            var classStudent = _repository.Query<Student>().FirstOrDefault(s => s.Id == id);

            if (classStudent is not null)
            {
                _repository.Delete(classStudent);
                await _repository.SaveChangeAsync();
            }
        }
    }
}
