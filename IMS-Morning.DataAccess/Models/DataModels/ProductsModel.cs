using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS_Morning.DataAccess.Models.DataModels
{
    public class ProductsModel
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int UnitPrice { get; set; }

        public int UnitsInStock { get; set; }
        public int CategoryID { get; set; }
    }
}
