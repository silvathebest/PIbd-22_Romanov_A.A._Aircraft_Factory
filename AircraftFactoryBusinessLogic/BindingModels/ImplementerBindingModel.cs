using System;
using System.Collections.Generic;
using System.Text;

namespace AircraftFactoryBusinessLogic.BindingModels
{
    /// <summary>
    /// Исполнитель, выполняющий заказы
    /// </summary>
    public class ImplementerBindingModel
    {
        public int? Id { get; set; }
        public string ImplementerFIO { get; set; }
        public int WorkingTime { get; set; }
        public int PauseTime { get; set; }
    }
}
