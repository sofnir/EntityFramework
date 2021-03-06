using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadingRelatedObjects.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }                
        public CourseLevel Level { get; set; }
        public float FullPrice { get; set; }
        public Author Author { get; set; }
        public int AuthorId { get; set; }
        public IList<Tag> Tags { get; set; }
        public int CoverId { get; set; }
        public Cover Cover { get; set; }

        public enum CourseLevel
        {
            Beginner = 1,
            Intermediate = 2,
            Advanced = 3
        }

        public bool IsBeginnerCourse
        {
            get { return Level == CourseLevel.Beginner; }
        }
    }
}
