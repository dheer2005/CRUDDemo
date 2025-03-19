using CRUDDemo.Interfaces;
using CRUDDemo.Services;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;
using CRUDDemo.Areas.Identity.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using NToastNotify;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<IEmployeeService, EmployeeService>();

//builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
//    .AddCookie(options =>
//    {
//        options.Cookie.Name = "MyAppCookie";
//        options.LoginPath = "/Areas/Identity/Pages/Account/Login";
//    });

builder.Services.AddDbContext<EmployeeDbContext>
            (options => options.UseSqlServer(builder.Configuration.GetConnectionString("EmployeeCRUDDemoDb")));

builder.Services.AddDefaultIdentity<IdentityUser>().AddEntityFrameworkStores<EmployeeDbContext>();
builder.Services.AddMvc();

// Add services to the container.
//builder.Services.AddControllers();
builder.Services.AddControllersWithViews().AddNToastNotifyToastr(new ToastrOptions()
{
    ProgressBar = false,
    PositionClass = ToastPositions.BottomCenter
});

builder.Services.AddRazorPages();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/Employee/Error");
    app.UseHsts();
}

// Ensure HTTPS redirection comes before routing
app.UseHttpsRedirection();

// Enable serving static files (CSS, JS, images, etc.)
app.UseStaticFiles();

app.UseRouting();

// Authentication & Authorization should be added before endpoints
app.UseAuthentication();
app.UseAuthorization();

// Ensure NToastNotify is used before endpoint mapping
app.UseNToastNotify();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Employee}/{action=Index}/{id?}");

    endpoints.MapRazorPages();
});

app.Run();
