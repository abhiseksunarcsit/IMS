using IMS_Morning.DataAccess.Interfaces;
using IMS_Morning.DataAccess.Models.DataModels;
using IMS_Morning.DataAccess.Models.Healper;
using IMS_Morning.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace IMS_Morning.Services.Services
{
    public class ProductServices:IProductServices
    {
        private readonly IProductRepositories _repository;

        public ProductServices(IProductRepositories repository)
        {
            _repository = repository;
        }

        public DataResult CreateProduct(ProductsModel products)
        {

            DataResult result = new DataResult();
            if (products.ProductName == null)
            {
                result.Success = false;
                result.Message = "product name is required";

            }
            result = _repository.CreateProduct(products);
            result.Message = "Data inserted successfully and changed message from services";
            return result;
        }

        public DataResult DeleteProduct(int ProductID)
        {
            return _repository.DeleteProduct(ProductID);
        }

        public DataResult<ProductsModel> GetAllProducts()
        {
            
            return _repository.GetAllProducts();
        }

        public DataResult<ProductsModel> GetProductByID(int ProductID)
        {
            return _repository.GetProductByID(ProductID);
        }

        public DataResult UpdateProduct(ProductsModel products)
        {
            DataResult dataResult = new DataResult();
            if (products != null)
            {
                dataResult.Success = true;
                dataResult.Message = "";
            }
            return dataResult;
        }
    }
}
