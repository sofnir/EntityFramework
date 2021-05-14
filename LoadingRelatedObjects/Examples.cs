using LoadingRelatedObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
