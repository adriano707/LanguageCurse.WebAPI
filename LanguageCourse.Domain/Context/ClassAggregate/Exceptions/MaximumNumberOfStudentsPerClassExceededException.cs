namespace LanguageCourse.Domain.Context.ClassAggregate.Exceptions
{
    public class MaximumNumberOfStudentsPerClassExceededException : Exception
    {
        public MaximumNumberOfStudentsPerClassExceededException() : base("A class cannot have more than 5 students.")
        {
            
        }
    }
}
