using LanguageCourse.Domain.Context.ClassAggregate.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LanguageCourse.Data.Configurations.ClassConfiguration
{
    public class ClassConfigurations : IEntityTypeConfiguration<Class>
    {
        public void Configure(EntityTypeBuilder<Class> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Name).HasColumnType("varchar(250)");
        }
    }
}
