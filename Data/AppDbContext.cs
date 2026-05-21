using Microsoft.EntityFrameworkCore;
using PAPPUCHARTWEBAPIS.Models;


namespace PAPPUCHARTWEBAPIS.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(
            DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<UserModel> Users { get; set; }
    }
}
