using IMS_Morning.DataAccess.Models.DataModels;
using IMS_Morning.DataAccess.Models.Healper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS_Morning.DataAccess.Interfaces
{
    public interface IProductRepositories
    {
        DataResult CreateProduct(ProductsModel products);

        DataResult DeleteProduct(int ProductID);

        DataResult UpdateProduct(ProductsModel products);
        DataResult<ProductsModel> GetAllProducts();
        DataResult<ProductsModel> GetProductByID(int ProductID);
    }
}
