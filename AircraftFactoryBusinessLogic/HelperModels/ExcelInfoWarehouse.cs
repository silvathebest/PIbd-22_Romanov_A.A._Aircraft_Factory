using AircraftFactoryBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace AircraftFactoryBusinessLogic.HelperModels
{
    public class ExcelInfoWarehouse
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public List<ReportWarehouseComponentViewModel> WarehouseComponents { get; set; }
    }
}
