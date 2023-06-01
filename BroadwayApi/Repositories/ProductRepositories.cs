//using IMS_Morning.DataAccess.Interfaces;
//using Microsoft.Extensions.Configuration;
//using System;
//using System.Collections.Generic;
//using System.Data.SqlClient;
//using System.Data;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using IMS_Morning.DataAccess.Models.DataModels;
//using IMS_Morning.DataAccess.Models.Healper;

//namespace IMS_Morning.DataAccess.Repositories
//{
//    public class ProductRepositories : IProductRepositories
//    {
//        private IConfiguration _confi;

//        public ProductRepositories(IConfiguration confi)
//        {
//            _confi = confi;
//        }
//        public DataResult CreateProduct(ProductsModel products)
//        {
//            DataResult result = new DataResult();
//            var connectionString = _confi.GetConnectionString("Defaultconnection");
//            using (SqlConnection connection = new SqlConnection(connectionString))
//            {

//                try
//                {
//                    SqlCommand command = new SqlCommand("InsertProduct", connection);
//                    command.CommandType = CommandType.StoredProcedure;
//                   // command.Parameters.AddWithValue("@ProductID", products.ProductID);
//                    command.Parameters.AddWithValue("@ProductName", products.ProductName);
//                    command.Parameters.AddWithValue("UnitPrice", products.UnitPrice);
//                    command.Parameters.AddWithValue("@UnitsInStock", products.UnitsInStock);
//                    command.Parameters.AddWithValue("@CategoryID", products.CategoryID);
                    


//                    connection.Open();
//                    int affectedRow = command.ExecuteNonQuery();

//                    if (affectedRow > 0)
//                    {
//                        result.Success = true;
//                        result.Message = "Data insert Successfully";
//                    }
//                    else
//                    {
//                        result.Success = false;
//                        result.Message = "Data inserted Failed. Please Contact your Adminisor";
//                    }

//                }
//                catch (Exception ex)
//                {
//                    result.Success = false;
//                    result.Message = ex.Message;


//                }
//                finally
//                {
//                    connection.Close();
//                }



//            }
//            return result;
//        }

//        public DataResult DeleteProduct(int ProductID)
//        {
//            // throw new NotImplementedException();
//            DataResult result = new DataResult();
//            var connectionString = _confi.GetConnectionString("Defaultconnection");
//            using (SqlConnection connection = new SqlConnection(connectionString))
//            {
//                try
//                {
//                    SqlCommand command = new SqlCommand("DeleteProducts", connection);
//                    command.CommandType = CommandType.StoredProcedure;
//                    command.Parameters.AddWithValue("@ProductID", ProductID);
//                    connection.Open();
//                    int affectedRow = command.ExecuteNonQuery();

//                    if (affectedRow > 0)
//                    {
//                        result.Success = true;
//                        result.Message = "Data Delete Successfully";
//                    }
//                    else
//                    {
//                        result.Success = false;
//                        result.Message = "Deleting Process Failed. Please Contact your Adminisor";
//                    }


//                }
//                catch (Exception ex)
//                {
//                    result.Success = false;
//                    result.Message = ex.Message;
//                }
//                finally
//                {
//                    connection.Close();
//                }
//                return result;
//            }
//        }

      
//        public DataResult UpdateProduct(ProductsModel products)
//        {
//            DataResult result = new DataResult();
//            var connectionString = _confi.GetConnectionString("DefaultConnection");
//            using(SqlConnection connection = new SqlConnection( connectionString))
//            {
//                try
//                {
//                    SqlCommand command = new SqlCommand("UpdateProducts", connection);
//                    command.CommandType = CommandType.StoredProcedure;
//                    command.Parameters.AddWithValue("@ProductID", products.ProductID);
//                    command.Parameters.AddWithValue("@ProductName", products.ProductName);
//                    command.Parameters.AddWithValue("UnitPrice", products.UnitPrice);
//                    command.Parameters.AddWithValue("@UnitsInStock", products.UnitsInStock);
//                    command.Parameters.AddWithValue("@CategoryID", products.CategoryID);
//                    connection.Open();
//                    int affectedRow = command.ExecuteNonQuery();

//                    if (affectedRow > 0)
//                    {
//                        result.Success = true;
//                        result.Message = "Data Delete Successfully";
//                    }
//                    else
//                    {
//                        result.Success = false;
//                        result.Message = "Deleting Process Failed. Please Contact your Adminisor";
//                    }

//                }
//                catch (Exception ex)
//                {
//                    result.Success = false;
//                    result.Message = ex.Message;
//                }
//                finally 
//                { 
//                    connection.Close();
//                }
//                return result;
//            }

//        }
//        public DataResult<ProductsModel> GetAllProducts()
//        {
//            DataResult<ProductsModel> result = new DataResult<ProductsModel>();
//            var connectionString = _confi.GetConnectionString("DefaultConnection");
//            using (SqlConnection connection = new SqlConnection(connectionString))
//            {
//                try
//                {
//                    SqlCommand command = new SqlCommand("GetProducts", connection);
//                    command.CommandType = CommandType.StoredProcedure;
//                    SqlDataAdapter adapter = new SqlDataAdapter();
//                    DataTable data = new DataTable();
//                    connection.Open();
//                    adapter.SelectCommand = command;
//                    adapter.Fill(data);

//                    result.Data = (from DataRow dr in data.Rows
//                                   select new ProductsModel
//                                   {
//                                       ProductID = Convert.ToInt32(dr["ProductID"]),

//                                       ProductName = Convert.ToString(dr["ProductName"]),
//                                       UnitPrice = Convert.ToInt32(dr["UnitPrice"]),
//                                       UnitsInStock = Convert.ToInt32(dr["UnitsInStock"]),
//                                       CategoryID = Convert.ToInt32(dr["CategoryID"]),
//                                   }).ToList();
                    

//                    int affectedRow = command.ExecuteNonQuery();

//                    if (result.Data.Count > 0)
//                    {
//                        result.Success = true;
//                        result.Message = "Get All Data Successfully";
//                    }
//                    else
//                    {
//                        result.Success = false;
//                        result.Message = " NO Data Found";
//                    }

//                }
//                catch (Exception ex)
//                {
//                    result.Success = false;
//                    result.Message = ex.Message;
//                }
//                finally
//                {
//                    connection.Close();
//                }
//            }

//            return result;
//        }

//        public DataResult<ProductsModel> GetProductByID(int ProductID)
//        {
//            DataResult<ProductsModel> result = new DataResult<ProductsModel>();
//            var connectionString = _confi.GetConnectionString("DefaultConnection");
//            using (SqlConnection connection = new SqlConnection(connectionString))
//            {
//                try
//                {
//                    SqlCommand command = new SqlCommand("GetProductByID", connection);
//                    command.CommandType = CommandType.StoredProcedure;
//                    command.Parameters.AddWithValue("@ProductID", ProductID);
//                    SqlDataAdapter adapter = new SqlDataAdapter();
//                    DataTable data = new DataTable();
//                    connection.Open();
//                    adapter.SelectCommand = command;
//                    adapter.Fill(data);

//                    result.Data = (from DataRow dr in data.Rows
//                                   select new ProductsModel
//                                   {
//                                       ProductID = Convert.ToInt32(dr["ProductID"]),

//                                       ProductName = Convert.ToString(dr["ProductName"]),
//                                       UnitPrice = Convert.ToInt32(dr["UnitPrice"]),
//                                       UnitsInStock = Convert.ToInt32(dr["UnitsInStock"]),
//                                       CategoryID = Convert.ToInt32(dr["CategoryID"]),
//                                   }).ToList();


//                    int affectedRow = command.ExecuteNonQuery();

//                    if (result.Data.Count > 0)
//                    {
//                        result.Success = true;
//                        result.Message = "Get All Data Successfully";
//                    }
//                    else
//                    {
//                        result.Success = false;
//                        result.Message = " NO Data Found";
//                    }

//                }
//                catch (Exception ex)
//                {
//                    result.Success = false;
//                    result.Message = ex.Message;
//                }
//                finally
//                {
//                    connection.Close();
//                }
//            }

//            return result;
//        }
//    }
//}
