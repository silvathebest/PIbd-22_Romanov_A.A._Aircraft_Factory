using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;

namespace AircraftFactoryBusinessLogic.ViewModels
{
    /// <summary>
    /// Сообщения, приходящие на почту
    /// </summary>
    [DataContract]
    public class MessageInfoViewModel
    {
        [DataMember]
        public string MessageId { get; set; }
        [DisplayName("Отправитель")]
        [DataMember]
        public string SenderName { get; set; }
        [DisplayName("Дата письма")]
        [DataMember]
        public DateTime DateDelivery { get; set; }
        [DisplayName("Заголовок")]
        [DataMember]
        public string Subject { get; set; }
        [DisplayName("Текст")]
        [DataMember]
        public string Body { get; set; }
    }
}
