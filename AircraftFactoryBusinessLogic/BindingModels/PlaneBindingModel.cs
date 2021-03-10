using System;
using System.Collections.Generic;
using System.Text;

namespace AircraftFactoryBusinessLogic.BindingModels
{
    public class PlaneBindingModel
    {
        public int? Id { get; set; }
        public string PlaneName { get; set; }
        public decimal Price { get; set; }
        public Dictionary<int, (string, int)> PlaneComponents { get; set; }
    }
}
