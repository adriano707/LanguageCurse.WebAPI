using LanguageCourse.Domain.Context.ClassAggregate.Entities;

namespace LanguageCourse.Domain.Context.ClassAggregate.Services
{
    public interface IClassService
    {
        Task<Class> GetClassById(Guid id);
        Task<List<Class>> GetAllSClassies();
        Task<Class> CreateClass(string name);
        Task<Class> UpdateClass(Guid id, string name);
        Task DeleteClass(Guid id);
    }
}
