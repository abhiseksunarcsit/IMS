using IMS_Morning.DataAccess.Models.DataModels;
using IMS_Morning.DataAccess.Models.Healper;
using IMS_Morning.DataAccess.Models.RequestArgs;
using IMS_Morning.Services.Interfaces;
using IMS_Morning.Services.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IMSMorning.Host.Controllers
{
 [Route("api/[controller]")]
[ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersServices _writeanyname;
        public OrdersController(IOrdersServices writeanyname) 
        {
            _writeanyname = writeanyname;
        }


        [HttpPost]
        [Route("CreateOrder")]

        public IActionResult CreateOrder(OrdersModel model)
        {
            var result = _writeanyname.CreateOrder(model);
            if (result.Success)
                return Ok(result.Message);

            else
                return BadRequest(result.Message);
        }

        [HttpDelete]
        [Route("DeleteOrder")]
        public IActionResult DeleteCustomer(int OrderID)
        {
            var result = _writeanyname.DeleteOrder(OrderID);
            if (result.Success)
                return Ok(result.Message);

            else
                return BadRequest(result.Message);
        }

        [HttpPut]
        [Route("UpdateOrder")]

        public IActionResult UpdateOrder(OrdersModel model)
        {

            var result = _writeanyname.UpdateOrder(model);

            if (result.Success)
                return Ok(result.Message);

            else
                return BadRequest(result.Message);
        }


        [HttpGet]
        [Route("GetAllOrders")]
        public IActionResult GetAllOrders()
        {
            DataResult<OrdersModel> result = _writeanyname.GetAllOrders();


            if (result.Success)
                return Ok(result);

            else
                return BadRequest(result.Message);
        }
        [HttpGet]
        [Route("GetOrderByID")]
        public IActionResult GetOrderByID([FromQuery] int OrderID)
        {
            DataResult<OrdersModel> result = _writeanyname.GetOrderByID(OrderID);


            if (result.Success)
                return Ok(result.Message);

            else
                return BadRequest(result.Message);

        }

    }
}
