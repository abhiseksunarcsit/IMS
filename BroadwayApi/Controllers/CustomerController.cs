using IMS_Morning.DataAccess.Interfaces;
using IMS_Morning.DataAccess.Models.DataModels;
using IMS_Morning.DataAccess.Models.Healper;
using IMS_Morning.DataAccess.Models.RequestArgs;
using IMS_Morning.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace IMSMorning.Host.Controllers
{
    [ApiController]
    [Route("CustomerController")]
    public class CustomerController:ControllerBase
    {
        private readonly ICustomerServices _customerServices;
        public CustomerController(ICustomerServices customerServices)
        {
            _customerServices = customerServices; 

        }
        [HttpPost]
        [Route("CreateCustomer")]
      
        public IActionResult CreateCustomer(CustomerModel model)
        {
            var result = _customerServices.CreateCustomer(model);
            if (result.Success)
                return Ok(result.Message);

            else
                return BadRequest(result.Message);
        }

        [HttpDelete]
        [Route("DeleteCustomer")]
        public IActionResult DeleteCustomer([FromBody] CustomerRequestArgs requestArgs)
        {
            var result = _customerServices.DeleteCustomer(requestArgs.CustomerId);
            if (result.Success)
                return Ok(result.Message);

            else
                return BadRequest(result.Message);
        }
       
        [HttpPut]
        [Route("UpdateCustomer")]

        public IActionResult UpdateCustomer(CustomerModel model)
        {
            
            var result = _customerServices.UpdateCustomer(model);

            if (result.Success)
                return Ok(result.Message);

            else
                return BadRequest(result.Message);
        }
        

        [HttpGet]
        [Route("GetAllCustomer")]
        public IActionResult GetAllCustomers()
        {
            DataResult<CustomerModel> result = _customerServices.GetAllCustomers();
           

            if (result.Success)
                return Ok(result);

            else
                return BadRequest(result.Message);
        }
        [HttpGet]
        [Route("GetCustomerByID")]
        public IActionResult GetCustomerByID([FromQuery] CustomerRequestArgs requestArgs)
        {
            DataResult<CustomerModel> result = _customerServices.GetCustomerByID(requestArgs.CustomerId);


            if (result.Success)
                return Ok(result.Message);

            else
                return BadRequest(result.Message);
            
        }


    }
}
