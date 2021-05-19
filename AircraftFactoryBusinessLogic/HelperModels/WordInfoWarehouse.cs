using AircraftFactoryBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace AircraftFactoryBusinessLogic.HelperModels
{
    public class WordInfoWarehouse
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public List<WarehouseViewModel> Warehouses{ get; set; }
    }
}
