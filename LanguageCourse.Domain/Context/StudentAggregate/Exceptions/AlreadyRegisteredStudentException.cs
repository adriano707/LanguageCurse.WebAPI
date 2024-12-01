namespace LanguageCourse.Domain.Context.StudentAggregate.Exceptions
{
    public class AlreadyRegisteredStudentException : Exception
    {
        public AlreadyRegisteredStudentException(string cpf) : base($"There is already a student with the provided CPF: {cpf}")
        {
            
        }
    }
}
