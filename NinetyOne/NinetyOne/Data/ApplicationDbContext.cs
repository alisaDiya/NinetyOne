using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NinetyOne.Models;

namespace NinetyOne.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Person> People { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Person>(entity =>
            {
                entity.ToTable("People");       
                entity.HasKey(p => p.Id);      
                entity.Property(p => p.FirstName).IsRequired();
                entity.Property(p => p.Score).IsRequired();
            });
        }
    }
}