using LanguageCourse.Domain.Context.ClassAggregate.Entities;
using LanguageCourse.Domain.Context.StudentAggregate.Entities;

namespace LanguageCourse.Domain.Context.EnrollmentAggregate.Entities
{
    public class Enrollment
    {
        public Guid Id { get; private set; }
        public string Number { get; private set; }
        public Student Student { get; private set; }
        public Guid StudentId { get; private set; }
        public Class Class { get; private set; }
        public Guid ClassId { get; private set; }

        public Enrollment(string number, Guid studentId, Guid classId)
        {
            Id = Guid.NewGuid();
            Number = number ?? throw new ArgumentNullException(nameof(number));
            StudentId = studentId;
            ClassId = classId;
        }
    }
}
