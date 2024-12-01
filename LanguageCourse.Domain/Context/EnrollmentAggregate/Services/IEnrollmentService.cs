using LanguageCourse.Domain.Context.EnrollmentAggregate.Entities;

namespace LanguageCourse.Domain.Context.EnrollmentAggregate.Services
{
    public interface IEnrollmentService
    {
        Task<Enrollment> GetEnrollmentById(Guid id);
        Task<List<Enrollment>> GetAllEnrollments();
        Task<Enrollment> UpdateEnrollment(Guid id, string number);
        Task DeletEnrollment(Guid id);
    }
}
