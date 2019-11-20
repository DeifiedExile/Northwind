using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Northwind.Models
{
    public class Region
    {
        public string RegionDescription { get; set; }
        public int RegionId { get; set; }
        public ICollection<Territory> Territories { get; set; }
    }
}
