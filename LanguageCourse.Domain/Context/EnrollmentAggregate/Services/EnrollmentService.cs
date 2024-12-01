using LanguageCourse.Domain.Context.EnrollmentAggregate.Entities;
using LanguageCourse.Domain.Repositories;

namespace LanguageCourse.Domain.Context.EnrollmentAggregate.Services
{
    public class EnrollmentService : IEnrollmentService
    {
        private readonly IRepository _repository;

        public EnrollmentService(IRepository repository)
        {
            _repository = repository;
        }
        public async Task<Enrollment> GetEnrollmentById(Guid id)
        {
            var enrollmet = _repository.Query<Enrollment>().FirstOrDefault(e => e.Id == id);
            return enrollmet;
        }

        public async Task<List<Enrollment>> GetAllEnrollments()
        {
            var enrollmet = _repository.Query<Enrollment>().ToList();
            return enrollmet;
        }

        public async Task<Enrollment> UpdateEnrollment(Guid id, string number)
        {
            var enrollment = _repository.Query<Enrollment>().FirstOrDefault(e => e.Id == id);

            if (enrollment is not null)
            {
                enrollment.UpdateEnrollment(number);
            }

            _repository.Update(enrollment);
            await _repository.SaveChangeAsync();

            return enrollment;
        }

        public async Task DeletEnrollment(Guid id)
        {
            var student = _repository.Query<Enrollment>().FirstOrDefault(s => s.Id == id);

            if (student is not null)
            {
                _repository.Delete(student);
                await _repository.SaveChangeAsync();
            }
        }
    }
}
