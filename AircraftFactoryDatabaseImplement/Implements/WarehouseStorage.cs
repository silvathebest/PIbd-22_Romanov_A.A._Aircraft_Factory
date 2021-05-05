using AircraftFactoryBusinessLogic.BindingModels;
using AircraftFactoryBusinessLogic.Interfaces;
using AircraftFactoryBusinessLogic.ViewModels;
using AircraftFactoryDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AircraftFactoryDatabaseImplement.Implements
{
    public class WarehouseStorage : IWarehouseStorage
    {
        public List<WarehouseViewModel> GetFullList()
        {
            using (AircraftFactoryDatabase context = new AircraftFactoryDatabase())
            {
                return context.Warehouses
                    .Include(rec => rec.WarehouseComponents)
                    .ThenInclude(rec => rec.Component)
                    .ToList()
                    .Select(rec => new WarehouseViewModel
                    {
                        Id = rec.Id,
                        WarehouseName = rec.WarehouseName,
                        ResponsiblePerson = rec.ResponsiblePerson,
                        DateCreate = rec.DateCreate,
                        WarehouseComponents = rec.WarehouseComponents
                            .ToDictionary(recStoreHouseMaterials => recStoreHouseMaterials.ComponentId,
                            recStoreHouseMaterials => (recStoreHouseMaterials.Component?.ComponentName,
                            recStoreHouseMaterials.Count))
                    })
                    .ToList();
            }
        }

        public void Delete(WarehouseBindingModel model)
        {
            using (AircraftFactoryDatabase context = new AircraftFactoryDatabase())
            {
                Warehouse warehouse = context.Warehouses.FirstOrDefault(rec => rec.Id == model.Id);

                if (warehouse == null)
                {
                    throw new Exception("Склад не найден");
                }
                context.Warehouses.Remove(warehouse);
                context.SaveChanges();
            }
        }

        public WarehouseViewModel GetElement(WarehouseBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            using (AircraftFactoryDatabase context = new AircraftFactoryDatabase())
            {
                Warehouse warehouse = context.Warehouses
                    .Include(rec => rec.WarehouseComponents)
                    .ThenInclude(rec => rec.Component)
                    .FirstOrDefault(rec => rec.WarehouseName == model.WarehouseName ||
                    rec.Id == model.Id);

                return warehouse != null ?
                    new WarehouseViewModel
                    {
                        Id = warehouse.Id,
                        WarehouseName = warehouse.WarehouseName,
                        ResponsiblePerson = warehouse.ResponsiblePerson,
                        DateCreate = warehouse.DateCreate,
                        WarehouseComponents = warehouse.WarehouseComponents
                            .ToDictionary(rec => rec.ComponentId,
                            rec => (rec.Component?.ComponentName,
                            rec.Count))
                    } :
                    null;
            }
        }

        public List<WarehouseViewModel> GetFilteredList(WarehouseBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            using (AircraftFactoryDatabase context = new AircraftFactoryDatabase())
            {
                return context.Warehouses
                    .Include(rec => rec.WarehouseComponents)
                    .ThenInclude(rec => rec.Component)
                    .Where(rec => rec.WarehouseName.Contains(model.WarehouseName))
                    .ToList()
                    .Select(rec => new WarehouseViewModel
                    {
                        Id = rec.Id,
                        WarehouseName = rec.WarehouseName,
                        ResponsiblePerson = rec.ResponsiblePerson,
                        DateCreate = rec.DateCreate,
                        WarehouseComponents = rec.WarehouseComponents
                            .ToDictionary(recStoreHouseMaterial => recStoreHouseMaterial.ComponentId,
                            recStoreHouseMaterial => (recStoreHouseMaterial.Component?.ComponentName,
                            recStoreHouseMaterial.Count))
                    })
                    .ToList();
            }
        }

        public void Insert(WarehouseBindingModel model)
        {
            using (AircraftFactoryDatabase context = new AircraftFactoryDatabase())
            {
                using (IDbContextTransaction transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        CreateModel(model, new Warehouse(), context);
                        context.SaveChanges();
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public bool IsTaked(Dictionary<int, (string, int)> components, int planeCount)
        {
            using (AircraftFactoryDatabase context = new AircraftFactoryDatabase())
            {
                using (IDbContextTransaction transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        foreach (KeyValuePair<int, (string, int)> component in components)
                        {
                            int requiredComponentCount = component.Value.Item2 * planeCount;
                            IEnumerable<WarehouseComponent> warehouseComponents = context.WarehouseComponents
                                .Where(warehouse => warehouse.ComponentId == component.Key);
                            foreach (WarehouseComponent warehouseComponent in warehouseComponents)
                            {
                                if (warehouseComponent.Count <= requiredComponentCount)
                                {
                                    requiredComponentCount -= warehouseComponent.Count;
                                    context.WarehouseComponents.Remove(warehouseComponent);
                                }
                                else
                                {
                                    warehouseComponent.Count -= requiredComponentCount;
                                    requiredComponentCount = 0;
                                    break;
                                }
                            }
                            if (requiredComponentCount != 0)
                            {
                                throw new Exception("Нехватка материалов на складе");
                            }
                        }
                        context.SaveChanges();
                        transaction.Commit();
                        return true;
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public void Update(WarehouseBindingModel model)
        {
            using (AircraftFactoryDatabase context = new AircraftFactoryDatabase())
            {
                using (IDbContextTransaction transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        Warehouse warehouse = context.Warehouses.FirstOrDefault(rec => rec.Id == model.Id);

                        if (warehouse == null)
                        {
                            throw new Exception("Склад не найден");
                        }

                        CreateModel(model, warehouse, context);
                        context.SaveChanges();
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        private Warehouse CreateModel(WarehouseBindingModel model, Warehouse warehouse, AircraftFactoryDatabase context)
        {
            warehouse.WarehouseName = model.WarehouseName;
            warehouse.ResponsiblePerson = model.ResponsiblePerson;

            if (warehouse.Id == 0)
            {
                warehouse.DateCreate = DateTime.Now;
                context.Warehouses.Add(warehouse);
                context.SaveChanges();
            }

            if (model.Id.HasValue)
            {
                List<WarehouseComponent> WarehouseComponents = context.WarehouseComponents
                    .Where(rec => rec.WarehouseId == model.Id.Value)
                    .ToList();

                context.WarehouseComponents.RemoveRange(WarehouseComponents
                    .Where(rec => !model.WarehouseComponents.ContainsKey(rec.ComponentId))
                    .ToList());
                context.SaveChanges();

                foreach (var component in WarehouseComponents)
                {
                    component.Count = model.WarehouseComponents[component.ComponentId].Item2;
                    model.WarehouseComponents.Remove(component.ComponentId);
                }
                context.SaveChanges();
            }


            foreach (var component in model.WarehouseComponents)
            {
                context.WarehouseComponents.Add(new WarehouseComponent
                {
                    WarehouseId = warehouse.Id,
                    ComponentId = component.Key,
                    Count = component.Value.Item2
                });
                context.SaveChanges();
            }

            return warehouse;
        }
    }
}
