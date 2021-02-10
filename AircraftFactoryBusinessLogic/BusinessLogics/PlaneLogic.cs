using AircraftFactoryBusinessLogic.BindingModels;
using AircraftFactoryBusinessLogic.Interfaces;
using AircraftFactoryBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace AircraftFactoryBusinessLogic.BusinessLogics
{
    public class PlaneLogic
    {
        private readonly IPlaneStorage _planeStorage;
        public PlaneLogic(IPlaneStorage planeStorage)
        {
            _planeStorage = planeStorage;
        }
        public List<PlaneViewModel> Read(PlaneBindingModel model)
        {
            if (model == null)
            {
                return _planeStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<PlaneViewModel> { _planeStorage.GetElement(model) };
            }
            return _planeStorage.GetFilteredList(model);
        }
        public void CreateOrUpdate(PlaneBindingModel model)
        {
            var element = _planeStorage.GetElement(new PlaneBindingModel { ProductName = model.ProductName });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже есть изделие с таким названием");
            }
            if (model.Id.HasValue)
            {
                _planeStorage.Update(model);
            }
            else
            {
                _planeStorage.Insert(model);
            }
        }
        public void Delete(PlaneBindingModel model)
        {
            var element = _planeStorage.GetElement(new PlaneBindingModel { Id = model.Id });
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            _planeStorage.Delete(model);
        }
    }
}
