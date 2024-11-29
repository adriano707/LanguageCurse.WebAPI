using LanguageCourse.Domain.Context.EnrollmentAggregate.Entities;

namespace LanguageCourse.Domain.Context.ClassAggregate.Entities
{
    public class Class
    {
        private List<Enrollment> _enrollment;

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public Guid StudentId { get; private set; }
        public IReadOnlyCollection<Enrollment> Enrollments => _enrollment;

        public Class(string name)
        {
            Id = Guid.NewGuid();
            Name = name ?? throw new ArgumentNullException(nameof(name));
            _enrollment = new List<Enrollment>();
        }
    }
}
