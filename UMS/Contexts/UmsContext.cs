using Microsoft.EntityFrameworkCore;
using UMS.Models;

namespace UMS.Contexts
{
    public class UmsContext : DbContext
    {
        public UmsContext(DbContextOptions<UmsContext> opt) : base(opt)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Role> Roles { get; set; }

    }
}