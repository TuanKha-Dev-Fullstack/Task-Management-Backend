using Microsoft.EntityFrameworkCore;
using Task_Management_Backend.Data;
using Task_Management_Backend.Repositories.Category.Interfaces;
using Task_Management_Backend.Repositories.Category.Queries;
using Task_Management_Backend.Repositories.Task.Interfaces;
using Task_Management_Backend.Repositories.Task.Queries;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Add DbContext
builder.Services.AddDbContext<AppDbContext>(option => 
    option.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
// Add services
builder.Services.AddScoped<ITask, QTask>();
builder.Services.AddScoped<ICategory, QCategory>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();