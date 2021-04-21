using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace AircraftFactoryBusinessLogic.ViewModels
{
    public class WarehouseViewModel
    {
        public int Id { get; set; }

        [DisplayName("Название склада")]
        public string WarehouseName { get; set; }

        [DisplayName("ФИО ответственного")]
        public string ResponsiblePerson { get; set; }

        [DisplayName("Дата создания")]
        public DateTime DateCreate { get; set; }

        public Dictionary<int, (string, int)> WarehouseComponents { get; set; }
    }
}
