using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;

namespace AircraftFactoryBusinessLogic.ViewModels
{
    [DataContract]
    public class WarehouseViewModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        [DisplayName("Cклад")]
        public string WarehouseName { get; set; }
        [DataMember]
        [DisplayName("ФИО ответственного")]
        public string ResponsiblePerson { get; set; }
        [DataMember]
        [DisplayName("Дата создания")]
        public DateTime DateCreate { get; set; }
        [DataMember]
        public Dictionary<int, (string, int)> WarehouseComponents { get; set; }
    }
}
