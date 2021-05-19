using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace oxymeter_netcore.DataAccess.Models
{
    public class DataAccessResponseContainer<T>
    {
        public T DataAccessResponse { get; set; }
        public bool isSucceed { get; set; }
        public string errorCode { get; set; }
    }
}
