using System;
using LanguageCourse.Domain.Context.StudentAggregate.Entities;

namespace LanguageCourse.Domain.Context.ClassAggregate.Entities
{
    public class Class
    {
        public Guid Id { get; set; }
        public string Name { get; private set; }
        public Student Student { get; private set; }
        public Guid StudentId { get; private set; }

        public Class(Guid id, string name)
        {
            Id = Guid.NewGuid();
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }
    }
}
