using System;

namespace oxymeter_netcore.Domain.Models.Response
{
    public class UserInfoModel
    {
        public string tckn { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public DateTime birthdate { get; set; }
        public string gender { get; set; }
    }
}
