using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace AircraftFactoryBusinessLogic.ViewModels
{
    /// <summary>
    /// Исполнитель, выполняющий заказы
    /// </summary>
    public class ImplementerViewModel
    {
        public int Id { get; set; }
        [DisplayName("ФИО исполнителя")]
        public string ImplementerFIO { get; set; }
        [DisplayName("Время на заказ")]
        public int WorkingTime { get; set; }
        [DisplayName("Время на перерыв")]
        public int PauseTime { get; set; }
    }
}
