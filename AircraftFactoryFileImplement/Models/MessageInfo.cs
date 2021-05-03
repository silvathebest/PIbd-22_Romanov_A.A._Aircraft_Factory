using System;
using System.Collections.Generic;
using System.Text;

namespace AircraftFactoryFileImplement.Models
{
    /// <summary>
    /// Сообщения, приходящие на почту
    /// </summary>
    public class MessageInfo
    {
        public string MessageId { get; set; }
        public int? ClientId { get; set; }
        public string SenderName { get; set; }
        public DateTime DateDelivery { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
