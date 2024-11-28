using LanguageCourse.Domain.Context.StudentAggregate.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LanguageCourse.Domain.Context.ClassAggregate.Entities;

namespace LanguageCourse.Domain.Context.ClassAggregate.Services
{
    public interface IClassService
    {
        Task<Class> GetClassById(Guid id);
        Task<List<Class>> GetAllSClassies();
        Task<Class> CreateClass();
        Task DeletClass(Guid id);
    }
}
