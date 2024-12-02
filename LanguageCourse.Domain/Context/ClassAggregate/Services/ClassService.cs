using LanguageCourse.Domain.Context.ClassAggregate.Entities;
using LanguageCourse.Domain.Context.ClassAggregate.Exceptions;
using LanguageCourse.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LanguageCourse.Domain.Context.ClassAggregate.Services
{
    public class ClassService : IClassService
    {
        private readonly IRepository _repository;

        public ClassService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<Class> GetClassByIdAsync(Guid id)
        {
            var classStudent = await _repository.Query<Class>().FirstOrDefaultAsync(c => c.Id == id);
            return classStudent;
        }

        public async Task<List<Class>> GetAllSClassesAsync()
        {
            var classStudent = await _repository.Query<Class>().ToListAsync();

            return classStudent;
        }

        public async Task<Class> CreateClassAsync(string name, string description)
        {
            Class classStudent = new Class(name, description);

            await _repository.InsertAsync(classStudent);
            await _repository.SaveChangeAsync();

            return classStudent;
        }

        public async Task<Class> UpdateClassAsync(Guid id, string number, string description)
        {
            var classe = _repository.Query<Class>().FirstOrDefault(c => c.Id == id);

            if (classe is not null)
            {
                classe.UpdateClass(number, description);
            }

            _repository.Update(classe);
            await _repository.SaveChangeAsync();

            return classe;
        }

        public async Task DeleteClassAsync(Guid id)
        {
            var classStudent = await _repository.Query<Class>()
                .Include(c => c.Enrollments)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (classStudent is null)
                throw new ClassNotFoundException();

            if (classStudent.Enrollments.Any())
                throw new ClassCannotBeDeletedException();

            _repository.Delete(classStudent);
            await _repository.SaveChangeAsync();
        }
    }
}
