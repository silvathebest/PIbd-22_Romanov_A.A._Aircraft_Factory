using AircraftFactoryBusinessLogic.BindingModels;
using AircraftFactoryBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace AircraftFactoryBusinessLogic.Interfaces
{
    public interface IPlaneStorage
    {
        List<PlaneViewModel> GetFullList();
        List<PlaneViewModel> GetFilteredList(PlaneBindingModel model);
        PlaneViewModel GetElement(PlaneBindingModel model);
        void Insert(PlaneBindingModel model);
        void Update(PlaneBindingModel model);
        void Delete(PlaneBindingModel model);
    }
}   
