using System;
using System.Collections.Generic;
using System.Text;

namespace AircraftFactoryBusinessLogic.HelperModels
{
    public class MailConfig
    {
        public string SmtpClientHost { get; set; }
        public int SmtpClientPort { get; set; }
        public string MailLogin { get; set; }
        public string MailPassword { get; set; }
    }
}
