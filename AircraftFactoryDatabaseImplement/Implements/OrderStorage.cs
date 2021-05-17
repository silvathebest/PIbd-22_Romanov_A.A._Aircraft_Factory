﻿using AircraftFactoryBusinessLogic.BindingModels;
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
                return context.Orders.Include(rec => rec.Planes)
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
                return context.Orders
                .Include(rec => rec.Planes)
                .Where(rec => (!model.DateFrom.HasValue && !model.DateTo.HasValue && rec.DateCreate.Date == model.DateCreate.Date) ||
                (model.DateFrom.HasValue && model.DateTo.HasValue && rec.DateCreate.Date >= model.DateFrom.Value.Date && rec.DateCreate.Date <= model.DateTo.Value.Date))
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
                var order = context.Orders.Include(rec => rec.Planes)
                .FirstOrDefault(rec => rec.Id == model.Id);
                return order != null ?
                new OrderViewModel
                {
                    Id = order.Id,
                    PlaneId = order.PlaneId,
                    PlaneName = order.Planes.PlaneName,
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
                Order order = new Order
                {
                    PlaneId = model.PlaneId,
                    Count = model.Count,
                    Sum = model.Sum,
                    Status = model.Status,
                    DateCreate = model.DateCreate,
                    DateImplement = model.DateImplement,
                };
                context.Orders.Add(order);
                context.SaveChanges();
                CreateModel(model, order);
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
                element.PlaneId = model.PlaneId;
                element.Count = model.Count;
                element.Sum = model.Sum;
                element.Status = model.Status;
                element.DateCreate = model.DateCreate;
                element.DateImplement = model.DateImplement;
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
            if (model == null)
            {
                return null;
            }

            using (var context = new AircraftFactoryDatabase())
            {
                Plane element = context.Planes.FirstOrDefault(rec => rec.Id == model.PlaneId);
                if (element != null)
                {
                    if (element.Orders == null)
                    {
                        element.Orders = new List<Order>();
                    }
                    element.Orders.Add(order);
                    context.Planes.Update(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
            return order;
        }
    }
}
