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
    public class UserService : IUserService
    {
        private readonly IUserDataAccess _userDataAccess;

        public UserService(IUserDataAccess userDataAccess)
        {
            _userDataAccess = userDataAccess;
        }
        public BusinessResponseContainer<UserInfoModel> GetUser(GetUserModel request)
        {
            BusinessResponseContainer<UserInfoModel> result = new BusinessResponseContainer<UserInfoModel>();
            //Validation
            if (request.Tckn == null || request.Tckn == "")
            {
                result.isSucceed = false;
                result.errorCode = "TCKN cannot be null or empty";
            } else if (request.Tckn.Length < 11 || request.Tckn.Length > 11)
            {
                result.isSucceed = false;
                result.errorCode = "TCKN should contain 11 digits";
            }
            else
            {
                //Call Data Access Layer - GetUser
                DataAccessResponseContainer<UserInfoModel> daoResult = _userDataAccess.GetUser(request.Tckn);
                if(daoResult.DataAccessResponse == null)
                {
                    //User not exist
                    result.isSucceed = false;
                    result.errorCode = "User Not Exist";
                }
                else
                {
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
            }
            return result;

        }

        public BusinessResponseContainer<EmptyResponse> Register(RegisterModel request)
        {
            BusinessResponseContainer<EmptyResponse> result = new BusinessResponseContainer<EmptyResponse>();
            //Validations
            if (request.Tckn == null || request.Name == null || request.Surname == null || request.Birthdate == null || request.Password == null || request.Gender == null)
            {
                result.isSucceed = false;
                result.errorCode = "Required fields cannot be null";
            }
            else
            {
                //Call Data Access Layer - Register
                DataAccessResponseContainer<EmptyResponse> daoResult = _userDataAccess.Register(request);
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

        public BusinessResponseContainer<UserLoginModelAUK> Login(LoginModel request)
        {
            BusinessResponseContainer<UserLoginModelAUK> result = new BusinessResponseContainer<UserLoginModelAUK>();
            //Validations
            if (request.Tckn == null || request.Password == null )
            {
                result.isSucceed = false;
                result.errorCode = "Required fields cannot be null";
            }
            else
            {
                //Call Data Access Layer - Register
                DataAccessResponseContainer<UserLoginModelAUK> daoResult = _userDataAccess.Login(request);
                if(daoResult.DataAccessResponse == null)
                {
                    //Login failed
                    result.isSucceed = false;
                    result.errorCode = "Pasword or Tckn is wrong";
                }
                else
                {
                    if (daoResult.isSucceed == true)
                    {
                        result.BusinessResponse = daoResult.DataAccessResponse;
                        result.isSucceed = true;

                    }
                    else
                    {
                        result.errorCode = daoResult.errorCode;
                        result.isSucceed = false;
                    }
                }
            }
            return result;
        }



    }
}
