using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using CRUDDemo.Models;

namespace CRUDDemo.Areas.Identity.Data
{
    public class EmployeeDbContext : IdentityDbContext<IdentityUser>
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options) { }


        public DbSet<Employee> Employees { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

    }
}
