using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
using SoniaGhandiAPI.DataLayer;
using SoniaGhandiAPI.Models;
using SoniaGhandiAPI.Repository;

var builder = WebApplication.CreateBuilder(args);

// Register the Swagger generator, defining one or more Swagger documents
builder.Services.AddSwaggerGen(c =>
{
   c.SwaggerDoc("v1", new OpenApiInfo
   {
       Version = "v1",
       Title = "http",
       Description = "A simple example ASP.NET Core Web API"
   });
});
// Add services to the container.
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddControllers();
builder.Services.AddDbContext<SMSContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IRepository<TeacherViewModel>, TeacherRepository>();

//builder.Services.AddScoped<StudentRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
// Enable middleware to serve generated Swagger as a JSON endpoint
app.UseSwagger();

// Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
// specifying the Swagger JSON endpoint.
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "http");
    c.RoutePrefix = string.Empty; // To serve the Swagger UI at the app's root (http://localhost:<port>/), set the RoutePrefix property to an empty string
});

app.UseAuthorization();

app.MapControllers();

app.Run();
