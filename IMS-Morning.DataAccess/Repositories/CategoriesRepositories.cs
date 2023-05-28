using IMS_Morning.DataAccess.Interfaces;
using IMS_Morning.DataAccess.Models.DataModels;
using IMS_Morning.DataAccess.Models.Healper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS_Morning.DataAccess.Repositories
{
    public class CategoriesRepositories : ICategoriesRepositories
    {
        private readonly IConfiguration _confi;
        public CategoriesRepositories(IConfiguration confi)
        {
            _confi = confi;
        }
        public DataResult CreateCategory(CategoriesModel categories)
        {
            DataResult result = new DataResult();
            var connectionString = _confi.GetConnectionString("Defaultconnection");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                try
                {
                    SqlCommand command = new SqlCommand("InsertCategories", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CategoryName", categories.CategoryName);
                    command.Parameters.AddWithValue("@Description", categories.Description);
                    


                    connection.Open();
                    int affectedRow = command.ExecuteNonQuery();

                    if (affectedRow > 0)
                    {
                        result.Success = true;
                        result.Message = "Data insert Successfully";
                    }
                    else
                    {
                        result.Success = false;
                        result.Message = "Data inserted Failed. Please Contact your Adminisor";
                    }

                }
                catch (Exception ex)
                {
                    result.Success = false;
                    result.Message = ex.Message;


                }
                finally
                {
                    connection.Close();
                }



            }
            return result;
        }

        public DataResult DeleteCategory(int CategoryID)
        {
            throw new NotImplementedException();
        }

        public DataResult<CategoriesModel> GetAllCategory()
        {
            DataResult<CategoriesModel> result = new DataResult<CategoriesModel>();
            var connectionString = _confi.GetConnectionString("DefaultConnection");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand("GetCategories", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    DataTable data = new DataTable();
                    connection.Open();
                    adapter.SelectCommand = command;
                    adapter.Fill(data);

                    result.Data = (from DataRow dr in data.Rows
                                   select new CategoriesModel
                                   {
                                       CategoryID = Convert.ToInt32(dr["CategoryID"]),
                                       CategoryName = Convert.ToString(dr["CategoryName"]),
                                        Description= Convert.ToString(dr["Description"]),
                                       
                                   }).ToList();
                    //connection.Close();

                    int affectedRow = command.ExecuteNonQuery();

                    if (result.Data.Count > 0)
                    {
                        result.Success = true;
                        result.Message = "Get All Data Successfully";
                    }
                    else
                    {
                        result.Success = false;
                        result.Message = " NO Data Found";
                    }




                }
                catch (Exception ex)
                {
                    result.Success = false;
                    result.Message = ex.Message;
                }
                finally
                {
                    connection.Close();
                }
            }

            return result;
        
    }

        public DataResult<CategoriesModel> GetCategoryByID(int CategoryID)
        {
            throw new NotImplementedException();
        }

        public DataResult UpdateCategory(CategoriesModel categories)
        {
            throw new NotImplementedException();
        }
    }
}
