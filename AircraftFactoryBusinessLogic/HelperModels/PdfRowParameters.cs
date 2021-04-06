using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace AircraftFactoryBusinessLogic.HelperModels
{
    class PdfRowParameters
    {
        public Table Table { get; set; }
        public List<string> Texts { get; set; }
        public string Style { get; set; }
        public ParagraphAlignment ParagraphAlignment
        {
            get; set;
        }
    }
}
