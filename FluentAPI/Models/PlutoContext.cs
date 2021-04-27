using FluentAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Models
{
    public class PlutoContext : DbContext
    {        
        public PlutoContext()
        {
        }

        public PlutoContext(DbContextOptions<PlutoContext> options)
            : base(options)
        {
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Tag> Tags { get; set; }        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-GUK2RJ2;Database=Pluto_FluentAPI;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>()
                .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(255);

            modelBuilder.Entity<Course>()
                .Property(c => c.Description)
                .IsRequired()
                .HasMaxLength(2000);

            modelBuilder.Entity<Course>()
                .HasOne(c => c.Author)
                .WithMany(a => a.Courses)
                .HasForeignKey(c => c.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Course>()
                .HasMany(c => c.Tags)
                .WithMany(t => t.Courses)
                .UsingEntity(join => join.ToTable("CourseTags"));

            modelBuilder.Entity<Course>()
                .HasOne(c => c.Cover)
                .WithOne(c => c.Course)
                .HasForeignKey<Cover>(c => c.CourseId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
