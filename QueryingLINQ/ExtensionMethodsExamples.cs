using QueryingLINQ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryingLINQ
{
    public class ExtensionMethodsExamples
    {
        PlutoContext Context = new PlutoContext();

        public void DisplayTagsFromBegginerCourses()
        {
            var courses = Context.Courses
                .Where(c => c.Level == Course.CourseLevel.Beginner)
                .OrderByDescending(c => c.Name)
                .ThenByDescending(c => c.Level)
                .Select(c => c.Tags);                

            foreach (var c in courses)
            {
                foreach (var tag in c)
                    Console.WriteLine(tag.Name);
            }

            Console.WriteLine("\n---\n");

            var tags = Context.Courses
                .Where(c => c.Level == Course.CourseLevel.Beginner)
                .OrderByDescending(c => c.Name)
                .ThenByDescending(c => c.Level)
                .SelectMany(c => c.Tags)
                .Distinct();

            foreach (var tag in tags)
                Console.WriteLine(tag.Name);
        }        
        public void Grouping()
        {
            var groups = Context.Courses.GroupBy(c => c.Level);

            foreach (var group in groups)
            {
                Console.WriteLine("Key: " + group.Key);

                foreach (var course in group)
                    Console.WriteLine("\t" + course.Name);
            }
        }
        public void Join()
        {
            var join = Context.Courses.Join(
                Context.Authors,
                c => c.AuthorId,
                a => a.Id,
                (course, author) => new
                {
                    CourseName = course.Name,
                    AuthorName = author.Name
                });

            foreach (var j in join)
            {
                Console.WriteLine("{0} - {1}", j.CourseName, j.AuthorName);
            }
        }
        public void GroupJoin()
        {
            //depreciated
            var group = Context.Authors.GroupJoin(
                Context.Courses,
                a => a.Id,
                c => c.AuthorId,
                (author, courses) => new
                {                    
                    AuthorName = author.Name,
                    Courses = courses.Count()
                });

            foreach (var g in group)
            {
                Console.WriteLine("{0} - {1}", g.AuthorName, g.Courses);
            }
        }
        public void CrossJoin()
        {
            var crossJoin = Context.Authors.SelectMany(a => Context.Courses, (author, course) => new
            {
                AuthorMame = author.Name,
                CourseName = course.Name
            });

            foreach (var cj in crossJoin)
            {
                Console.WriteLine("{0} - {1}", cj.AuthorMame, cj.CourseName);
            }
        }
        public void Partitioning()
        {
            var courses = Context.Courses.Skip(2).Take(2);

            foreach (var c in courses)
                Console.WriteLine(c.Name);
        }
        public void ElementOperators()
        {
            var firstCourse = Context.Courses.OrderBy(c => c.Level).FirstOrDefault(c => c.FullPrice > 100);
            var lastCourse = Context.Courses.OrderBy(c => c.Level).Last();
            var singleCourse = Context.Courses.SingleOrDefault(c => c.Level == Course.CourseLevel.Advanced);

            Console.WriteLine(firstCourse.Name);
            Console.WriteLine(lastCourse.Name);
            Console.WriteLine(singleCourse.Name);
        }
        public void Quantifying()
        {
            bool allAbove10Dolars = Context.Courses.All(c => c.FullPrice > 10);
            bool anyCourseIsBegginer = Context.Courses.Any(c => c.Level == Course.CourseLevel.Beginner);

            Console.WriteLine("allAbove10Dolars: {0}", allAbove10Dolars);
            Console.WriteLine("anyCourseIsBegginer: {0}", anyCourseIsBegginer);
        }
        public void Aggregating()
        {
            var count = Context.Courses.Where(c => c.Level == Course.CourseLevel.Beginner).Count();
            var mostExpensive = Context.Courses.Max(c => c.FullPrice);
            var lessCost = Context.Courses.Min(c => c.FullPrice);
            var averagePrice = Context.Courses.Average(c => c.FullPrice);

            Console.WriteLine("count: {0}", count);
            Console.WriteLine("mostExpensive: {0}", mostExpensive);
            Console.WriteLine("lessCost: {0}", lessCost);
            Console.WriteLine("averagePrice: {0}", averagePrice);
        }
    }
}
