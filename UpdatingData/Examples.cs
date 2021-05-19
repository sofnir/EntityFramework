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
    }
}
