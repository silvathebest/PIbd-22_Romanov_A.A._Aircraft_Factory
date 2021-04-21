using AirCraftFactoryListImplement.Models;
using System;
using System.Collections.Generic;

namespace AirCraftFactoryListImplement
{
    public class DataListSingleton
    {
        private static DataListSingleton instance;
        public List<Component> Components { get; set; }
        public List<Order> Orders { get; set; }
        public List<Plane> Products { get; set; }
        public List<Warehouse> Warehouses { get; set; }
        private DataListSingleton()
        {
            Components = new List<Component>();
            Orders = new List<Order>();
            Products = new List<Plane>();
            Warehouses = new List<Warehouse>(); 
        }
        public static DataListSingleton GetInstance()
        {
            if (instance == null)  instance = new DataListSingleton();
            
            return instance;
        }
    }
}
