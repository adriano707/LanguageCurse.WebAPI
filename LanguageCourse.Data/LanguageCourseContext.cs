using LanguageCourse.Domain.Context.ClassAggregate.Entities;
using LanguageCourse.Domain.Context.EnrollmentAggregate.Entities;
using LanguageCourse.Domain.Context.StudentAggregate.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace LanguageCourse.Data
{
    public class LanguageCourseContext : DbContext
    {
        public DbSet<Student> Student { get; set; }
        public DbSet<Enrollment> Enrollment { get; set; }
        public DbSet<Class> Class { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
