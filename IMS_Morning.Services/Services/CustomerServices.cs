using IMS_Morning.DataAccess.Interfaces;
using IMS_Morning.DataAccess.Models.DataModels;
using IMS_Morning.DataAccess.Models.Healper;
using IMS_Morning.DataAccess.Models.RequestArgs;
using IMS_Morning.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS_Morning.Services.Service
{
    public class CustomerServices : ICustomerServices
    {
        private readonly ICustomerRepositories _repository;

        public CustomerServices(ICustomerRepositories repository)
        {
            _repository = repository;
        }




        public DataResult CreateCustomer(CustomerModel customer)
        {
            DataResult result = new DataResult();
           if (customer.CustomerName == null)
            {
                result.Success = false;
                result.Message = "Company name is required";
               
            }
            result = _repository.CreateCustomer(customer);
            result.Message = "Data inserted successfully and changed message from services";
            return result;
        }

       

        public DataResult DeleteCustomer(int CustomerID)
        {
            return _repository.DeleteCustomer(CustomerID);
        }

        public DataResult<CustomerModel> GetAllCustomers()
        {
            return _repository.GetAllCustomers();
        }

        public DataResult<CustomerModel> GetCustomerByID(int  CustomerID)
        {

            return _repository.GetCustomerByID(CustomerID);
        }

        public DataResult UpdateCustomer(CustomerModel model)
        {
            DataResult dataResult = new DataResult();   
            if(model != null)
            {
                dataResult.Success = true;
                dataResult.Message = "";
            }
            return dataResult;
        }
    }
}
