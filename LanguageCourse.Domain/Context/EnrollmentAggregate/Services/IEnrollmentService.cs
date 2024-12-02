using LanguageCourse.Domain.Context.EnrollmentAggregate.Entities;

namespace LanguageCourse.Domain.Context.EnrollmentAggregate.Services
{
    public interface IEnrollmentService
    {
        Task<Enrollment> GetEnrollmentById(Guid id);
        Task<List<Enrollment>> GetAllEnrollments();
        Task DeletEnrollment(Guid id);
    }
}
