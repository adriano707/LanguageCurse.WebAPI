namespace LanguageCourse.Domain.Context.ClassAggregate.Exceptions
{
    public class ClassCannotBeDeletedException : Exception
    {
        public ClassCannotBeDeletedException() : base("Class cannot be deleted as it has students enrolled") { }
    }
}
