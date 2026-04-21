using Microsoft.EntityFrameworkCore;
using OnlineShool.Application;
using OnlineShool.Domain;
using OnlineShool.Infrastructura.Instructions;
using OnlineShool.Infrastructura.Sql_Server;
using OnlineShool.Infrastructura.Sql_Server.Realization;
using System.Data.Common;

string connectionString = "";




var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Add services to the container.S

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContextFactory<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddScoped<ICommentDomain, ManagerComment>();
builder.Services.AddScoped<ICourseDomain, ManagerCourse>();
builder.Services.AddScoped<IHomeWorkDomain, ManagerHomework>();
builder.Services.AddScoped<ILessonDomain, ManagerLesson>();
builder.Services.AddScoped<IRoleDomain, ManagerRole>();
builder.Services.AddScoped<IUserDomain, ManagerUser>();
builder.Services.AddScoped<IVideoDomain, ManagerVideo>();


builder.Services.AddScoped<IComment, CommentManager>();
builder.Services.AddScoped<ICourseRepository, CourseManager>();
builder.Services.AddScoped<IHomeWork, HomeworkManager>();
builder.Services.AddScoped<ILessonRepository, LessonManager>();
builder.Services.AddScoped<IRoleRepository, RoleManager>();
builder.Services.AddScoped<IUserRepository, UserManager>();
builder.Services.AddScoped<IVideo, VideoManager>();
builder.Services.AddScoped<IImplementingHomeWork, ImplementingHomeworkManager>();
builder.Services.AddScoped<IImplementingLesson, ImplementingLessonManager>();
builder.Services.AddScoped<ILinksLessonsHomeWork, LinksLessonsHomeworkManager>();
builder.Services.AddScoped<ILinksVideoLesson, LinksVideoLessonManager>();
builder.Services.AddScoped<IPurchasedCourse, PurchasedCourseManager>();
builder.Services.AddScoped<IStatusHomeWork, StatusHomeworkManager>();
builder.Services.AddScoped<IStatusLesson, StatusLessonManager>();



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
