using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS_Morning.DataAccess.Models.Healper
{
    public class DataResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }


    }

    //polymorphism and generic use

    public class DataResult<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public List<T> Data { get; set; }

    }
}
