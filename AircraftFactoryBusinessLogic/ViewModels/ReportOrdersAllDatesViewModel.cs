using System;
using System.Collections.Generic;
using System.Text;

namespace AircraftFactoryBusinessLogic.ViewModels
{
    public class ReportOrdersAllDatesViewModel
    {
        public DateTime Date { get; set; }

        public int Count { get; set; }

        public decimal Sum { get; set; }
    }
}
