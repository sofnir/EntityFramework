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

            modelBuilder.Entity<Course>().HasData(
                new Course
                {
                    Id = 1, Name = "C# Basics",
                    AuthorId = 1,
                    FullPrice = 49,
                    Description = "Description for C# Basics",
                    Level = Course.CourseLevel.Beginner
                },
                new Course
                {
                    Id = 2,
                    Name = "C# Intermediate",
                    AuthorId = 1,
                    FullPrice = 49,
                    Description = "Description for C# Intermediate",
                    Level = Course.CourseLevel.Intermediate
                },
                new Course
                {
                    Id = 3,
                    Name = "C# Advanced",
                    AuthorId = 1,
                    FullPrice = 69,
                    Description = "Description for C# Advanced",
                    Level = Course.CourseLevel.Advanced
                },
                new Course
                {
                    Id = 4,
                    Name = "Javascript: Understanding the Weird Parts",
                    AuthorId = 2,
                    FullPrice = 149,
                    Description = "Description for Javascript",
                    Level = Course.CourseLevel.Intermediate
                },
                new Course
                {
                    Id = 5,
                    Name = "Learn and Understand AngularJS",
                    AuthorId = 2,
                    FullPrice = 99,
                    Description = "Description for AngularJS",
                    Level = Course.CourseLevel.Intermediate
                },
                new Course
                {
                    Id = 6,
                    Name = "Learn and Understand NodeJS",
                    AuthorId = 2,
                    FullPrice = 149,
                    Description = "Description for NodeJS",
                    Level = Course.CourseLevel.Intermediate
                },
                new Course
                {
                    Id = 7,
                    Name = "Programming for Complete Beginners",
                    AuthorId = 3,
                    FullPrice = 45,
                    Description = "Description for Programming for Beginners",
                    Level = Course.CourseLevel.Beginner
                },
                new Course
                {
                    Id = 8,
                    Name = "A 16 Hour C# Course with Visual Studio 2013",
                    AuthorId = 4,
                    FullPrice = 150,
                    Description = "Description 16 Hour Course",
                    Level = Course.CourseLevel.Beginner
                },
                new Course
                {
                    Id = 9,
                    Name = "Learn JavaScript Through Visual Studio 2013",
                    AuthorId = 4,
                    FullPrice = 20,
                    Description = "Description Learn Javascript",
                    Level = Course.CourseLevel.Beginner
                }
            );            

            base.OnModelCreating(modelBuilder);
        }
    }
}
