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
        public void ExplicitLoading()
        {
            var author = Context.Authors.Single(a => a.Name.Contains("Mosh"));

            // MSDN way
            Context.Entry(author).Collection(a => a.Courses).Query().Where(c => c.FullPrice == 49).Load();

            // custom way
            Context.Courses.Where(c => c.AuthorId == author.Id && c.FullPrice == 49).Load();

            foreach (var course in author.Courses)
                Console.WriteLine("{0}", course.Name);

            //load multiple authors
            var authors = Context.Authors.ToList();
            var authorIds = authors.Select(a => a.Id);

            Context.Courses.Where(c => authorIds.Contains(c.AuthorId) && c.FullPrice == 0).Load();
        }
    }
}
