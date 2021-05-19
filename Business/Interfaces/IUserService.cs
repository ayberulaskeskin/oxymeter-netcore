using oxymeter_netcore.Business.Models;
using oxymeter_netcore.Domain.Models.Request;
using oxymeter_netcore.Domain.Models.Response;

namespace oxymeter_netcore.Business.Interfaces
{
    public interface IUserService
    {
        public BusinessResponseContainer<UserInfoModel> GetUser(GetUserModel request);
        public BusinessResponseContainer<EmptyResponse> Register(RegisterModel request);

        public BusinessResponseContainer<UserLoginModelAUK> Login(LoginModel request);


    }
}
