using System;
using System.Collections.Generic;
using System.Text;

namespace AircraftFactoryBusinessLogic.ViewModels
{
    public class ReportPlaneComponentViewModel
    {
        public string PlaneName { get; set; }
        public int TotalCount { get; set; }
        public List<Tuple<string, int>> PlaneComponents { get; set; }
    }
}