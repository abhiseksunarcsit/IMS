using IMS_Morning.DataAccess.Models.DataModels;
using IMS_Morning.DataAccess.Models.Healper;
using IMS_Morning.DataAccess.Models.RequestArgs;
using IMS_Morning.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IMSMorning.Host.Controllers
{
[Route("api/Categoriescontroller")]
[ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoriesServices _categoryServices;
        public CategoriesController(ICategoriesServices categoryServices)
        {
            _categoryServices = categoryServices;
        }

        [HttpPost]
        [Route("CreateCategory")]

        public IActionResult CreateCategory(CategoriesModel categories)
        {
            var result = _categoryServices.CreateCategory(categories);
            if (result.Success)
                return Ok("Create category success");

            else
                return BadRequest(result.Message);
        }

        [HttpDelete]
        [Route("DeleteCategory")]
        public IActionResult DeleteCategory([FromBody] CustomerRequestArgs requestArgs)
        {
            var result = _categoryServices.DeleteCategory(requestArgs.CustomerId);
            if (result.Success)
                return Ok(result.Message);

            else
                return BadRequest(result.Message);
        }

        [HttpPut]
        [Route("UpdateCategory")]

        public IActionResult UpdateCategory(CategoriesModel model)
        {

            var result = _categoryServices.UpdateCategory(model);

            if (result.Success)
                return Ok(result.Message);

            else
                return BadRequest(result.Message);
        }


        [HttpGet]
        [Route("GetAllCategory")]
        public IActionResult GetAllCategory()
        {
            DataResult<CategoriesModel> result = _categoryServices.GetAllCategory();


            if (result.Success)
                return Ok(result);

            else
                return BadRequest(result.Message);
        }
        [HttpGet]
        [Route("GetCategoryByID")]
        public IActionResult GetCategoryByID(int CategoryID)
        {
            DataResult<CategoriesModel> result = _categoryServices.GetCategoryByID(CategoryID);


            if (result.Success)
                return Ok(result.Message);

            else
                return BadRequest(result.Message);

        }


    
}

}
