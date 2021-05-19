using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace oxymeter_netcore.Domain.Models.Request
{
    public class AddMedicalRecordModel
    {
        public string Spo2 { get; set; }
        public string Hr { get; set; }

        public string PatientStory { get; set; }
        public DateTime MeasurementDate { get; set; }

        public string HesCode { get; set; }
        public string Tckn { get; set; }

    }
}
