using IMS_Morning.DataAccess.Models.DataModels;
using IMS_Morning.DataAccess.Models.Healper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS_Morning.Services.Interfaces
{
    public interface IProductServices
    {
        DataResult<ProductsModel> GetProductByID(int ProductID);
        DataResult<ProductsModel> GetAllProducts();
        DataResult CreateProduct(ProductsModel products);
        DataResult DeleteProduct(int ProductID);
        DataResult UpdateProduct(ProductsModel products);
    }
}
