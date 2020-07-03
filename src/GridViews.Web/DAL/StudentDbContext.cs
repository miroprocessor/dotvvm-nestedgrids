using Microsoft.EntityFrameworkCore;
using GridViews.Web.DAL.Entities;
namespace GridViews.Web.DAL
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Student> Students { get; set; }
    }
}
