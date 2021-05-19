using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace oxymeter_netcore.Domain.Models
{
    public class RestResponseContainer<T>
    {
        public T response { get; set; }
        public bool isSucceed { get; set; }
        public string errorCode { get; set; }

    }
}
