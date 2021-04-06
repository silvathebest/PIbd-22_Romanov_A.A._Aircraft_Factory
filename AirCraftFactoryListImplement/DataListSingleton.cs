﻿using AirCraftFactoryListImplement.Models;
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
        public List<Client> Clients { get; set; }
        private DataListSingleton()
        {
            Components = new List<Component>();
            Orders = new List<Order>();
            Planes = new List<Plane>();
            Clients = new List<Client>();
        }
        public static DataListSingleton GetInstance()
        {
            if (instance == null) instance = new DataListSingleton();

            return instance;
        }
    }
}
