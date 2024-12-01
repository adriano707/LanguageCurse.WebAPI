using LanguageCourse.Domain.Context.EnrollmentAggregate.Entities;
using LanguageCourse.Domain.Context.StudentAggregate.Enums;

namespace LanguageCourse.Domain.Context.StudentAggregate.Entities
{
    public class Student
    {
        private List<Enrollment> _enrollment;

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public GenreEnum Genre { get; private set; }
        public string CPF { get; private set; }
        public string Email { get; private set; }
        public IReadOnlyCollection<Enrollment> Enrollments => _enrollment;

        public Student()
        {
            
        }


        public Student(string name, GenreEnum genre, string cpf, string email)
        {
            Id = Guid.NewGuid();
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Genre = genre;
            CPF = cpf ?? throw new ArgumentNullException(nameof(cpf));
            Email = email ?? throw new ArgumentNullException(nameof(email));
            _enrollment = new List<Enrollment>();
        }

        public void UpdateStudent(string name, GenreEnum genre, string cpf, string email)
        {
            Name = name;
            Genre = genre;
            CPF = cpf;
            Email = email;
        }

        public void AddEnrollment(Enrollment enrollment)
        {
            if (enrollment == null)
            {
                _enrollment = new List<Enrollment>();  
            }
            
            _enrollment.Add(enrollment);  
        }
    }
}
