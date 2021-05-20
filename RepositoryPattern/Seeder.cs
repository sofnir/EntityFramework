using RepositoryPattern.Core.Domain;
using RepositoryPattern.Persistence;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern
{
    public class Seeder
    {        
        private readonly Dictionary<string, Tag> Tags = new Dictionary<string, Tag>
        {
            {"c#", new Tag { Name = "c#"}},
            {"angularjs", new Tag { Name = "angularjs"}},
            {"javascript", new Tag { Name = "javascript"}},
            {"nodejs", new Tag { Name = "nodejs"}},
            {"oop", new Tag { Name = "oop"}},
            {"linq", new Tag { Name = "linq"}},
        };
        private readonly Dictionary<string, Author> Authors = new Dictionary<string, Author>
        {
            { "Mosh Hamedani", new Author { Name = "Mosh Hamedani" }},
            { "Anthony Alicea", new Author { Name = "Anthony Alicea" }},
            { "Eric Wise", new Author { Name = "Eric Wise" }},
            { "Tom Owsiak", new Author { Name = "Tom Owsiak" }},
            { "John Smith", new Author { Name = "John Smith" }}
        };

        private List<Course> Courses;

        PlutoContext context;

        public Seeder()
        {
            CreateCourses();

            context = new PlutoContext();
        }

        public void RemoveData()
        {
            var existingTags = context.Tags.ToList();
            var existingAuthors = context.Authors.ToList();
            var existingCourses = context.Courses.ToList();

            foreach (var course in existingCourses)
            {
                context.Courses.Remove(course);
            }

            foreach (var tag in existingTags)
            {
                context.Tags.Remove(tag);
            }

            foreach (var author in existingAuthors)
            {
                context.Authors.Remove(author);
            }

            context.SaveChanges();
        }

        public void Seed()
        {
            SeedTags();
            SeedAuthors();
            SeedCourses();

            context.SaveChanges();
        }
                
        private void SeedTags()
        {            
            foreach (var tag in Tags.Values)
            {
                var existingTag = context.Tags.FirstOrDefault(q => q.Name == tag.Name);
                if (existingTag == null)
                {
                    context.Tags.Add(tag);
                }
            }
        }
        private void SeedAuthors()
        {            
            foreach (var author in Authors.Values)
            {
                var existingAuthor = context.Authors.FirstOrDefault(q => q.Name == author.Name);
                if (existingAuthor == null)
                {
                    context.Authors.Add(author);
                }
            }
        }
        private void SeedCourses()
        {
            foreach (var course in Courses)
            {
                var existingCourse = context.Courses.FirstOrDefault(q => q.Name == course.Name);
                if (existingCourse == null)
                {
                    context.Courses.Add(course);
                }
            }
        }

        private void CreateCourses()
        {
            Courses = new List<Course>
            {
                new Course
                {
                    Name = "C# Basics",
                    FullPrice = 49,
                    Description = "Description for C# Basics",
                    Level = Course.CourseLevel.Beginner,
                    Author = Authors["Mosh Hamedani"],
                    Tags = new Collection<Tag>()
                    {
                        Tags["c#"]
                    }
                },
                new Course
                {
                    Name = "C# Intermediate",
                    FullPrice = 49,
                    Description = "Description for C# Intermediate",
                    Level = Course.CourseLevel.Intermediate,
                    Author = Authors["Anthony Alicea"],
                    Tags = new Collection<Tag>()
                    {
                        Tags["c#"],
                        Tags["oop"]
                    }
                },
                new Course
                {
                    Name = "C# Advanced",
                    FullPrice = 69,
                    Description = "Description for C# Advanced",
                    Level = Course.CourseLevel.Advanced,
                    Author = Authors["Mosh Hamedani"],
                    Tags = new Collection<Tag>()
                    {
                        Tags["c#"]
                    }
                },
                new Course
                {
                    Name = "Javascript: Understanding the Weird Parts",
                    FullPrice = 149,
                    Description = "Description for Javascript",
                    Level = Course.CourseLevel.Intermediate,
                    Author = Authors["Anthony Alicea"],
                    Tags = new Collection<Tag>()
                    {
                        Tags["javascript"]
                    }
                },
                new Course
                {
                    Name = "Learn and Understand AngularJS",
                    FullPrice = 99,
                    Description = "Description for AngularJS",
                    Level = Course.CourseLevel.Intermediate,
                    Author = Authors["Anthony Alicea"],
                    Tags = new Collection<Tag>()
                    {
                        Tags["angularjs"]
                    }
                },
                new Course
                {
                    Name = "Learn and Understand NodeJS",
                    FullPrice = 149,
                    Description = "Description for NodeJS",
                    Level = Course.CourseLevel.Intermediate,
                    Author = Authors["Anthony Alicea"],
                    Tags = new Collection<Tag>()
                    {
                        Tags["nodejs"]
                    }
                },
                new Course
                {
                    Name = "Programming for Complete Beginners",
                    FullPrice = 45,
                    Description = "Description for Programming for Beginners",
                    Level = Course.CourseLevel.Beginner,
                    Author = Authors["Eric Wise"],
                    Tags = new Collection<Tag>()
                    {
                        Tags["c#"]
                    }
                },
                new Course
                {
                    Name = "A 16 Hour C# Course with Visual Studio 2013",
                    FullPrice = 150,
                    Description = "Description 16 Hour Course",
                    Level = Course.CourseLevel.Beginner,
                    Author = Authors["Tom Owsiak"],
                    Tags = new Collection<Tag>()
                    {
                        Tags["c#"]
                    }
                },
                new Course
                {
                    Name = "Learn JavaScript Through Visual Studio 2013",
                    FullPrice = 20,
                    Description = "Description Learn Javascript",
                    Level = Course.CourseLevel.Beginner,
                    Author = Authors["Tom Owsiak"],
                    Tags = new Collection<Tag>()
                    {
                        Tags["javascript"]
                    }
                }
            };
        }
    }
}
