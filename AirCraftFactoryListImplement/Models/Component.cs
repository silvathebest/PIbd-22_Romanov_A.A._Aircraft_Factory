using System;
using System.Collections.Generic;
using System.Text;

namespace AirCraftFactoryListImplement.Models
{
    /// <summary>
    /// Компонент, требуемый для изготовления изделия
    /// </summary>
    public class Component
    {
        public int Id { get; set; }
        public string ComponentName { get; set; }
    }
}
