namespace LanguageCourse.Domain.Context.StudentAggregate.Exceptions
{
    public class DuplicateEnrollmentException : Exception
    {
        public DuplicateEnrollmentException() : base("This student is already registered in this class")
        {
        }
    }

}
