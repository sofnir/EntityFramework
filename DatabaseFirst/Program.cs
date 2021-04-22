using DatabaseFirst.Models;
using System;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DatabaseFirst
{
    class Program
    {
        static PlutoContext DbContext;

        static async Task Main(string[] args)
        {
            DbContext = new PlutoContext();
            
            await CallStoredProcedureAsync();
        }

        static private async Task CallStoredProcedureAsync()
        {
            var courses = await DbContext.Courses
                .FromSqlRaw("GetCourses")
                .ToListAsync();

            courses?.ForEach(q => Console.WriteLine(q.Description));
        }
    }
}
