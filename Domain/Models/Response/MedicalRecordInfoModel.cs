using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace oxymeter_netcore.Domain.Models.Response
{
    public class MedicalRecordInfoModel
    {
        public string Tckn { get; set; }
        public DateTime Date { get; set; }
        public string HearthRate { get; set; }
        public string OxygenRate { get; set; }
        public string HesCode { get; set; }
        public string PatientStory { get; set; }

    }
}
