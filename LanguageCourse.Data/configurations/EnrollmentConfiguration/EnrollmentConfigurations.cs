using LanguageCourse.Domain.Context.EnrollmentAggregate.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LanguageCourse.Data.Configurations.EnrollmentConfiguration
{
    public class EnrollmentConfigurations : IEntityTypeConfiguration<Enrollment>
    {
        public void Configure(EntityTypeBuilder<Enrollment> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Number).HasColumnType("varchar(250)");

            builder.HasOne(e => e.Student)  
                .WithMany(s => s.Enrollments)  
                .HasForeignKey(e => e.StudentId)
                .OnDelete(DeleteBehavior.Cascade);  

            builder.HasOne(e => e.Class)  
                .WithMany(c => c.Enrollments)  
                .HasForeignKey(e => e.ClassId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
