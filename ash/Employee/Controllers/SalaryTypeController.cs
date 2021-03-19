using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASHEmployee.Models;
using ASHEmployee.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASHEmployee.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SalaryTypeController : BaseController<SalaryType,SalaryTypeRepository> 
    {
        public SalaryTypeController(SalaryTypeRepository repo): base(repo)
        { 
        }
    }
}
