using Microsoft.EntityFrameworkCore;
using RazorPageCurdDemo.Models;

namespace RazorPageCurdDemo.Data
{
    public class ApplicationDBContext : DbContext
    {
        public DbSet<EmpModel> EmpDetails { get; set; }

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options):base(options)
        {

        }
    }
}
