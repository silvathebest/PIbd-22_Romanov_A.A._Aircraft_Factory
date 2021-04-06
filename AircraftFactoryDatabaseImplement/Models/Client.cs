using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AircraftFactoryDatabaseImplement.Models
{
    public class Client
    {
        public int Id { set; get; }
        [Required]
        public string FIO { set; get; }
        [Required]
        public string Email { set; get; }
        [Required]
        public string Password { set; get; }
        [ForeignKey("ClientId")]
        public virtual List<Order> Orders { set; get; }
    }
}
