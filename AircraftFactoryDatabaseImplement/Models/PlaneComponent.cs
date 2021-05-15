using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AircraftFactoryDatabaseImplement.Models
{
    /// <summary>
    /// Сколько компонентов, требуется при изготовлении изделия
    /// </summary>
    public class PlaneComponent
    {
        public int Id { get; set; }
        public int PlaneId { get; set; }
        public int ComponentId { get; set; }
        [Required]
        public int Count { get; set; }
        public virtual Component Component { get; set; }
        public virtual Plane Plane { get; set; }

    }
}
