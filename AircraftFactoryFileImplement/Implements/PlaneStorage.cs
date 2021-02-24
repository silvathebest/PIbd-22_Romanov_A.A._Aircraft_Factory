using AircraftFactoryBusinessLogic.BindingModels;
using AircraftFactoryBusinessLogic.Interfaces;
using AircraftFactoryBusinessLogic.ViewModels;
using AircraftFactoryFileImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AircraftFactoryFileImplement.Implements
{
    public class PlaneStorage : IPlaneStorage
    {
        private readonly FileDataListSingleton source;
        public PlaneStorage()
        {
            source = FileDataListSingleton.GetInstance();
        }
        public List<PlaneViewModel> GetFullList()
        {
            return source.Products.Select(CreateModel).ToList();
        }
        public List<PlaneViewModel> GetFilteredList(PlaneBindingModel model)
        {
            if (model == null) return null;

            return source.Products.Where(rec => rec.ProductName.Contains(model.ProductName))
            .Select(CreateModel)
            .ToList();
        }
        public PlaneViewModel GetElement(PlaneBindingModel model)
        {
            if (model == null) return null;

            var product = source.Products
            .FirstOrDefault(rec => rec.ProductName == model.ProductName || rec.Id == model.Id);
            return product != null ? CreateModel(product) : null;
        }
        public void Insert(PlaneBindingModel model)
        {
            int maxId = source.Products.Count > 0 ? source.Components.Max(rec => rec.Id) : 0;
            var element = new Plane
            {
                Id = maxId + 1,
                ProductComponents = new Dictionary<int, int>()
            };
            source.Products.Add(CreateModel(model, element));
        }
        public void Update(PlaneBindingModel model)
        {
            var element = source.Products.FirstOrDefault(rec => rec.Id == model.Id);

            if (element == null) throw new Exception("Элемент не найден");
            
            CreateModel(model, element);
        }
        public void Delete(PlaneBindingModel model)
        {
            Plane element = source.Products.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                source.Products.Remove(element);
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
        private Plane CreateModel(PlaneBindingModel model, Plane plane)
        {
            plane.ProductName = model.ProductName;
            plane.Price = model.Price;
            // удаляем убранные
            foreach (var key in plane.ProductComponents.Keys.ToList())
            {
                if (!model.PlaneComponents.ContainsKey(key))
                {
                    plane.ProductComponents.Remove(key);
                }
            }
            // обновляем существуюущие и добавляем новые
            foreach (var component in model.PlaneComponents)
            {
                if (plane.ProductComponents.ContainsKey(component.Key))
                {
                    plane.ProductComponents[component.Key] = model.PlaneComponents[component.Key].Item2;
                }
                else
                {
                    plane.ProductComponents.Add(component.Key,model.PlaneComponents[component.Key].Item2);
                }
            }
            return plane;
        }
        private PlaneViewModel CreateModel(Plane plane)
        {
            return new PlaneViewModel
            {
                Id = plane.Id,
                ProductName = plane.ProductName,
                Price = plane.Price,
                PlaneComponents = plane.ProductComponents
                .ToDictionary(recPC => recPC.Key, recPC =>
                (source.Components.FirstOrDefault(recC => recC.Id == recPC.Key)?.ComponentName, recPC.Value))
            };
        }
    }

}
