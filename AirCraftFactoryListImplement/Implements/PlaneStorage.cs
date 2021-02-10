using AircraftFactoryBusinessLogic.BindingModels;
using AircraftFactoryBusinessLogic.Interfaces;
using AircraftFactoryBusinessLogic.ViewModels;
using AirCraftFactoryListImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AirCraftFactoryListImplement.Implements
{
    public class PlaneStorage : IPlaneStorage
    {
        private readonly DataListSingleton source;
        public PlaneStorage()
        {
            source = DataListSingleton.GetInstance();
        }
        public List<PlaneViewModel> GetFullList()
        {
            List<PlaneViewModel> result = new List<PlaneViewModel>();
            foreach (var component in source.Products)
            {
                result.Add(CreateModel(component));
            }
            return result;
        }
        public List<PlaneViewModel> GetFilteredList(PlaneBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            List<PlaneViewModel> result = new List<PlaneViewModel>();
            foreach (var product in source.Products)
            {
                if (product.ProductName.Contains(model.ProductName))
                {
                    result.Add(CreateModel(product));
                }
            }
            return result;
        }
        public PlaneViewModel GetElement(PlaneBindingModel model)
        {
            if (model == null) return null;

            foreach (var product in source.Products)
            {
                if (product.Id == model.Id || product.ProductName == model.ProductName)
                {
                    return CreateModel(product);
                }
            }

            return null;
        }
        public void Insert(PlaneBindingModel model)
        {
            Plane tempProduct = new Plane
            {
                Id = 1,
                ProductComponents = new Dictionary<int, int>()
            };
            foreach (var product in source.Products)
            {
                if (product.Id >= tempProduct.Id)
                {
                    tempProduct.Id = product.Id + 1;
                }
            }
            source.Products.Add(CreateModel(model, tempProduct));
        }
        public void Update(PlaneBindingModel model)
        {
            Plane tempProduct = null;
            foreach (var product in source.Products)
            {
                if (product.Id == model.Id)
                {
                    tempProduct = product;
                }
            }
            if (tempProduct == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, tempProduct);
        }
        public void Delete(PlaneBindingModel model)
        {
            for (int i = 0; i < source.Products.Count; ++i)
            {
                if (source.Products[i].Id == model.Id)
                {
                    source.Products.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }
        private Plane CreateModel(PlaneBindingModel model, Plane product)
        {
            product.ProductName = model.ProductName;
            product.Price = model.Price;
            // удаляем убранные
            foreach (var key in product.ProductComponents.Keys.ToList())
            {
                if (!model.PlaneComponents.ContainsKey(key))
                {
                    product.ProductComponents.Remove(key);
                }
            }
            // обновляем существуюущие и добавляем новые
            foreach (var component in model.PlaneComponents)
            {
                if (product.ProductComponents.ContainsKey(component.Key))
                {
                    product.ProductComponents[component.Key] =
                    model.PlaneComponents[component.Key].Item2;
                }
                else
                {
                    product.ProductComponents.Add(component.Key,
                    model.PlaneComponents[component.Key].Item2);
                }
            }
            return product;
        }
        private PlaneViewModel CreateModel(Plane plane)
        {
            // требуется дополнительно получить список компонентов для изделия с названиями и их количество
            Dictionary<int, (string, int)> productComponents = new
            Dictionary<int, (string, int)>();
            foreach (var pc in plane.ProductComponents)
            {
                string componentName = string.Empty;
                foreach (var component in source.Components)
                {
                    if (pc.Key == component.Id)
                    {
                        componentName = component.ComponentName;
                        break;
                    }
                }
                productComponents.Add(pc.Key, (componentName, pc.Value));
            }
            return new PlaneViewModel
            {
                Id = plane.Id,
                ProductName = plane.ProductName,
                Price = plane.Price,
                PlaneComponents = productComponents
            };
        }
    }

}
