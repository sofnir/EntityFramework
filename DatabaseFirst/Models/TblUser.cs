﻿using System;
using System.Collections.Generic;

#nullable disable

namespace DatabaseFirst.Models
{
    public partial class TblUser
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public int Password { get; set; }
    }
}
