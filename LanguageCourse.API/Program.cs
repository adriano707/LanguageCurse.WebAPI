using Api.Configurations.Swagger;
using LanguageCourse.Data;
using LanguageCourse.Data.Repositories;
using LanguageCourse.Domain.Context.ClassAggregate.Services;
using LanguageCourse.Domain.Context.EnrollmentAggregate.Services;
using LanguageCourse.Domain.Context.StudentAggregate.Services;
using LanguageCourse.Domain.Repositories;
using Microsoft.AspNetCore.Authentication.Negotiate;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<LanguageCourseContext>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("app"));
});

// Add services to the container.
builder.Services.AddTransient<IClassService, ClassService>();
builder.Services.AddTransient<IEnrollmentService, EnrollmentService>();
builder.Services.AddTransient<IStudentService, StudentService>();

builder.Services.AddTransient<IRepository, Repository>();

builder.Services.AddVersionedSwagger();

//builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(NegotiateDefaults.AuthenticationScheme)
   .AddNegotiate();

builder.Services.AddAuthorization(options =>
{
    // By default, all incoming requests will be authorized according to the default policy.
    options.FallbackPolicy = options.DefaultPolicy;
});

//builder.Services.AddControllers()
//    .AddJsonOptions(options =>
//    {
//        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
//    });

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.WriteIndented = true; 
    });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
