using LanguageCourse.Domain.Context.EnrollmentAggregate.Entities;
using LanguageCourse.Domain.Context.StudentAggregate.Enums;
using System.Text.Json.Serialization;

namespace LanguageCourse.Domain.Context.StudentAggregate.Entities
{
    public class Student
    {
        private List<Enrollment> _enrollments;

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public GenreEnum Genre { get; private set; }
        public string CPF { get; private set; }
        public string Email { get; private set; }

        [JsonIgnore]
        public IReadOnlyCollection<Enrollment> Enrollments => _enrollments.AsReadOnly();

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
            _enrollments = new List<Enrollment>();
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
                _enrollments = new List<Enrollment>();  
            }
            
            _enrollments.Add(enrollment);  
        }
    }
}
