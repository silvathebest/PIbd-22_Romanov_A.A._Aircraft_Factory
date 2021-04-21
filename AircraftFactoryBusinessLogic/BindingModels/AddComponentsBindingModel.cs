using System;
using System.Collections.Generic;
using System.Text;

namespace AircraftFactoryBusinessLogic.BindingModels
{
    public class AddComponentsBindingModel
    {
        public int WarehouseId { get; set; }

        public int ComponentId { get; set; }

        public int Count { get; set; }
    }
}
