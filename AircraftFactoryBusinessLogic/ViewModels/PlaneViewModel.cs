using AircraftFactoryBusinessLogic.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;

namespace AircraftFactoryBusinessLogic.ViewModels
{
    /// <summary>
    /// Изделие, изготавливаемое в магазине
    /// </summary>
    [DataContract]
    public class PlaneViewModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        [Column(title: "Название изделия", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string PlaneName { get; set; }
        [DataMember]
        [Column(title: "Цена", gridViewAutoSize: GridViewAutoSize.Fill)]
        public decimal Price { get; set; }
        [DataMember]
        public Dictionary<int, (string, int)> PlaneComponents { get; set; }
    }
}
