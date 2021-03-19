using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ASHEmployee.Models;

namespace ASHEmployee.Data
{
    public class EmpContext : DbContext
    {
        private Func<object, object> p;

        public EmpContext (DbContextOptions<EmpContext> options)
            : base(options)
        {
        }

        public EmpContext(Func<object, object> p)
        {
            this.p = p;
        }

        public DbSet<Employee> Employee { get; set; }
        public DbSet<SalaryType> SalaryType { get; set; }
    }
    }

