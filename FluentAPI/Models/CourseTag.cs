﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentAPI.Models
{
    public class CourseTag
    {
        public int CourseId { get; set; }
        public Course Course { get; set; }

        public int TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
