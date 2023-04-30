using AngularAuthAPI.Context.EntityConfigurations;
using AngularAuthAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace AngularAuthAPI.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
            
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new UserEntityTypeConfiguration().Configure(modelBuilder.Entity<User>());

        }

    }
}
