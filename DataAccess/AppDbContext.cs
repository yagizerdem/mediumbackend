using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Models.Entity;
using System.Reflection.Emit;

namespace DataAccess
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Comment> Comments { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Comment>()
    .HasOne(e => e.AppUser)
    .WithMany(x => x.Comments)
    .OnDelete(DeleteBehavior.NoAction);

            base.OnModelCreating(builder);
            builder.Entity<Like>()
    .HasOne(e => e.AppUser)
    .WithMany(x => x.Likes)
    .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
