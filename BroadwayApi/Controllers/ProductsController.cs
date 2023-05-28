using IMS_Morning.DataAccess.Interfaces;
using IMS_Morning.DataAccess.Models.DataModels;
using IMS_Morning.DataAccess.Models.Healper;
using IMS_Morning.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace IMSMorning.Host.Controllers
{
    [ApiController]
    [Route("ProductController")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductServices _ProductServices;

        public ProductsController(IProductServices ProductServices)
        {
            _ProductServices = ProductServices;

        }
        [HttpPost]
        [Route("CreateProduct")]

        public IActionResult CreateProduct(ProductsModel model)
        {
            var result = _ProductServices.CreateProduct(model);
            if (result.Success)
                return Ok(result.Message);

            else
                return BadRequest(result.Message);
        }

        [HttpDelete]
        [Route("DeleteProduct")]

        public IActionResult DeleteProduct(int ProductID)
        {
            var result = _ProductServices.DeleteProduct(ProductID);
            if (result.Success)
                return Ok(result.Message);

            else
                return BadRequest(result.Message);
        }

        [HttpPut]
        [Route("UpdateProduct")]

        public IActionResult UpdateProduct(ProductsModel model)
        {
            var result = _ProductServices.UpdateProduct(model);
            if (result.Success)
                return Ok(result.Message);

            else
                return BadRequest(result.Message);
        }

        [HttpGet]
        [Route("GetAllProducts")]
        public IActionResult GetAllProduct()
        {
            DataResult<ProductsModel> result = _ProductServices.GetAllProducts();

            if (result.Success)
                return Ok(result);

            else
                return BadRequest(result.Message);
        }
        [HttpGet]
        [Route("GetProductByID")]

        public IActionResult GetProductByID(int ProductID)
        {
            DataResult<ProductsModel> result = _ProductServices.GetProductByID(ProductID);

            if (result.Success)
                return Ok(result.Message);

            else
                return BadRequest(result.Message);

        }

    }

}
