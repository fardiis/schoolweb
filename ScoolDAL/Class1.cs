using Microsoft.EntityFrameworkCore;
using System;

namespace ScoolDAL
{
    public class SchoolContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=.;initial catalog=schooll;integrated security=true");
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Student> Students { get; set; }
    }
}
