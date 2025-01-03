﻿using LanguageCourse.Domain.Context.ClassAggregate.Entities;
using LanguageCourse.Domain.Context.StudentAggregate.Entities;

namespace LanguageCourse.Domain.Context.EnrollmentAggregate.Entities
{
    public class Enrollment
    {
        public Guid Id { get; set; }
        public Student Student { get; private set; }
        public Guid StudentId { get; private set; }
        public Class Class { get; private set; }
        public Guid ClassId { get; private set; }

        public Enrollment(Guid classId)
        {
            Id = Guid.NewGuid();
            ClassId = classId;
        }

        public Enrollment(Guid studentId, Guid classId)
        {
            StudentId = studentId;
            ClassId = classId;
        }
    }
}
