using LanguageCourse.Domain.Context.ClassAggregate.Entities;

namespace LanguageCourse.Domain.Context.ClassAggregate.Services
{
    public interface IClassService
    {
        Task<Class> GetClassByIdAsync(Guid id);
        Task<List<Class>> GetAllSClassesAsync();
        Task<Class> CreateClassAsync(string name, string description);
        Task<Class> UpdateClassAsync(Guid id, string name, string description);
        Task DeleteClassAsync(Guid id);
    }
}
