using AircraftFactoryBusinessLogic.BindingModels;
using AircraftFactoryBusinessLogic.BusinessLogics;
using AircraftFactoryBusinessLogic.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AircraftFactoryRestApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class WarehouseController : ControllerBase
    {
        private readonly WarehouseLogic warehouseLogic;
        private readonly ComponentLogic componentLogic;
        public WarehouseController(WarehouseLogic warehouseLogic, ComponentLogic сomponentLogic)
        {
            this.warehouseLogic = warehouseLogic;
            this.componentLogic = сomponentLogic;
        }

        public List<WarehouseViewModel> GetAll() => warehouseLogic.Read(null);

        public List<ComponentViewModel> GetAllComponents() => componentLogic.Read(null);

        [HttpPost]
        public void Create(WarehouseBindingModel model) => warehouseLogic.CreateOrUpdate(model);

        [HttpPost]
        public void Update(WarehouseBindingModel model) => warehouseLogic.CreateOrUpdate(model);

        [HttpPost]
        public void Delete(WarehouseBindingModel model) => warehouseLogic.Delete(model);

        [HttpPost]
        public void AddComponent(AddComponentsBindingModel model) => warehouseLogic.AddComponent(model);
    }
}
