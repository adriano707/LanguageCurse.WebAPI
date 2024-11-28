using LanguageCourse.Domain.Context.EnrollmentAggregate.Entities;
using LanguageCourse.Domain.Context.StudentAggregate.Entities;
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
        }
    }
}
