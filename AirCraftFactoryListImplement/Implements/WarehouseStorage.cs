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
    public class WarehouseStorage : IWarehouseStorage
    {
        private readonly DataListSingleton source;

        public WarehouseStorage()
        {
            source = DataListSingleton.GetInstance();
        }

        public void Delete(WarehouseBindingModel model)
        {
            for (int i = 0; i < source.Warehouses.Count; ++i)
            {
                if (source.Warehouses[i].Id == model.Id)
                {
                    source.Warehouses.RemoveAt(i);
                    return;
                }
            }

            throw new Exception("Элемент не найден");
        }

        public WarehouseViewModel GetElement(WarehouseBindingModel model)
        {
            if (model == null) return null;


            foreach (Warehouse warehouse in source.Warehouses)
            {
                if (warehouse.Id == model.Id || warehouse.WarehouseName == model.WarehouseName)
                {
                    return CreateModel(warehouse);
                }
            }

            return null;
        }

        public List<WarehouseViewModel> GetFilteredList(WarehouseBindingModel model)
        {
            if (model == null)

                return null;


            List<WarehouseViewModel> result = new List<WarehouseViewModel>();
            foreach (Warehouse warehouse in source.Warehouses)
            {
                if (warehouse.WarehouseName.Contains(model.WarehouseName))
                {
                    result.Add(CreateModel(warehouse));
                }
            }
            return result;
        }

        public List<WarehouseViewModel> GetFullList()
        {

            List<WarehouseViewModel> result = new List<WarehouseViewModel>();
            foreach (Warehouse warehouse in source.Warehouses)
            {
                result.Add(CreateModel(warehouse));
            }
            return result;
        }

        public void Insert(WarehouseBindingModel model)
        {
            Warehouse tempWarehouse = new Warehouse
            {
                Id = 1,
                WarehouseComponents = new Dictionary<int, int>(),
                DateCreate = DateTime.Now
            };

            foreach (Warehouse warehouse in source.Warehouses)
            {
                if (warehouse.Id >= tempWarehouse.Id)
                {
                    tempWarehouse.Id = warehouse.Id + 1;
                }
            }

            source.Warehouses.Add(CreateModel(model, tempWarehouse));
        }

        public bool IsTaked(Dictionary<int, (string, int)> component, int planeCount)
        {
            throw new NotImplementedException();
        }

        public void Update(WarehouseBindingModel model)
        {
            Warehouse tempWarehouse = null;

            foreach (Warehouse warehouse in source.Warehouses)
            {
                if (warehouse.Id == model.Id)
                {
                    tempWarehouse = warehouse;
                }
            }

            if (tempWarehouse == null)
            {
                throw new Exception("Элемент не найден");
            }

            CreateModel(model, tempWarehouse);
        }
        private Warehouse CreateModel(WarehouseBindingModel model, Warehouse warehouse)
        {
            warehouse.WarehouseName = model.WarehouseName;
            warehouse.ResponsiblePerson = model.ResponsiblePerson;

            foreach (int key in warehouse.WarehouseComponents.Keys.ToList())
            {
                if (!model.WarehouseComponents.ContainsKey(key))
                {
                    warehouse.WarehouseComponents.Remove(key);
                }
            }

            foreach (KeyValuePair<int, (string, int)> material in model.WarehouseComponents)
            {
                if (warehouse.WarehouseComponents.ContainsKey(material.Key))
                {
                    warehouse.WarehouseComponents[material.Key] =
                        model.WarehouseComponents[material.Key].Item2;
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

            foreach (KeyValuePair<int, int> storehouseMaterial in warehouse.WarehouseComponents)
            {
                string materialName = string.Empty;
                foreach (Component component in source.Components)
                {
                    if (storehouseMaterial.Key == component.Id)
                    {
                        materialName = component.ComponentName;
                        break;
                    }
                }
                warehouseComponents.Add(storehouseMaterial.Key, (materialName, storehouseMaterial.Value));
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
