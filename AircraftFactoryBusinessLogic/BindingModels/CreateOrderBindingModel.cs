using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace AircraftFactoryBusinessLogic.BindingModels
{
    /// <summary>
    /// Данные от клиента, для создания заказа
    /// </summary>
    [DataContract]
    public class CreateOrderBindingModel
    {
        [DataMember]
        public int ClientId { get; set; }
        [DataMember]
        public string ClientFIO { get; set; }
        [DataMember]
        public int PlaneId { get; set; }
        [DataMember]
        public int Count { get; set; }
        [DataMember]
        public decimal Sum { get; set; }
    }

}
