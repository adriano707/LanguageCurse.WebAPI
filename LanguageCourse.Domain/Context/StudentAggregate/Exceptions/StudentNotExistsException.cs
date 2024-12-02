namespace LanguageCourse.Domain.Context.StudentAggregate.Exceptions
{
    public class StudentNotExistsException : Exception
    {
        public StudentNotExistsException() : base("Student not exists.")
        {
        }
    }
}
