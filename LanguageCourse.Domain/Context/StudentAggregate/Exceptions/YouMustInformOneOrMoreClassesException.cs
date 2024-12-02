namespace LanguageCourse.Domain.Context.StudentAggregate.Exceptions
{
    public class YouMustInformOneOrMoreClassesException : Exception
    {
        public YouMustInformOneOrMoreClassesException() : base("You must inform one or more classes")
        {
            
        }
    }
}
