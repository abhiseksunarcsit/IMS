using IMS_Morning.DataAccess.Interfaces;
using IMS_Morning.DataAccess.Models.DataModels;
using IMS_Morning.DataAccess.Models.Healper;
using IMS_Morning.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS_Morning.Services.Services
{
    public class CategoriesServices : ICategoriesServices
    {
        private ICategoriesRepositories _repository;
        public CategoriesServices(ICategoriesRepositories repository) 
        {
            _repository = repository;

        }
        public DataResult CreateCategory(CategoriesModel categories)
        {
            DataResult result = new DataResult();
            if (categories.CategoryName == null)
            {
                result.Success = false;
                result.Message = "Category name is required";

            }
            result = _repository.CreateCategory(categories);
            result.Message = "Data inserted successfully and changed message from services";
            return result;
        }

        public DataResult DeleteCategory(int CategoryID)
        {
            return _repository.DeleteCategory(CategoryID);
        }

        public DataResult<CategoriesModel> GetAllCategory()
        {
           return _repository.GetAllCategory();
        }

        public DataResult<CategoriesModel> GetCategoryByID(int CategoryID)
        {
            return _repository.GetCategoryByID(CategoryID);
        }

        public DataResult UpdateCategory(CategoriesModel categories)
        {
            return _repository.UpdateCategory(categories);
        }
    }
}
