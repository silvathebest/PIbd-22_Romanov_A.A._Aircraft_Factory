using AircraftFactoryBusinessLogic.BindingModels;
using AircraftFactoryBusinessLogic.Enums;
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
                return context.Orders.Include(rec => rec.Planes).Include(rec => rec.Client).Include(rec => rec.Implementer)
                .Select(rec => new OrderViewModel
                {
                    Id = rec.Id,
                    PlaneId = rec.PlaneId,
                    PlaneName = context.Planes.FirstOrDefault(pr => pr.Id == rec.PlaneId).PlaneName,
                    ImplementerId = rec.ImplementerId,
                    ImplementerFIO = rec.Implementer.ImplementerFIO,
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
                return context.Orders.Include(rec => rec.Planes).Include(rec => rec.Client).Include(rec => rec.Implementer)
                .Where(rec => (!model.DateFrom.HasValue && !model.DateTo.HasValue &&
                rec.DateCreate.Date == model.DateCreate.Date) ||
                (model.DateFrom.HasValue && model.DateTo.HasValue &&
                rec.DateCreate.Date >= model.DateFrom.Value.Date && rec.DateCreate.Date <=
                model.DateTo.Value.Date) || (model.ClientId.HasValue && rec.ClientId == model.ClientId) ||
                (model.FreeOrders.HasValue && model.FreeOrders.Value && rec.Status ==
                OrderStatus.Принят) || (model.ImplementerId.HasValue && rec.ImplementerId == model.ImplementerId && rec.Status == model.Status))
                .Select(rec => new OrderViewModel
                {
                    Id = rec.Id,
                    ClientId = rec.ClientId,
                    ClientFIO = context.Clients.Include(x => x.Orders).FirstOrDefault(x => x.Id == rec.ClientId).FIO,
                    ImplementerId = rec.ImplementerId,
                    ImplementerFIO = rec.Implementer.ImplementerFIO,
                    PlaneId = rec.PlaneId,
                    PlaneName = context.Planes.Include(x => x.Orders).FirstOrDefault(x => x.Id == rec.PlaneId).PlaneName,
                    Count = rec.Count,
                    Sum = rec.Sum,
                    Status = rec.Status,
                    DateCreate = rec.DateCreate,
                    DateImplement = rec.DateImplement
                })
                .ToList();
            }
        }
        public OrderViewModel GetElement(OrderBindingModel model)
        {
            if (model == null) return null;

            using (var context = new AircraftFactoryDatabase())
            {
                var order = context.Orders.Include(rec => rec.Planes).Include(rec => rec.Client).Include(rec => rec.Implementer)
                .FirstOrDefault(rec => rec.Id == model.Id);
                return order != null ?
                new OrderViewModel
                {
                    Id = order.Id,
                    PlaneId = order.PlaneId,
                    ClientId = order.ClientId,
                    PlaneName = context.Planes.FirstOrDefault(rec => rec.Id == order.PlaneId)?.PlaneName,
                    ClientFIO = context.Clients.Include(x => x.Orders).FirstOrDefault(x => x.Id == order.ClientId).FIO,
                    ImplementerId = order.ImplementerId,
                    ImplementerFIO = order.ImplementerId.HasValue ? order.Implementer.ImplementerFIO : string.Empty,
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
            using (AircraftFactoryDatabase context = new AircraftFactoryDatabase())
            {
                context.Orders.Add(CreateModel(model, new Order()));
                context.SaveChanges();
            }
        }
        public void Update(OrderBindingModel model)
        {
            using (AircraftFactoryDatabase context = new AircraftFactoryDatabase())
            {
                var order = context.Orders.FirstOrDefault(rec => rec.Id == model.Id);
                if (order == null)
                {
                    throw new Exception("Заказ не найден");
                }
                CreateModel(model, order);
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
            order.ImplementerId = model.ImplementerId;
            order.DateImplement = model.DateImplement;
            return order;
        }
    }
}
