using EmployeeData.Services;
using Microsoft.EntityFrameworkCore;
using EmployeeData;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddTransient(typeof(IEmployeeData),typeof(SqlEmployee));
builder.Services.AddTransient(typeof(IDeptData), typeof(SqlDept));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<EmployeeDbContext>();

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
