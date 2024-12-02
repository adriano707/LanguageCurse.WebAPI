using LanguageCourse.Domain.Context.EnrollmentAggregate.Entities;

namespace LanguageCourse.Domain.Context.ClassAggregate.Entities
{
    public class Class
    {
        private List<Enrollment> _enrollment;

        public Guid Id { get; set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public IReadOnlyCollection<Enrollment> Enrollments => _enrollment;

        public Class(string name, string description)
        {
            Id = Guid.NewGuid();
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Description = description ?? throw new ArgumentNullException(nameof(description));
            _enrollment = new List<Enrollment>();
        }

        public void UpdateClass(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
