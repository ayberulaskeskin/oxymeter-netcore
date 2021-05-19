using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace oxymeter_netcore.Business.Models
{
    public class BusinessResponseContainer<T>
    {
        public T BusinessResponse{get;set;}
        public bool isSucceed { get; set; }
        public string errorCode { get; set; }
    }
}
