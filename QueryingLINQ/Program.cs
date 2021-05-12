﻿using QueryingLINQ.Models;
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
            var examples = new Examples();

            examples.DisplayCSharpCourses();
        }

        static private void SeedData()
        {
            var seeder = new Seeder();
            seeder.Seed();
            //seeder.RemoveData();
        }
    }
}
