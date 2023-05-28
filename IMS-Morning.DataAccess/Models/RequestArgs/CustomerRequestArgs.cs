using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS_Morning.DataAccess.Models.RequestArgs
{
    public class CustomerRequestArgs
    {
        public int CustomerId { get; set; }
        public string CompanyName { get; set; }

        public string Address { get; set; }
        public string City { get; set; }
    }
}
