using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [ForeignKey("PlaneId")]
        public virtual List<PlaneComponent> PlaneComponents { get; set; }
        [ForeignKey("PlaneId")]
        public virtual List<Order> Orders { get; set; }
    }
}
