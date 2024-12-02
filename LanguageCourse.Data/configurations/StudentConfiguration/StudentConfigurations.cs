using LanguageCourse.Domain.Context.StudentAggregate.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LanguageCourse.Data.Configurations.StudentConfiguration
{
    public class StudentConfigurations : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Name).HasColumnType("varchar(250)");
            builder.Property(s => s.CPF).HasColumnType("varchar(11)");
            builder.Property(s => s.Email).HasColumnType("varchar(250)");
            builder.Property(s => s.Genre).HasConversion<int>().IsRequired();

            builder.HasMany(s => s.Enrollments)  
                .WithOne(e => e.Student)     
                .HasForeignKey(e => e.StudentId);
        }
    }
}
