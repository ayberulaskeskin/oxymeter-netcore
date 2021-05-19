using oxymeter_netcore.DataAccess.Models;
using oxymeter_netcore.Domain.Models.Request;
using oxymeter_netcore.Domain.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace oxymeter_netcore.DataAccess.DAO.Interface
{
    public interface IUserDataAccess
    {
        public DataAccessResponseContainer<UserInfoModel> GetUser(string tckn);
        public DataAccessResponseContainer<EmptyResponse> Register(RegisterModel request);
        public DataAccessResponseContainer<UserLoginModelAUK> Login(LoginModel request);

    }
}
