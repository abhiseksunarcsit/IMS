using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS_Morning.DataAccess.Models.DataModels
{
    public class CustomerModel
    {
        public int CustomerId { get; set; }
        public string ?CustomerName { get; set; }

        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public long Phone { get; set; }
    }
}
