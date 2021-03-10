using System;
using System.Collections.Generic;
using System.Text;

namespace AirCraftFactoryListImplement.Models
{
    /// <summary>
    /// Самолеты, изготавливаемые на заводе
    /// </summary>
    public class Plane
    {
        public int Id { get; set; }
        public string PlaneName { get; set; }
        public decimal Price { get; set; }
        public Dictionary<int, int> PlaneComponents { get; set; }
    }
}
