
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using oxymeter_netcore.Business.Interfaces;
using oxymeter_netcore.Business.Models;
using oxymeter_netcore.Domain.Models;
using oxymeter_netcore.Domain.Models.Request;
using oxymeter_netcore.Domain.Models.Response;

namespace oxymeter_netcore.Domain.Controllers
{
    [EnableCors("_allowSpecificOrigins")]
    [Route("api/[controller]/")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        // GET: api/<UserController>
        [HttpPost]
        [Route("GetUser")]
        public IActionResult GetUser([FromBody] GetUserModel request)
        {
            RestResponseContainer<UserInfoModel> resp = new RestResponseContainer<UserInfoModel>();


            //Business Service call - GetUser
            BusinessResponseContainer<UserInfoModel> result = _userService.GetUser(request);

            if(result.isSucceed == false)
            {
                resp.isSucceed = false;
                resp.errorCode = result.errorCode;
                return NotFound(resp);//404
            }
            else
            {
                resp.response = result.BusinessResponse;
                resp.isSucceed = true;
                return Ok(resp);//200
            }
        }
        // GET: api/<UserController>
        [HttpPost]
        [Route("Register")]
        public IActionResult Register([FromBody] RegisterModel request)
        {
            RestResponseContainer<EmptyResponse> resp = new RestResponseContainer<EmptyResponse>();

            //Business Service call - GetUser
            BusinessResponseContainer<EmptyResponse> result = _userService.Register(request);

            if (result.isSucceed == false)
            {
                resp.isSucceed = false;
                resp.errorCode = result.errorCode;
                return NotFound(resp);//404
            }
            else
            {
                resp.response = result.BusinessResponse;
                resp.isSucceed = true;
                return Ok(resp);//200
            }
        }



        [HttpPost]
        [Route("Login")]
        public IActionResult Login([FromBody] LoginModel request)
        {
            RestResponseContainer<UserLoginModelAUK> resp = new RestResponseContainer<UserLoginModelAUK>();

            //Business Service call - GetUser
            BusinessResponseContainer<UserLoginModelAUK> result = _userService.Login(request);

            if (result.isSucceed == false)
            {
                resp.isSucceed = false;
                resp.errorCode = result.errorCode;
                return NotFound(resp);//404
            }
            else
            {
                resp.response = result.BusinessResponse;
                resp.isSucceed = true;
                return Ok(resp);//200
            }
        }
    }
}
