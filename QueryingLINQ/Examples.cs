using QueryingLINQ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryingLINQ
{
    class Examples
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
    }
}
