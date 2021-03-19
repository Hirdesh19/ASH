using ASHEmployee.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASHEmployee.Models
{
    public class Employee : IEntity
    {
        public Employee id;

        public int Id { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        
        [StringLength(100)]
        public string Address1 { get; set; }

        
        
        public int SalaryType { get; set; }

        [Required]
        [RegularExpression(@"^\d+\.\d{0,2}$")]
        [Range(0, 999.99)]
        public decimal Salary { get; set; }

        [Required]
        public bool CanHaveExpenses { get; set; }

        [Required]
        [RegularExpression(@"^\d+\.\d{0,2}$")]
        [Range(0, 99999999.99)]
        public decimal MaxExpenseAmount { get; set; }
        
        public static explicit operator Employee(ActionResult v)
        {
            throw new NotImplementedException();
        }
    }
}
