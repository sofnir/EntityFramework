using QueryingLINQ.EntityConfigurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryingLINQ.Models
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
        public DbSet<CourseTag> CourseTags { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-GUK2RJ2;Database=Pluto_QueryingLINQ;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CourseConfiguration());

            modelBuilder.Entity<CourseTag>()
                .HasKey(ct => new { ct.CourseId, ct.TagId });

            modelBuilder.Entity<Tag>().HasData(
                new Tag { Id = 1, Name = "c#" },
                new Tag { Id = 2, Name = "angularjs" },
                new Tag { Id = 3, Name = "javascript" },
                new Tag { Id = 4, Name = "nodejs" },
                new Tag { Id = 5, Name = "oop" },
                new Tag { Id = 6, Name = "linq" }
            );

            modelBuilder.Entity<Author>().HasData(
                new Author { Id = 1, Name = "Mosh hamedani" },
                new Author { Id = 2, Name = "Anthony Alicea" },
                new Author { Id = 3, Name = "Eric Wise" },
                new Author { Id = 4, Name = "Tom Owsiak" },
                new Author { Id = 5, Name = "John Smith" }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
