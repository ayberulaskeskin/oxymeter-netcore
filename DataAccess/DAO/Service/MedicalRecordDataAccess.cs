using Dapper;
using MySql.Data.MySqlClient;
using oxymeter_netcore.DataAccess.DAO.Interface;
using oxymeter_netcore.DataAccess.Models;
using oxymeter_netcore.DataAccess.Query;
using oxymeter_netcore.Domain.Models.Request;
using oxymeter_netcore.Domain.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace oxymeter_netcore.DataAccess.DAO.Service
{
    public class MedicalRecordDataAccess : IMedicalRecordDataAccess
    {
        private readonly MySqlConnection _connection;

        public MedicalRecordDataAccess(MySqlConnection connection)
        {
            _connection = connection;
        }
        public DataAccessResponseContainer<List<MedicalRecordInfoModel>> GetMedicalRecord(string tckn)
        {
            DataAccessResponseContainer<List<MedicalRecordInfoModel>> daoResult = new DataAccessResponseContainer<List<MedicalRecordInfoModel>>();
            QueryHandler qHandler = new QueryHandler("GetMedicalRecord");
            try
            {
                List<MedicalRecordInfoModel> user = _connection.Query<MedicalRecordInfoModel>(qHandler.selectedQuery, new { Tckn = tckn }).ToList();
                daoResult.DataAccessResponse = user;
                daoResult.isSucceed = true;
                return daoResult;
            }
            catch(Exception e)
            {
                daoResult.isSucceed = false;
                daoResult.errorCode = "User not found";
                return daoResult;
            }

        }


        public DataAccessResponseContainer<EmptyResponse> AddMedicalRecord(AddMedicalRecordModel request)
        {
            DataAccessResponseContainer<EmptyResponse> daoResult = new DataAccessResponseContainer<EmptyResponse>();
            QueryHandler qHandler = new QueryHandler("AddMedicalRecord");
            try
            {
                //User not exists then we can register
               
                _connection.Execute(qHandler.selectedQuery, request);
                daoResult.isSucceed = true;
                return daoResult;
            }
            catch (Exception ex)
            {
                var a = ex;
                daoResult.isSucceed = false;
                daoResult.errorCode = "Error happened ";
                return daoResult;
            }

        }
    }
}
