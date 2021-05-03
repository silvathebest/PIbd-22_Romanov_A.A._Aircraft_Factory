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
    public class WarehouseStorage : IWarehouseStorage
    {
        private readonly FileDataListSingleton source;

        public WarehouseStorage()
        {
            source = FileDataListSingleton.GetInstance();
        }
        public void Delete(WarehouseBindingModel model)
        {
            var warehouse = source.Warehouses.FirstOrDefault(xWarehouse => xWarehouse.Id == model.Id);

            if (warehouse != null)
            {
                source.Warehouses.Remove(warehouse);
            }
            else
            {
                throw new Exception("Склад не найден");
            }
        }

        public WarehouseViewModel GetElement(WarehouseBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            var warehouse = source.Warehouses.FirstOrDefault(xWarehouse => xWarehouse.WarehouseName == model.WarehouseName || xWarehouse.Id == model.Id);

            return warehouse != null ? CreateModel(warehouse) : null;
        }

        public List<WarehouseViewModel> GetFilteredList(WarehouseBindingModel model) => model == null ? null :
            source.Warehouses.Where(xWarehouse => xWarehouse.WarehouseName.Contains(model.WarehouseName)).Select(CreateModel).ToList();

        public List<WarehouseViewModel> GetFullList => source.Warehouses.Select(CreateModel).ToList();

        public void Insert(WarehouseBindingModel model)
        {
            int maxId = source.Warehouses.Count > 0 ? source.Warehouses.Max(xWarehouse => xWarehouse.Id) : 0;
            var warehouse = new Warehouse { Id = maxId + 1, WarehouseComponents = new Dictionary<int, int>(), DateCreate = DateTime.Now };
            source.Warehouses.Add(CreateModel(model, warehouse));
        }

        public bool IsTaked(Dictionary<int, (string, int)> components, int planeCount)
        {
            foreach (var warehouseComponent in components)
            {
                int count = source.Warehouses.Where(material => material.WarehouseComponents.ContainsKey(warehouseComponent.Key)).Sum(component => component.WarehouseComponents[warehouseComponent.Key]);

                if (count < warehouseComponent.Value.Item2 * planeCount)
                {
                    return false;
                }
            }

            foreach (var warehouseComponent in components)
            {
                int count = warehouseComponent.Value.Item2 * planeCount;
                IEnumerable<Warehouse> warehouses = source.Warehouses.Where(material => material.WarehouseComponents.ContainsKey(warehouseComponent.Key));

                foreach (Warehouse warehouse in warehouses)
                {
                    if (warehouse.WarehouseComponents[warehouseComponent.Key] <= count)
                    {
                        count -= warehouse.WarehouseComponents[warehouseComponent.Key];
                        warehouse.WarehouseComponents.Remove(warehouseComponent.Key);
                    }
                    else
                    {
                        warehouse.WarehouseComponents[warehouseComponent.Key] -= count;
                        count = 0;
                    }

                    if (count == 0)
                    {
                        break;
                    }
                }
            }

            return true;
        }

        public void Update(WarehouseBindingModel model)
        {
            var warehouse = source.Warehouses.FirstOrDefault(xWarehouse => xWarehouse.Id == model.Id);

            if (warehouse == null)
            {
                throw new Exception("Склад не найден");
            }

            CreateModel(model, warehouse);
        }
        private Warehouse CreateModel(WarehouseBindingModel model, Warehouse warehouse)
        {
            warehouse.WarehouseName = model.WarehouseName;
            warehouse.ResponsiblePerson = model.ResponsiblePerson;

            foreach (var key in warehouse.WarehouseComponents.Keys.ToList())
            {
                if (!model.WarehouseComponents.ContainsKey(key))
                {
                    warehouse.WarehouseComponents.Remove(key);
                }
            }

            foreach (var material in model.WarehouseComponents)
            {
                if (warehouse.WarehouseComponents.ContainsKey(material.Key))
                {
                    warehouse.WarehouseComponents[material.Key] = model.WarehouseComponents[material.Key].Item2;
                }
                else
                {
                    warehouse.WarehouseComponents.Add(material.Key, model.WarehouseComponents[material.Key].Item2);
                }
            }

            return warehouse;
        }

        private WarehouseViewModel CreateModel(Warehouse warehouse)
        {
            Dictionary<int, (string, int)> warehouseComponents = new Dictionary<int, (string, int)>();

            foreach (var warehouseComponent in warehouse.WarehouseComponents)
            {
                string componentName = string.Empty;
                foreach (var component in source.Components)
                {
                    if (warehouseComponent.Key == component.Id)
                    {
                        componentName = component.ComponentName;
                        break;
                    }
                }
                warehouseComponents.Add(warehouseComponent.Key, (componentName, warehouseComponent.Value));
            }

            return new WarehouseViewModel
            {
                Id = warehouse.Id,
                WarehouseName = warehouse.WarehouseName,
                ResponsiblePerson = warehouse.ResponsiblePerson,
                DateCreate = warehouse.DateCreate,
                WarehouseComponents = warehouseComponents
            };
        }
    }
}
