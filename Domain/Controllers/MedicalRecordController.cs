
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
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
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalRecordController : ControllerBase
    {
        private readonly IMedicalRecordService _MedicalRecordService;

        public MedicalRecordController(IMedicalRecordService MedicalRecordService)
        {
            _MedicalRecordService = MedicalRecordService;
        }
        // GET: api/<UserController>
        [HttpPost]
        [Route("GetMedicalRecord")]
        public IActionResult GetMedicalRecord([FromBody] GetMedicalRecordModel request)
        {
            RestResponseContainer<List<MedicalRecordInfoModel>> resp = new RestResponseContainer<List<MedicalRecordInfoModel>>();


            //Business Service call - GetUser
            BusinessResponseContainer<List<MedicalRecordInfoModel>> result = _MedicalRecordService.GetMedicalRecord(request);

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
        [Route("AddMedicalRecord")]
        public IActionResult AddMedicalRecord([FromBody] AddMedicalRecordModel request)
        {
            RestResponseContainer<EmptyResponse> resp = new RestResponseContainer<EmptyResponse>();


            //Business Service call - GetUser
            BusinessResponseContainer<EmptyResponse> result = _MedicalRecordService.AddMedicalRecord(request);

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
