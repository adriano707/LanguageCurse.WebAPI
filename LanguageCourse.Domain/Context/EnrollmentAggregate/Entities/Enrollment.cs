using System;

namespace LanguageCourse.Domain.Context.EnrollmentAggregate.Entities
{
    public class Enrollment
    {
        public Guid Id { get; set; }
        public string Number { get; private set; }

        public Enrollment(Guid id, string number)
        {
            Id = Guid.NewGuid();
            Number = number ?? throw new ArgumentNullException(nameof(number));
        }
    }
}
