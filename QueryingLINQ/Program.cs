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
    }
}
