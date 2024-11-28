using LanguageCourse.Domain.Context.EnrollmentAggregate.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LanguageCourse.Domain.Context.EnrollmentAggregate.Services
{
    public class EnrollmentService : IEnrollmentService
    {
        public Task<Enrollment> GetEnrollmentById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Enrollment>> GetAllEnrollments()
        {
            throw new NotImplementedException();
        }

        public Task<Enrollment> CreateEnrollment()
        {
            throw new NotImplementedException();
        }

        public Task DeletEnrollment(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
