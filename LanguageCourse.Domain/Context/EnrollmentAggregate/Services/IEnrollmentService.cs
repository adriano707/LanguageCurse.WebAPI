using LanguageCourse.Domain.Context.EnrollmentAggregate.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LanguageCourse.Domain.Context.EnrollmentAggregate.Services
{
    public interface IEnrollmentService
    {
        Task<Enrollment> GetEnrollmentById(Guid id);
        Task<List<Enrollment>> GetAllEnrollments();
        Task<Enrollment> CreateEnrollment();
        Task DeletEnrollment(Guid id);
    }
}
