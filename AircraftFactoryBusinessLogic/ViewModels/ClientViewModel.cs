using AircraftFactoryBusinessLogic.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;

namespace AircraftFactoryBusinessLogic.ViewModels
{
    [DataContract]
    public class ClientViewModel
    {
        [Column(title: "Номер", width: 100)]
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        [Column(title: "Клиент", width: 150)]
        public string FIO { get; set; }
        [DataMember]
        [Column(title: "Email", width: 100)]
        public string Email { get; set; }
        [DataMember]
        [Column(title: "Пароль", width: 100)]
        public string Password { get; set; }
    }
}
