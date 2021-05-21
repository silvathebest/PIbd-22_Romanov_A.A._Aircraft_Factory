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
    public class OrderStorage : IOrderStorage
    {
        public List<OrderViewModel> GetFullList()
        {
            using (var context = new AircraftFactoryDatabase())
            {
                return context.Orders.Include(rec => rec.Planes).Include(rec => rec.Client)
                .Select(rec => new OrderViewModel
                {
                    Id = rec.Id,
                    PlaneId = rec.PlaneId,
                    PlaneName = rec.Planes.PlaneName,
                    Count = rec.Count,
                    Sum = rec.Sum,
                    Status = rec.Status,
                    DateCreate = rec.DateCreate,
                    DateImplement = rec.DateImplement,
                    ClientId = rec.ClientId,
                    ClientFIO = context.Clients.Include(x => x.Orders).FirstOrDefault(x => x.Id == rec.ClientId).FIO,
                }).ToList();
            }
        }
        public List<OrderViewModel> GetFilteredList(OrderBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new AircraftFactoryDatabase())
            {
                return context.Orders.Include(rec => rec.Planes).Include(rec => rec.Client)
               .Where(rec => (!model.DateFrom.HasValue && !model.DateTo.HasValue && rec.DateCreate.Date == model.DateCreate.Date) ||
               (model.DateFrom.HasValue && model.DateTo.HasValue && rec.DateCreate.Date
               >= model.DateFrom.Value.Date && rec.DateCreate.Date <= model.DateTo.Value.Date) ||
               (model.ClientId.HasValue && rec.ClientId == model.ClientId))
               .Select(rec => new OrderViewModel
               {
                   Id = rec.Id,
                   ClientId = rec.ClientId,
                   ClientFIO = context.Clients.Include(x => x.Orders).FirstOrDefault(x => x.Id == rec.ClientId).FIO,
                   PlaneId = rec.PlaneId,
                   PlaneName = rec.Planes.PlaneName,
                   Count = rec.Count,
                   Sum = rec.Sum,
                   Status = rec.Status,
                   DateCreate = rec.DateCreate,
                   DateImplement = rec.DateImplement
               }).ToList();
            }
        }
        public OrderViewModel GetElement(OrderBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new AircraftFactoryDatabase())
            {
                var order = context.Orders.Include(rec => rec.Planes).Include(rec => rec.Client)
                .FirstOrDefault(rec => rec.Id == model.Id);
                return order != null ?
                new OrderViewModel
                {
                    Id = order.Id,
                    PlaneId = order.PlaneId,
                    ClientId = order.ClientId,
                    ClientFIO = context.Clients.Include(x => x.Orders).FirstOrDefault(x => x.Id == order.ClientId).FIO,
                    PlaneName = context.Planes.FirstOrDefault(rec => rec.Id == order.PlaneId)?.PlaneName,
                    Count = order.Count,
                    Sum = order.Sum,
                    Status = order.Status,
                    DateCreate = order.DateCreate,
                    DateImplement = order.DateImplement,
                } : null;
            }
        }
        public void Insert(OrderBindingModel model)
        {
            using (var context = new AircraftFactoryDatabase())
            {
                context.Orders.Add(CreateModel(model, new Order()));
                context.SaveChanges();
            }
        }
        public void Update(OrderBindingModel model)
        {
            using (var context = new AircraftFactoryDatabase())
            {
                var element = context.Orders.FirstOrDefault(rec => rec.Id == model.Id);
                if (element == null)
                {
                    throw new Exception("Элемент не найден");
                }
                CreateModel(model, element);
                context.SaveChanges();
            }
        }
        public void Delete(OrderBindingModel model)
        {
            using (var context = new AircraftFactoryDatabase())
            {
                Order element = context.Orders.FirstOrDefault(rec => rec.Id == model.Id);
                if (element != null)
                {
                    context.Orders.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }
        private Order CreateModel(OrderBindingModel model, Order order)
        {
            order.ClientId = (int)model.ClientId;
            order.PlaneId = model.PlaneId;
            order.Count = model.Count;
            order.Sum = model.Sum;
            order.Status = model.Status;
            order.DateCreate = model.DateCreate;
            order.DateImplement = model.DateImplement;
            return order;
        }
    }
}
