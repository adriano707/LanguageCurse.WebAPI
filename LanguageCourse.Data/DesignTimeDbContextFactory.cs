using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace LanguageCourse.Data
{
    internal class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<LanguageCourseContext>
    {
        public LanguageCourseContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<LanguageCourseContext>();
            var connectionString = "server=localhost;database=db_language_course;user id=sa;password=aL58070102&77;Trusted_connection=false;TrustServerCertificate=True;";
            builder.UseSqlServer(connectionString);
            return new LanguageCourseContext(builder.Options);
        }
    }
}
