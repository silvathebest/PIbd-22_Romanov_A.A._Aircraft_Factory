using System;
using System.Collections.Generic;
using System.Text;

namespace AircraftFactoryFileImplement.Models
{
    /// <summary>
    /// Самолеты, изготавливаемые на заводе
    /// </summary>
    public class Plane
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public Dictionary<int, int> ProductComponents { get; set; }
    }
}
