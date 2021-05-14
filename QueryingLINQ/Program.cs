using QueryingLINQ.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace QueryingLINQ
{
    class Program
    {        
        static void Main(string[] args)
        {
            ;
        }

        static private void SeedData()
        {
            var seeder = new Seeder();
            seeder.Seed();            
        }

        static private void DeferredExecution()
        {
            var context = new PlutoContext();
            
            //var courses = context.Courses.Where(c => c.IsBeginnerCourse == true); - this will return exception

            var courses = context.Courses.ToList().Where(c => c.IsBeginnerCourse == true);

            foreach (var c in courses)
                Console.WriteLine(c.Name);
        }

        static private void QueryableExplained()
        {
            var context = new PlutoContext();

            //using IQueryable - call sql select with where level as part of the method
            IQueryable<Course> courses = context.Courses;
            var filtered = courses.Where(c => c.Level == Course.CourseLevel.Beginner);

            foreach (var course in filtered)
                Console.WriteLine(course.Name);

            //using IEnumerable - call sql select without where (get all objects)
            IEnumerable<Course> coursesesIEnumerable = context.Courses;
            var filteredIEnumerable = coursesesIEnumerable.Where(c => c.Level == Course.CourseLevel.Beginner); //call sql select with where level as part of the method 

            foreach (var courseIEnumerable in filteredIEnumerable)
                Console.WriteLine(courseIEnumerable.Name);
        }
    }
}
