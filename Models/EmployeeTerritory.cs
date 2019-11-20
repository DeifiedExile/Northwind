using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Northwind.Models
{
    public class EmployeeTerritory
    {
        [Key, Column(Order = 0)]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        [Key, Column(Order = 1)]
        public int TerritoryId { get; set; }
        public Territory Territory { get; set; }
    }
}
