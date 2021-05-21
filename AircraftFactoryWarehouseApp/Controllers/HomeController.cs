using AircraftFactoryBusinessLogic.BindingModels;
using AircraftFactoryBusinessLogic.ViewModels;
using AircraftFactoryWarehouseApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AircraftFactoryWarehouseApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration configuration;

        public HomeController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public IActionResult Index()
        {
            if (!Program.Authorization)
            {
                return Redirect("~/Home/Privacy");
            }

            return View(APIWarehouse.GetRequest<List<WarehouseViewModel>>($"api/warehouse/getall"));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public void Privacy(string password)
        {
            if (!string.IsNullOrEmpty(password))
            {
                Program.Authorization = password == configuration["Password"];

                if (!Program.Authorization)
                {
                    throw new Exception("Неверный пароль");
                }

                Response.Redirect("Index");
                return;
            }

            throw new Exception("Введите пароль");
        }

        public IActionResult Create()
        {
            if (!Program.Authorization)
            {
                return Redirect("~/Home/Privacy");
            }
            return View();
        }

        [HttpPost]
        public void Create([Bind("WarehouseName, ResponsiblePerson")] WarehouseBindingModel model)
        {
            if (string.IsNullOrEmpty(model.WarehouseName) || string.IsNullOrEmpty(model.ResponsiblePerson))
            {
                return;
            }
            model.WarehouseComponents = new Dictionary<int, (string, int)>();
            APIWarehouse.PostRequest("api/warehouse/create", model);
            Response.Redirect("Index");
        }

        public IActionResult Update(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var warehouse = APIWarehouse.GetRequest<List<WarehouseViewModel>>(
                $"api/warehouse/getall").FirstOrDefault(rec => rec.Id == id);
            if (warehouse == null)
            {
                return NotFound();
            }

            return View(warehouse);
        }

        [HttpPost]
        public IActionResult Update(int id, [Bind("Id,WarehouseName,ResponsiblePerson")] WarehouseBindingModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            var warehouse = APIWarehouse.GetRequest<List<WarehouseViewModel>>(
                $"api/warehouse/getall").FirstOrDefault(rec => rec.Id == id);

            model.WarehouseComponents= warehouse.WarehouseComponents;

            APIWarehouse.PostRequest("api/warehouse/update", model);
            return Redirect("~/Home/Index");
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var warehouses = APIWarehouse.GetRequest<List<WarehouseViewModel>>(
                $"api/warehouse/getall").FirstOrDefault(rec => rec.Id == id);
            if (warehouses == null)
            {
                return NotFound();
            }

            return View(warehouses);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            APIWarehouse.PostRequest("api/warehouse/delete", new WarehouseBindingModel { Id = id });
            return Redirect("~/Home/Index");
        }

        public IActionResult AddComponent()
        {
            if (!Program.Authorization)
            {
                return Redirect("~/Home/Privacy");
            }
            ViewBag.Warehouses = APIWarehouse.GetRequest<List<WarehouseViewModel>>("api/warehouse/getall");
            ViewBag.Components = APIWarehouse.GetRequest<List<ComponentViewModel>>("api/warehouse/getallcomponents");

            return View();
        }

        [HttpPost]
        public IActionResult AddComponent([Bind("WarehouseId, ComponentId, Count")] AddComponentsBindingModel model)
        {
            if (model.WarehouseId == 0 || model.ComponentId == 0 || model.Count <= 0)
            {
                return NotFound();
            }

            var warehouse = APIWarehouse.GetRequest<List<WarehouseViewModel>>(
                "api/warehouse/getall").FirstOrDefault(rec => rec.Id == model.WarehouseId);

            if (warehouse == null)
            {
                return NotFound();
            }

            var component = APIWarehouse.GetRequest<List<WarehouseViewModel>>(
                "api/warehouse/getallcomponents").FirstOrDefault(rec => rec.Id == model.ComponentId);

            if (component == null)
            {
                return NotFound();
            }

            APIWarehouse.PostRequest("api/warehouse/addcomponent", model);
            return Redirect("~/Home/Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
