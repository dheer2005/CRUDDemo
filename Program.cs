using CRUDDemo.Interfaces;
using CRUDDemo.Models;
using CRUDDemo.Services;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<IEmployeeService, EmployeeService>();

builder.Services.AddDbContext<EmployeeDbContext>
            (options => options.UseSqlServer(builder.Configuration.GetConnectionString("EmployeeCRUDDemoDb")));

// Add services to the container.
//builder.Services.AddControllers();
builder.Services.AddControllersWithViews();
    
builder.Services.AddRazorPages();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


//app.MapDefaultControllerRoute();
//app.MapRazorPages();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Employee}/{action=Index}/{id?}");

app.Run();
