using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASHEmployee.Data;
using ASHEmployee.Models;

namespace ASHEmployee.Repository
{
    public class SalaryTypeRepository : BaseRepository<SalaryType,EmpContext>
    {
        public SalaryTypeRepository(EmpContext context):base(context)
        {

        }
    }
}
