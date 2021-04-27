using System;
using System.Collections.Generic;

#nullable disable

namespace CodeFirstSimpleExample.Models
{
    public partial class Post
    {
        public int Id { get; set; }
        public DateTime DatePublished { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
    }
}
