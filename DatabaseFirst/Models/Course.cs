using System;
using System.Collections.Generic;

#nullable disable

namespace DatabaseFirst.Models
{
    public partial class Course
    {
        public Course()
        {
            CourseSections = new HashSet<CourseSection>();
            CourseTags = new HashSet<CourseTag>();
        }

        public int CourseId { get; set; }
        public int AuthorId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public short FullPrice { get; set; }        
        public CourseLevel Level { get; set; }

        public virtual Author Author { get; set; }
        public virtual ICollection<CourseSection> CourseSections { get; set; }
        public virtual ICollection<CourseTag> CourseTags { get; set; }

        public enum CourseLevel
        {
            Begginer,
            Intermediate,
            Advanced
        }
    }
}
