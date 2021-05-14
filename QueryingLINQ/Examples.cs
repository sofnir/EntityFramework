using QueryingLINQ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryingLINQ
{
    class SyntaxExamples
    {
        PlutoContext Context = new PlutoContext();        

        public void DisplayCSharpCourses()
        {
            // LINQ syntax
            var query =
                from c in Context.Courses
                where c.Name.Contains("c#")
                orderby c.Name
                select c;

            foreach (var course in query)
                Console.WriteLine(course.Name);

            // Extension methods
            var courses = Context.Courses
                .Where(c => c.Name.Contains("c#"))
                .OrderBy(c => c.Name);

            foreach (var course in courses)
                Console.WriteLine(course.Name);
        }        
        public void Restriction()
        {            
            var query =
                from c in Context.Courses
                where c.Level == Course.CourseLevel.Beginner && c.Author.Name.Contains("Mosh")
                select c;

            foreach (var course in query)
                Console.WriteLine(course.Name);
        }
        public void Ordering()
        {
            var query =
                from c in Context.Courses
                where c.Level == Course.CourseLevel.Beginner
                orderby c.Level descending, c.Name
                select c;

            foreach (var course in query)
                Console.WriteLine(course.Name);
        }
        public void Projection()
        {
            var query =
                from c in Context.Courses
                where c.Level == Course.CourseLevel.Beginner
                orderby c.Level descending, c.Name
                select new { Name = c.Name, Author = c.Author.Name };

            foreach (var course in query)
                Console.WriteLine(course.Name);
        }
        public void Grouping()
        {
            var query =
                from c in Context.Courses.AsEnumerable()
                group c by c.Level
                into g
                select g;

            foreach (var group in query)
            {                
                Console.WriteLine("{0} ({1})", group.Key, group.Count());

                foreach (var course in group)
                    Console.WriteLine("\t{0}", course.Name);
            }
        }
        public void InnerJoin()
        {            
            var query =
                from c in Context.Courses                
                select new { CourseName = c.Name, AuthorName = c.Author.Name };

            var queryWithoutNavigationProperties =
                from c in Context.Courses
                join a in Context.Authors on c.AuthorId equals a.Id
                select new { CourseName = c.Name, AuthorName = a.Name };

            foreach (var c in query)
                Console.WriteLine("{0} ({1})", c.CourseName, c.AuthorName);

            foreach (var c in queryWithoutNavigationProperties)
                Console.WriteLine("{0} ({1})", c.CourseName, c.AuthorName);
        }
        public void CrossJoin()
        {
            var query =
                from a in Context.Authors
                from c in Context.Courses                
                select new { AuthorName = a.Name, CourseName = c.Name };

            foreach (var x in query)
                Console.WriteLine("{0} - {1}", x.AuthorName, x.CourseName);        
        }
    }
}
