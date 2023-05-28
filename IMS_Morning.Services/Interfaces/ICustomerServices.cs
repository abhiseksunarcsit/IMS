using IMS_Morning.DataAccess.Models.DataModels;
using IMS_Morning.DataAccess.Models.Healper;
using IMS_Morning.DataAccess.Models.RequestArgs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS_Morning.Services.Interfaces
{
    public interface ICustomerServices
    {
        DataResult<CustomerModel> GetCustomerByID(int CustomerID);
        DataResult<CustomerModel> GetAllCustomers();
        DataResult CreateCustomer(CustomerModel customer);
        DataResult DeleteCustomer(int CustomerID);
        DataResult UpdateCustomer(CustomerModel customer);
    }
}
