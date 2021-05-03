using AircraftFactoryBusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AircraftFactoryBusinessLogic.HelperModels
{
    public class MailCheckInfo
    {
        public string PopHost { get; set; }
        public int PopPort { get; set; }
        public IMessageInfoStorage MessageInfoStorage { get; set; }
        public IClientStorage ClientStorage { get; set; }
    }
}
