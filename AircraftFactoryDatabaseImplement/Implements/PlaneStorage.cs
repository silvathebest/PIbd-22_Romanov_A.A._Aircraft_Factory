using AircraftFactoryBusinessLogic.BindingModels;
using AircraftFactoryBusinessLogic.Interfaces;
using AircraftFactoryBusinessLogic.ViewModels;
using AircraftFactoryDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AircraftFactoryDatabaseImplement.Implements
{
    public class PlaneStorage : IPlaneStorage
    {
        public List<PlaneViewModel> GetFullList()
        {
            using (var context = new AircraftFactoryDatabase())
            {
                return context.Planes
                .Include(rec => rec.PlaneComponents)
               .ThenInclude(rec => rec.Component)
               .ToList()
               .Select(rec => new PlaneViewModel
               {
                   Id = rec.Id,
                   PlaneName = rec.PlaneName,
                   Price = rec.Price,
                   PlaneComponents = rec.PlaneComponents
                .ToDictionary(recPC => recPC.ComponentId, recPC =>
               (recPC.Component?.ComponentName, recPC.Count))
               })
               .ToList();
            }
        }
        public List<PlaneViewModel> GetFilteredList(PlaneBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new AircraftFactoryDatabase())
            {
                return context.Planes
                .Include(rec => rec.PlaneComponents)
               .ThenInclude(rec => rec.Component)
               .Where(rec => rec.PlaneName.Contains(model.PlaneName))
               .ToList()
               .Select(rec => new PlaneViewModel
               {
                   Id = rec.Id,
                   PlaneName = rec.PlaneName,
                   Price = rec.Price,
                   PlaneComponents = rec.PlaneComponents
                .ToDictionary(recPC => recPC.ComponentId, recPC =>
               (recPC.Component?.ComponentName, recPC.Count))
               })
               .ToList();
            }
        }
        public PlaneViewModel GetElement(PlaneBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new AircraftFactoryDatabase())
            {
                var product = context.Planes
                .Include(rec => rec.PlaneComponents)
               .ThenInclude(rec => rec.Component)
               .FirstOrDefault(rec => rec.PlaneName == model.PlaneName || rec.Id
               == model.Id);
                return product != null ?
                new PlaneViewModel
                {
                    Id = product.Id,
                    PlaneName = product.PlaneName,
                    Price = product.Price,
                    PlaneComponents = product.PlaneComponents
                .ToDictionary(recPC => recPC.ComponentId, recPC =>
               (recPC.Component?.ComponentName, recPC.Count))
                } : null;
            }
        }
        public void Insert(PlaneBindingModel model)
        {
            using (var context = new AircraftFactoryDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.Planes.Add(CreateModel(model, new Plane(), context));
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
        public void Update(PlaneBindingModel model)
        {
            using (var context = new AircraftFactoryDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var element = context.Planes.FirstOrDefault(rec => rec.Id == model.Id);
                        if (element == null)
                        {
                            throw new Exception("Элемент не найден");
                        }
                        CreateModel(model, element, context);
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
        public void Delete(PlaneBindingModel model)
        {
            using (var context = new AircraftFactoryDatabase())
            {
                Plane element = context.Planes.FirstOrDefault(rec => rec.Id == model.Id);
                if (element != null)
                {
                    context.Planes.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }
        private Plane CreateModel(PlaneBindingModel model, Plane plane, AircraftFactoryDatabase context)
        {
            plane.PlaneName = model.PlaneName;
            plane.Price = model.Price;
            if (model.Id.HasValue)
            {
                var productComponents = context.PlaneComponents.Where(rec =>
               rec.ProductId == model.Id.Value).ToList();
                // удалили те, которых нет в модели
                context.PlaneComponents.RemoveRange(productComponents.Where(rec =>
               !model.PlaneComponents.ContainsKey(rec.ComponentId)).ToList());
                context.SaveChanges();
                // обновили количество у существующих записей
                foreach (var updateComponent in productComponents)
                {
                    updateComponent.Count =
                   model.PlaneComponents[updateComponent.ComponentId].Item2;
                    model.PlaneComponents.Remove(updateComponent.ComponentId);
                }
                context.SaveChanges();
            }
            // добавили новые
            foreach (var pc in model.PlaneComponents)
            {
                context.PlaneComponents.Add(new PlaneComponent
                {
                    ProductId = plane.Id,
                    ComponentId = pc.Key,
                    Count = pc.Value.Item2
                });
                context.SaveChanges();
            }
            return plane;
        }
    }
}
