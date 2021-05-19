using Dapper;
using MySql.Data.MySqlClient;
using oxymeter_netcore.DataAccess.DAO.Interface;
using oxymeter_netcore.DataAccess.Models;
using oxymeter_netcore.DataAccess.Query;
using oxymeter_netcore.Domain.Models.Request;
using oxymeter_netcore.Domain.Models.Response;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace oxymeter_netcore.DataAccess.DAO.Service
{
    public class UserDataAccess : IUserDataAccess
    {
        private readonly MySqlConnection _connection;

        public UserDataAccess(MySqlConnection connection)
        {
            _connection = connection;
        }
        public DataAccessResponseContainer<UserInfoModel> GetUser(string tckn)
        {
            DataAccessResponseContainer<UserInfoModel> daoResult = new DataAccessResponseContainer<UserInfoModel>();
            QueryHandler qHandler = new QueryHandler("GetUser");
            try
            {
                UserInfoModel user = _connection.Query<UserInfoModel>(qHandler.selectedQuery, new { tckn = tckn }).FirstOrDefault();
                daoResult.DataAccessResponse = user;
                daoResult.isSucceed = true;
                return daoResult;
            }
            catch(Exception e)
            {
                daoResult.isSucceed = false;
                daoResult.errorCode = e.Message;
                return daoResult;
            }
            

        }

        public DataAccessResponseContainer<EmptyResponse> Register(RegisterModel request)
        {
            DataAccessResponseContainer<EmptyResponse> daoResult = new DataAccessResponseContainer<EmptyResponse>();
            bool userExist = true;
            try
            {
                QueryHandler qHandlerGetUser = new QueryHandler("GetUser");
                UserInfoModel user = _connection.QueryFirst<UserInfoModel>(qHandlerGetUser.selectedQuery, new { tckn = request.Tckn });
                
            }
            catch
            {
                userExist = false;
            }
            if (userExist == true)
            {
                //User already exists
                daoResult.isSucceed = false;
                daoResult.errorCode = "Given user is already exists";
                return daoResult;
            }
            else
            {
                try
                {
                    //User not exists then we can register
                    QueryHandler qHandler = new QueryHandler("Register");
                    _connection.Execute(qHandler.selectedQuery, request);
                    daoResult.isSucceed = true;
                    return daoResult;
                } catch (Exception ex)
                {
                    var a = ex;
                    daoResult.isSucceed = false;
                    daoResult.errorCode = "Error happened in registiration";
                    return daoResult;
                }
                
            }
        }

        public DataAccessResponseContainer<UserLoginModelAUK> Login(LoginModel request)
        {
            DataAccessResponseContainer<UserLoginModelAUK> daoResult = new DataAccessResponseContainer<UserLoginModelAUK>();
            
            try
            {
                QueryHandler qHandlerLogin;
                if(request.SourceSystem == "desktop")
                {
                    qHandlerLogin = new QueryHandler("AdminLogin");
                }
                else
                {
                    qHandlerLogin = new QueryHandler("Login");
                }
                UserLoginModelAUK user = _connection.Query<UserLoginModelAUK>(qHandlerLogin.selectedQuery, new { tckn = request.Tckn ,password=request.Password}).FirstOrDefault();
                
                daoResult.isSucceed = true;
                daoResult.DataAccessResponse = user;
                return daoResult;
            }
            catch(Exception e)
            {
                daoResult.isSucceed = false;
                daoResult.errorCode = e.Message;
                return daoResult;
            }
          
         





        }
    }
}
