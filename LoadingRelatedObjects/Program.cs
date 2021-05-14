using System;

namespace LoadingRelatedObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            var seeder = new Seeder();
            seeder.Seed();
        }
    }
}
