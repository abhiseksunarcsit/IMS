using IMS_Morning.DataAccess.Models.DataModels;
using IMS_Morning.DataAccess.Models.Healper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS_Morning.DataAccess.Interfaces
{
    public interface ICategoriesRepositories
    {
        DataResult<CategoriesModel> GetCategoryByID(int CategoryID);
        DataResult<CategoriesModel> GetAllCategory();
        DataResult CreateCategory(CategoriesModel categories);
        DataResult DeleteCategory(int CategoryID);
        DataResult UpdateCategory(CategoriesModel categories);
    }
}
