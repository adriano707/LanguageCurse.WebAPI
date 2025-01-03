﻿// <auto-generated />
using System;
using LanguageCourse.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LanguageCourse.Data.Migrations
{
    [DbContext(typeof(LanguageCourseContext))]
    [Migration("20241201122149_AllowNullInRegistrationNumber")]
    partial class AllowNullInRegistrationNumber
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LanguageCourse.Domain.Context.ClassAggregate.Entities.Class", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(250)");

                    b.HasKey("Id");

                    b.ToTable("Class");
                });

            modelBuilder.Entity("LanguageCourse.Domain.Context.EnrollmentAggregate.Entities.Enrollment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ClassId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Number")
                        .HasColumnType("varchar(250)");

                    b.Property<Guid>("StudentId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ClassId");

                    b.HasIndex("StudentId");

                    b.ToTable("Enrollment");
                });

            modelBuilder.Entity("LanguageCourse.Domain.Context.StudentAggregate.Entities.Student", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("varchar(11)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(250)");

                    b.Property<int>("Genre")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(250)");

                    b.HasKey("Id");

                    b.ToTable("Student");
                });

            modelBuilder.Entity("LanguageCourse.Domain.Context.EnrollmentAggregate.Entities.Enrollment", b =>
                {
                    b.HasOne("LanguageCourse.Domain.Context.ClassAggregate.Entities.Class", "Class")
                        .WithMany("Enrollments")
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LanguageCourse.Domain.Context.StudentAggregate.Entities.Student", "Student")
                        .WithMany("Enrollments")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Class");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("LanguageCourse.Domain.Context.ClassAggregate.Entities.Class", b =>
                {
                    b.Navigation("Enrollments");
                });

            modelBuilder.Entity("LanguageCourse.Domain.Context.StudentAggregate.Entities.Student", b =>
                {
                    b.Navigation("Enrollments");
                });
#pragma warning restore 612, 618
        }
    }
}
