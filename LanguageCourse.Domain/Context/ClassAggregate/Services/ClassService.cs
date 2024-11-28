using LanguageCourse.Domain.Context.ClassAggregate.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LanguageCourse.Domain.Context.ClassAggregate.Services
{
    public class ClassService : IClassService
    {
        public Task<Class> GetClassById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Class>> GetAllSClassies()
        {
            throw new NotImplementedException();
        }

        public Task<Class> CreateClass()
        {
            throw new NotImplementedException();
        }

        public Task DeletClass(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
