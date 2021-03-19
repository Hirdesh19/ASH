using Microsoft.VisualStudio.TestTools.UnitTesting;
using ASHEmployee.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ASHEmployee.Repository;
using ASHEmployee.Controllers;
using System.Configuration;
using System;
using Microsoft.AspNetCore.Mvc;
using ASHEmployee.Models;
using System.Linq;

namespace ASHEmployee.Test
{
    [TestClass]
    public class ASHTest
    {
        private EmpContext _context;
        int id;

        public ASHTest()
        {
            InitContext();
        }

        [TestMethod]
        public async Task Emp_Get_by_id()
        {
            EmployeeRepository empRepo = new EmployeeRepository(_context);
            EmployeeController con = new EmployeeController(empRepo);
            var m = await con.Get(4);
            Assert.AreEqual(m.Value.Id, 4);
        }

        [TestMethod]
        public async Task Emp_Get_All()
        {
            EmployeeRepository empRepo = new EmployeeRepository(_context);
            EmployeeController con = new EmployeeController(empRepo);
            var m = await con.Get();
            Assert.IsNotNull(m.Value);
        }

        [TestMethod]
        public async Task Emp_Create()
        {
            EmployeeRepository empRepo = new EmployeeRepository(_context);
            EmployeeController con = new EmployeeController(empRepo);
            Employee emp = new Employee
            {
                FirstName = "Tom",
                LastName = "Alter",
                Address1 = "124 abc St.",
                SalaryType = 2,
                Salary = Convert.ToDecimal(80.00),
                CanHaveExpenses = true,
                MaxExpenseAmount = Convert.ToDecimal(900.00),
            };
            var m = await con.Post(emp);
            Assert.AreEqual(((Employee)((ObjectResult)m.Result).Value).FirstName, emp.FirstName);
        }

        [TestMethod]
        public async Task Emp_Delete()
        {
            EmployeeRepository empRepo = new EmployeeRepository(_context);
            EmployeeController con = new EmployeeController(empRepo);
            Employee lastEmp =_context.Employee.OrderByDescending(p => p.Id).FirstOrDefault();
            var m = await con.Delete(lastEmp.Id);
            Assert.IsNull(m.Value);
        }

        public void InitContext()
        {
            var builder = new DbContextOptionsBuilder<EmpContext>()
                .UseSqlServer("Server=localhost;Database=ASH;Trusted_Connection=True;MultipleActiveResultSets=true");

            _context = new EmpContext(builder.Options);
        }
    }
}
