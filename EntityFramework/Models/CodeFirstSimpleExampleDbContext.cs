using DatabaseFirstSimpleExample.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstSimpleExample.Models
{
    public class CodeFirstSimpleExampleDbContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-GUK2RJ2;Database=CodeFirstSimpleExample;Trusted_Connection=True;");
        }
    }
}
