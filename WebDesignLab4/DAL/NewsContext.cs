using Microsoft.EntityFrameworkCore;
using WebDesignLab4.Models;

namespace WebDesignLab4.DAL
{
    public class NewsContext : DbContext
    {
        public NewsContext() { }

        public NewsContext(DbContextOptions options) : base(options) { Database.EnsureCreated(); }

        public DbSet<News> News { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=ViewsWithNews;Integrated Security=True;Trusted_Connection=True;");
        }
    }
}