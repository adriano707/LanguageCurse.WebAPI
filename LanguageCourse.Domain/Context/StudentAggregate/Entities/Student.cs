﻿using System;
using System.Net;
using LanguageCourse.Domain.Context.ClassAggregate.Entities;
using LanguageCourse.Domain.Context.StudentAggregate.Enums;

namespace LanguageCourse.Domain.Context.StudentAggregate.Entities
{
    public class Student
    {
        private List<Class> _class;

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public GenreEnum Genre { get; private set; }
        public string CPF { get; private set; }
        public string Email { get; private set; }
        public IReadOnlyCollection<Class> Classes => _class;


        public Student(string name, GenreEnum genre, string cpf, string email, IReadOnlyCollection<Class> classes)
        {
            Id = Guid.NewGuid();
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Genre = genre;
            CPF = cpf ?? throw new ArgumentNullException(nameof(cpf));
            Email = email ?? throw new ArgumentNullException(nameof(email));
            _class = new List<Class>();
        }
    }
}