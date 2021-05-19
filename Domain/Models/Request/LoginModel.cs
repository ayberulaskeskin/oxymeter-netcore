using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace oxymeter_netcore.Domain.Models.Request
{
    public class LoginModel
    {
        public string Tckn { get; set; }
        public string Password { get; set; }
        public string SourceSystem { get; set; }
    }
}
