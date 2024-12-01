﻿using LanguageCourse.Domain.Context.StudentAggregate.Entities;
using LanguageCourse.Domain.Context.StudentAggregate.Enums;

namespace LanguageCourse.Domain.Context.StudentAggregate.Services
{
    public interface IStudentService
    {
        Task<Student> GetStudentById(Guid id);
        Task<List<Student>> GetAllStudents();
        Task<Student> CreateStudent(string name, GenreEnum genre, string cpf, string email, List<Guid> classIds);
        Task<Student> UpdateStudent(Guid id, string name, GenreEnum genre, string cpf, string email);
        Task DeletStudent(Guid id);
    }
}
