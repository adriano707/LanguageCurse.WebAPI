using LanguageCourse.Domain.Context.ClassAggregate.Entities;
using LanguageCourse.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

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

        public async Task<Class> UpdateClass(Guid id, string number)
        {
            var classe = _repository.Query<Class>().FirstOrDefault(c => c.Id == id);

            if (classe is not null)
            {
                classe.UpdateClass(number);
            }

            _repository.Update(classe);
            await _repository.SaveChangeAsync();

            return classe;
        }

        public async Task DeleteClass(Guid id)
        {
            var classStudent = await _repository.Query<Class>()
                .Include(c => c.Enrollments)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (classStudent is null)
                throw new InvalidOperationException("Class not found.");

            if (classStudent.Enrollments.Any())
                throw new InvalidOperationException("Class cannot be deleted as it has students enrolled.");

            _repository.Delete(classStudent);
            await _repository.SaveChangeAsync();
        }
    }
}
