namespace LanguageCourse.Domain.Context.ClassAggregate.Exceptions
{
    public class ClassNotFoundException : Exception
    {
        public ClassNotFoundException() : base("Class not found.") { }
    }
}
