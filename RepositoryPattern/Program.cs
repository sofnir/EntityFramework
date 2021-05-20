using System;

namespace RepositoryPattern
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
