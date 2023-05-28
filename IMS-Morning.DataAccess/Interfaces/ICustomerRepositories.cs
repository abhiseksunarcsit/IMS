using IMS_Morning.DataAccess.Models.DataModels;
using IMS_Morning.DataAccess.Models.Healper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS_Morning.DataAccess.Interfaces
{
    public interface ICustomerRepositories
    {
        DataResult CreateCustomer(CustomerModel customer);
        DataResult CreateCustomer1(String CustomerName, String Address, string City, string Region, int Phone);
        DataResult DeleteCustomer(int CustomerId);

        DataResult UpdataCustomer(CustomerModel customer);

        DataResult <CustomerModel> GetAllCustomers();
        DataResult<CustomerModel> GetCustomerByID(int ProductID);
    }
}
