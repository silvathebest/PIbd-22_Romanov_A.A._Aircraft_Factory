using AircraftFactoryBusinessLogic.BindingModels;
using AircraftFactoryBusinessLogic.BusinessLogics;
using AircraftFactoryBusinessLogic.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace AircraftFactoryRestApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MainController : ControllerBase
    {
        private readonly OrderLogic _order;
        private readonly PlaneLogic _plane;
        private readonly OrderLogic _main;
        public MainController(OrderLogic order, PlaneLogic plane, OrderLogic main)
        {
            _order = order;
            _plane = plane;
            _main = main;
        }
        [HttpGet]
        public List<PlaneViewModel> GetPlaneList() => _plane.Read(null)?.ToList();
        [HttpGet]
        public PlaneViewModel GetPlane(int planeId) => _plane.Read(new PlaneBindingModel { Id = planeId })?[0];
        [HttpGet]
        public List<OrderViewModel> GetOrders(int clientId) => _order.Read(new OrderBindingModel { ClientId = clientId });
        [HttpPost]
        public void CreateOrder(CreateOrderBindingModel model) => _main.CreateOrder(model);
    }
}
