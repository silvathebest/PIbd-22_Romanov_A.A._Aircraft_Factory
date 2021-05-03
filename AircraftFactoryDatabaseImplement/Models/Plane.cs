using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AircraftFactoryDatabaseImplement.Models
{
    /// <summary>
    /// Самолеты, изготавливаемые на заводе
    /// </summary>
    public class Plane
    {
        public int Id { get; set; }
        [Required]
        public string PlaneName { get; set; }
        [Required]
        public decimal Price { get; set; }
        public virtual List<PlaneComponent> PlaneComponents { get; set; }
        public virtual List<Order> Orders { get; set; }
    }
}
