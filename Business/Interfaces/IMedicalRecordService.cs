using oxymeter_netcore.Business.Models;
using oxymeter_netcore.Domain.Models.Request;
using oxymeter_netcore.Domain.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace oxymeter_netcore.Business.Interfaces
{
    public interface IMedicalRecordService
    {
        public BusinessResponseContainer<List<MedicalRecordInfoModel>> GetMedicalRecord(GetMedicalRecordModel request);
        public BusinessResponseContainer<EmptyResponse> AddMedicalRecord(AddMedicalRecordModel request);
    }
    
    
       
    
}
