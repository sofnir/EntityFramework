using LoadingRelatedObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LoadingRelatedObjects
{
    public class Examples
    {
        PlutoContext Context = new PlutoContext();

        public void LazyLoading()
        {
            //throws exception - not supported in ef core
            var courses = Context.Courses.FirstOrDefault(c => c.Level == Course.CourseLevel.Advanced);

            foreach (var tag in courses.Tags)
                Console.WriteLine(tag.Name);
        }
        public void NPlusOneIssue()
        {
            //throws exception - not supported in ef core
            var courses = Context.Courses.ToList();

            foreach (var course in courses)
                Console.WriteLine("{0} by {1}", course.Name, course.Author.Name);
        }
        public void EagerLoading()
        {
            var courses = Context.Courses.Include(c => c.Author).ToList();

            foreach (var course in courses)
                Console.WriteLine("{0} by {1}", course.Name, course.Author.Name);
        }
    }
}
