using ASHEmployee.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASHEmployee.Models
{
    public class SalaryType :IEntity
    {
        public int Id { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 2)]
        public string SalaryTypeDec { get; set; }

    }
}
