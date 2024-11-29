using LanguageCourse.Domain.Context.ClassAggregate.Entities;
using LanguageCourse.Domain.Context.EnrollmentAggregate.Entities;

namespace LanguageCourse.Domain.Context.ClassAggregate.Services
{
    public interface IClassService
    {
        Task<Class> GetClassById(Guid id);
        Task<List<Class>> GetAllSClassies();
        Task<Class> CreateClass(string name);
        Task DeletClass(Guid id);
    }
}
