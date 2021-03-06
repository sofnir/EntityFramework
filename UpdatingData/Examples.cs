using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpdatingData.Models;

namespace UpdatingData
{
    public static class Examples
    {        
        public static void AddCourseWithAuthorObject()
        {
            using (var context = new PlutoContext())
            {
                var author = context.Authors.Single(q => q.Id == 1);
                var courseWithAuthorObject = new Course
                {
                    Name = "Course with author object",
                    Description = "Descrpition",
                    FullPrice = 19.95f,
                    Level = Course.CourseLevel.Beginner,
                    Author = author
                };

                context.Add(courseWithAuthorObject);
                context.SaveChanges();
            }
        }
        public static void AddCourseWithAuthorId()
        {
            using (var context = new PlutoContext())
            {
                var courseWithAuthorId = new Course
                {
                    Name = "Course with author id",
                    Description = "Descrpition",
                    FullPrice = 19.95f,
                    Level = Course.CourseLevel.Beginner,
                    AuthorId = 1
                };

                context.Add(courseWithAuthorId);
                context.SaveChanges();
            }            
        }
        public static void AddCourseWithAttachedAuthor()
        {
            using (var context = new PlutoContext())
            {
                var newAuthor = new Author() { Id = 1, Name = "Mosh Hamedani" };
                context.Authors.Attach(newAuthor);
                var courseWithAttachedAuthor = new Course
                {
                    Name = "Course With Attached Author",
                    Description = "Descrpition",
                    FullPrice = 19.95f,
                    Level = Course.CourseLevel.Beginner,
                    Author = newAuthor
                };

                context.Courses.Add(courseWithAttachedAuthor);
                context.SaveChanges();
            }
        }

        public static void UpdateCourse()
        {
            using (var context = new PlutoContext())
            {
                var course = context.Courses.Find(4);

                course.Name = "New Name";
                course.AuthorId = 2;

                context.SaveChanges();
            }
        }

        public static void RemoveCourse()
        {
            using (var context = new PlutoContext())
            {
                var course = context.Courses.Find(6);

                context.Courses.Remove(course);

                context.SaveChanges();
            }
        }
        public static void RemoveAuthor()
        {
            using (var context = new PlutoContext())
            {
                var author = context.Authors.Include(a => a.Courses).Single(a => a.Id == 2);

                context.Courses.RemoveRange(author.Courses);
                context.Authors.Remove(author);

                context.SaveChanges();
            }
        }

        public static void ChangeTracker()
        {
            using (var context = new PlutoContext())
            {
                context.Authors.Add(new Author { Name = "New author" });

                var author = context.Authors.Find(3);
                author.Name = "Updated";

                var authorToRemove = context.Authors.Find(4);
                context.Authors.Remove(authorToRemove);

                var entries = context.ChangeTracker.Entries();

                foreach (var entry in entries)
                {
                    entry.Reload();
                    Console.WriteLine(entry.State);
                }
            }
        }
    }
}
