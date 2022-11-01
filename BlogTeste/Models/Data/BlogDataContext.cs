using Microsoft.EntityFrameworkCore;

namespace BlogTeste.Models.Data
{
    public class BlogDataContext : DbContext
    {
        public DbSet<Category>? Categories { get; set; }
        public DbSet<Post>? Posts { get; set; }
        public DbSet<User>? Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            {options.UseSqlServer("data source=ANAC_NOTEBOOK;initial catalog=Blog;trusted_connection=true;Trust Server Certificate=true");
            
            }
        

    }
}