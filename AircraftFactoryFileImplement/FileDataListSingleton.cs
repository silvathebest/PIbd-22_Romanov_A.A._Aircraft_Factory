using AircraftFactoryBusinessLogic.Enums;
using AircraftFactoryFileImplement.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace AircraftFactoryFileImplement
{
    public class FileDataListSingleton
    {
        private static FileDataListSingleton instance;
        private readonly string ComponentFileName = "Component.xml";
        private readonly string OrderFileName = "Order.xml";
        private readonly string PlaneFileName = "Plane.xml";
        private readonly string WarehouseFileName = "Warehouse.xml";
        private readonly string ClientFileName = "Client.xml";

        public List<Component> Components { get; set; }
        public List<Order> Orders { get; set; }
        public List<Plane> Planes { get; set; }
        public List<Warehouse> Warehouses { get; set; }
        public List<Client> Clients { get; set; }
        
        private FileDataListSingleton()
        {
            Components = LoadComponents();
            Orders = LoadOrders();
            Planes = LoadPlanes();
            Warehouses = LoadWarehouses();
            Clients = LoadClients();
        }

        private List<Client> LoadClients()
        {
            var list = new List<Client>();
            if (File.Exists(ClientFileName))
            {
                XDocument xDocument = XDocument.Load(ClientFileName);
                var xElements = xDocument.Root.Elements("Client").ToList();
                foreach (var element in xElements)
                {
                    list.Add(new Client
                    {
                        Id = Convert.ToInt32(element.Attribute("Id").Value),
                        FIO = element.Element("FIO").Value,
                        Email = element.Element("Email").Value,
                        Password = element.Element("Password").Value
                    });
                }
            }
            return list;
        }

        public static FileDataListSingleton GetInstance()
        {
            if (instance == null) instance = new FileDataListSingleton();

            return instance;
        }
        ~FileDataListSingleton()
        {
            SaveComponents();
            SaveOrders();
            SavePlanes();
            SaveWarehouses();
            SaveClients();
        }

        private List<Component> LoadComponents()
        {
            var list = new List<Component>();
            if (File.Exists(ComponentFileName))
            {
                XDocument xDocument = XDocument.Load(ComponentFileName);
                var xElements = xDocument.Root.Elements("Component").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new Component
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        ComponentName = elem.Element("ComponentName").Value
                    });
                }
            }
            return list;
        }
        private List<Order> LoadOrders()
        {
            var list = new List<Order>();
            if (File.Exists(OrderFileName))
            {
                XDocument xDocument = XDocument.Load(OrderFileName);
                var xElements = xDocument.Root.Elements("Order").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new Order
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        PlaneId = Convert.ToInt32(elem.Element("PlaneId").Value),
                        ClientId = Convert.ToInt32(elem.Element("ClientId").Value),
                        Count = Convert.ToInt32(elem.Element("Count").Value),
                        Sum = Convert.ToInt32(elem.Element("Sum").Value),
                        Status = (OrderStatus)Enum.Parse(typeof(OrderStatus), elem.Element("Status").Value),
                        DateCreate = Convert.ToDateTime(elem.Element("DateCreate").Value),
                        DateImplement = string.IsNullOrEmpty(elem.Element("DateImplement").Value) ?
                        (DateTime?)null : Convert.ToDateTime(elem.Element("DateImplement").Value),
                    });
                }
            }
            return list;
        }
        private List<Plane> LoadPlanes()
        {
            var list = new List<Plane>();
            if (File.Exists(PlaneFileName))
            {
                XDocument xDocument = XDocument.Load(PlaneFileName);
                var xElements = xDocument.Root.Elements("Plane").ToList();
                foreach (var elem in xElements)
                {
                    var planeComponents = new Dictionary<int, int>();
                    foreach (var component in elem.Element("PlaneComponents").Elements("PlaneComponent").ToList())
                    {
                        planeComponents.Add(Convert.ToInt32(component.Element("Key").Value),
                       Convert.ToInt32(component.Element("Value").Value));
                    }
                    list.Add(new Plane
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        PlaneName = elem.Element("PlaneName").Value,
                        Price = Convert.ToDecimal(elem.Element("Price").Value),
                        PlaneComponents = planeComponents
                    });
                }
            }
            return list;
        }

        private List<Warehouse> LoadWarehouses()
        {
            var list = new List<Warehouse>();

            if (File.Exists(WarehouseFileName))
            {
                XDocument xDocument = XDocument.Load(WarehouseFileName);

                var xElements = xDocument.Root.Elements("Warehouse").ToList();

                foreach (var warehouse in xElements)
                {
                    var warehouseComponents = new Dictionary<int, int>();

                    foreach (var material in warehouse.Element("WarehouseComponents").Elements("WarehouseComponent").ToList())
                    {
                        warehouseComponents.Add(Convert.ToInt32(material.Element("Key").Value), Convert.ToInt32(material.Element("Value").Value));
                    }

                    list.Add(new Warehouse
                    {
                        Id = Convert.ToInt32(warehouse.Attribute("Id").Value),
                        WarehouseName = warehouse.Element("WarehouseName").Value,
                        ResponsiblePerson = warehouse.Element("ResponsiblePerson").Value,
                        DateCreate = Convert.ToDateTime(warehouse.Element("DateCreate").Value),
                        WarehouseComponents = warehouseComponents
                    });
                }
            }

            return list;
        }
        private void SaveComponents()
        {
            if (Components != null)
            {
                var xElement = new XElement("Components");
                foreach (var component in Components)
                {
                    xElement.Add(new XElement("Component",
                    new XAttribute("Id", component.Id),
                    new XElement("ComponentName", component.ComponentName)));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(ComponentFileName);
            }
        }
        private void SaveOrders()
        {
            if (Orders != null)
            {
                var xElement = new XElement("Orders");
                foreach (var order in Orders)
                {
                    xElement.Add(new XElement("Order",
                    new XAttribute("Id", order.Id),
                    new XElement("PlaneId", order.PlaneId),
                    new XElement("ClientId", order.ClientId),
                    new XElement("Count", order.Count),
                    new XElement("Sum", order.Sum),
                    new XElement("Status", order.Status),
                    new XElement("DateCreate", order.DateCreate),
                    new XElement("DateImplement", order.DateImplement)));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(OrderFileName);
            }
        }
        private void SavePlanes()
        {
            if (Planes != null)
            {
                var xElement = new XElement("Planes");
                foreach (var plane in Planes)
                {
                    var compElement = new XElement("PlaneComponents");
                    foreach (var component in plane.PlaneComponents)
                    {
                        compElement.Add(new XElement("PlaneComponent",
                        new XElement("Key", component.Key),
                        new XElement("Value", component.Value)));
                    }
                    xElement.Add(new XElement("Plane",
                     new XAttribute("Id", plane.Id),
                     new XElement("PlaneName", plane.PlaneName),
                     new XElement("Price", plane.Price),
                     compElement));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(PlaneFileName);
            }
        }
        private void SaveWarehouses()
        {
            if (Warehouses != null)
            {
                var xElement = new XElement("Warehouses");

                foreach (var warehouse in Warehouses)
                {
                    var materialElement = new XElement("WarehouseComponents");

                    foreach (var components in warehouse.WarehouseComponents)
                    {
                        materialElement.Add(new XElement("WarehouseComponent",
                            new XElement("Key", components.Key),
                            new XElement("Value", components.Value)));
                    }

                    xElement.Add(new XElement("Warehouse",
                        new XAttribute("Id", warehouse.Id),
                        new XElement("WarehouseName", warehouse.WarehouseName),
                        new XElement("ResponsiblePerson", warehouse.ResponsiblePerson),
                        new XElement("DateCreate", warehouse.DateCreate.ToString()),
                        materialElement));
                }

                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(WarehouseFileName);
            }
        }
        private void SaveClients()
        {
            if (Clients != null)
            {
                var xElement = new XElement("Clients");
                foreach (var client in Clients)
                {
                    xElement.Add(new XElement("Client",
                    new XAttribute("Id", client.Id),
                    new XElement("FIO", client.FIO),
                    new XElement("Email", client.Email),
                    new XElement("Password", client.Password)));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(ClientFileName);
            }
        }
    }
}
