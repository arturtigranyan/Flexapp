using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlexappTestSolution.Models
{
    public class FaDbContext : DbContext
    {
        public FaDbContext(DbContextOptions<FaDbContext> options) : base(options) { }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Department> Department { get; set; }
    }
}
