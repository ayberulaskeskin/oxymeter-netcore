using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace oxymeter_netcore.Domain.Models.Request
{
    public class RegisterModel
    {
        public string Tckn { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public DateTime Birthdate { get; set; }

        public string Gender { get; set; }

        public string Role { get; set; }
    }
}
