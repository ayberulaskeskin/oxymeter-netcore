using oxymeter_netcore.Business.Interfaces;
using oxymeter_netcore.Business.Models;
using oxymeter_netcore.DataAccess.DAO.Interface;
using oxymeter_netcore.DataAccess.Models;
using oxymeter_netcore.Domain.Models.Request;
using oxymeter_netcore.Domain.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace oxymeter_netcore.Business.Services
{
    public class MedicalRecordService:IMedicalRecordService
    {
        private readonly IMedicalRecordDataAccess _MedicalRecordDataAccess;

        public MedicalRecordService(IMedicalRecordDataAccess MedicalRecordDataAccess)
        {
            _MedicalRecordDataAccess = MedicalRecordDataAccess;
        }
        public BusinessResponseContainer<List<MedicalRecordInfoModel>> GetMedicalRecord(GetMedicalRecordModel request)
        {
            BusinessResponseContainer<List<MedicalRecordInfoModel>> result = new BusinessResponseContainer<List<MedicalRecordInfoModel>>();
            //Validation
            if (request.Tckn == null || request.Tckn == "")
            {
                result.isSucceed = false;
                result.errorCode = "TCKN cannot be null or empty";
            }
           
            else
            {
                //Call Data Access Layer - GetUser
                DataAccessResponseContainer<List<MedicalRecordInfoModel>> daoResult = _MedicalRecordDataAccess.GetMedicalRecord(request.Tckn);
                if (daoResult.isSucceed == false)
                {
                    result.isSucceed = false;
                    result.errorCode = daoResult.errorCode;
                }
                else
                {
                    result.BusinessResponse = daoResult.DataAccessResponse;
                    result.isSucceed = true;
                }
            }
            return result;




        }
        public BusinessResponseContainer<EmptyResponse> AddMedicalRecord(AddMedicalRecordModel request)
        {
            BusinessResponseContainer<EmptyResponse> result = new BusinessResponseContainer<EmptyResponse>();
            //Validation
            if (request.Tckn == null || request.Tckn == ""||request.Hr== null || request.Hr == ""|| request.Spo2 == null || request.Spo2 == ""|| request.MeasurementDate == null  )
            {
                result.isSucceed = false;
                result.errorCode = "Request is not valid";
            }

            else
            {
                //Call Data Access Layer - GetUser
                DataAccessResponseContainer<EmptyResponse> daoResult = _MedicalRecordDataAccess.AddMedicalRecord(request);
                if (daoResult.isSucceed == false)
                {
                    result.isSucceed = false;
                    result.errorCode = daoResult.errorCode;
                }
                else
                {
                    result.BusinessResponse = daoResult.DataAccessResponse;
                    result.isSucceed = true;
                }
            }
            return result;




        }
    }
}
