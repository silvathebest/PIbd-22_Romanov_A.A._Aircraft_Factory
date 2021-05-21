using AirCraftFactoryListImplement.Models;
using AirсraftFactoryListImplement.Models;
using System;
using System.Collections.Generic;

namespace AirCraftFactoryListImplement
{
    public class DataListSingleton
    {
        private static DataListSingleton instance;
        public List<Component> Components { get; set; }
        public List<Order> Orders { get; set; }
        public List<Plane> Planes { get; set; }
        public List<Warehouse> Warehouses { get; set; }
        public List<Client> Clients { get; set; }
        public List<Implementer> Implementers { get; set; }
        private DataListSingleton()
        {
            Components = new List<Component>();
            Orders = new List<Order>();
            Planes = new List<Plane>();
            Warehouses = new List<Warehouse>(); 
            Clients = new List<Client>();
            Implementers = new List<Implementer>();
        }
        public static DataListSingleton GetInstance()
        {
            if (instance == null) instance = new DataListSingleton();

            return instance;
        }
    }
}
