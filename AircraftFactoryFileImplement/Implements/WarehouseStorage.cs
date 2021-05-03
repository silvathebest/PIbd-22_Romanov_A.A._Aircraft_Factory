using AircraftFactoryBusinessLogic.BindingModels;
using AircraftFactoryBusinessLogic.Interfaces;
using AircraftFactoryBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace AircraftFactoryFileImplement.Implements
{
    public class WarehouseStorage : IWarehouseStorage
    {
        public void Delete(WarehouseBindingModel model)
        {
            throw new NotImplementedException();
        }

        public WarehouseViewModel GetElement(WarehouseBindingModel model)
        {
            throw new NotImplementedException();
        }

        public List<WarehouseViewModel> GetFilteredList(WarehouseBindingModel model)
        {
            throw new NotImplementedException();
        }

        public List<WarehouseViewModel> GetFullList()
        {
            throw new NotImplementedException();
        }

        public void Insert(WarehouseBindingModel model)
        {
            throw new NotImplementedException();
        }

        public bool IsTaked(Dictionary<int, (string, int)> component, int planeCount)
        {
            throw new NotImplementedException();
        }

        public void Update(WarehouseBindingModel model)
        {
            throw new NotImplementedException();
        }
    }
}
