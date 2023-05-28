using IMS_Morning.DataAccess.Interfaces;
using IMS_Morning.DataAccess.Models.DataModels;
using IMS_Morning.DataAccess.Models.Healper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS_Morning.DataAccess.Repositories
{
    public class CustomerRepositories : ICustomerRepositories
    {
        private IConfiguration _confi;

        public CustomerRepositories(IConfiguration confi)
        {
            _confi = confi;
        }
        //return type ho DataResult
        public DataResult CreateCustomer(CustomerModel customer)
        {
            DataResult result = new DataResult();
            var connectionString = _confi.GetConnectionString("Defaultconnection");
            using(SqlConnection connection = new SqlConnection(connectionString))
            {

                try
                {
                    SqlCommand command = new SqlCommand("InsertCustomers", connection);
                    command.CommandType = CommandType.StoredProcedure;
                   command.Parameters.AddWithValue("@CompanyName", customer.CustomerName);
                    command.Parameters.AddWithValue("@Address", customer.Address);
                    command.Parameters.AddWithValue("@City", customer.City);
                    command.Parameters.AddWithValue("@Region", customer.Region);
                    command.Parameters.AddWithValue("@Phone ", customer.Phone);


                    connection.Open();
                    int affectedRow =  command.ExecuteNonQuery();

                    if (affectedRow > 0)
                    {
                        result.Success= true;
                        result.Message = "Data insert Successfully";
                    }
                    else
                    {
                        result.Success= false;
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



        public DataResult DeleteCustomer(int CustomerId)
        {
          // throw new NotImplementedException();
            DataResult result = new DataResult();
            var connectionString = _confi.GetConnectionString("Defaultconnection");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand("DeleteCustomer", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CustomerId", CustomerId);
                    connection.Open();
                    int affectedRow = command.ExecuteNonQuery();

                    if (affectedRow > 0)
                    {
                        result.Success = true;
                        result.Message = "Data Delete Successfully";
                    }
                    else
                    {
                        result.Success = false;
                        result.Message = "Deleting Process Failed. Please Contact your Adminisor";
                    }


                }
                catch (Exception ex)
                {
                   // result.Success = false;
                }
                finally
                {
                    connection.Close(); 
                }
                return result;
            }
        }
        //only for test
        public DataResult CreateCustomer1(string CustomerName, string Address, string City, string Region, int Phone)
        {
            DataResult result = new DataResult();
            var connectionString = _confi.GetConnectionString("Defaultconnection");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                try
                {
                    SqlCommand command = new SqlCommand("InsertCustomers", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CompanyName", CustomerName);
                    command.Parameters.AddWithValue("@Address", Address);
                    command.Parameters.AddWithValue("@City", City);
                    command.Parameters.AddWithValue("@Region", Region);
                    command.Parameters.AddWithValue("@Phone ", Phone);


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


                }
                finally
                {
                    connection.Close();
                }



            }
            return result;
        }

        public DataResult UpdataCustomer(CustomerModel customer)
        {
           DataResult result = new DataResult();
            var connectionString = _confi.GetConnectionString("DefaultConnection");
            using(SqlConnection connection = new SqlConnection( connectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand("UpdateCustomer", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CustomerId", customer.CustomerId);
                    command.Parameters.AddWithValue("@CustomerName", customer.CustomerName);
                    command.Parameters.AddWithValue("@Address", customer.Address);
                    command.Parameters.AddWithValue("@City", customer.City);
                    command.Parameters.AddWithValue("@Region", customer.Region);
                    command.Parameters.AddWithValue("@Phone ", customer.Phone);


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
                return result;
            }
        }

        public DataResult<CustomerModel> GetAllCustomers()
        {
            DataResult<CustomerModel> result = new DataResult<CustomerModel> ();
            var connectionString = _confi.GetConnectionString("DefaultConnection");
            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand("GetCustomers", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    DataTable data= new DataTable();
                    connection.Open();
                    adapter.SelectCommand = command;
                    adapter.Fill(data);

                    result.Data = (from DataRow dr in data.Rows
                                   select new CustomerModel
                                   {
                                       CustomerId=Convert.ToInt32 (dr["CustomerId"]),
                                      // CompanyName = Convert.ToString(dr[" CustomerName"]),
                                       City = Convert.ToString(dr["City"]),
                                       Address = Convert.ToString(dr["Address"]),
                                       Region = Convert.ToString(dr["Region"]),
                                       Phone = Convert.ToInt64(dr["Phone"]),
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

        public DataResult<CustomerModel> GetCustomerByID(int CustomerId)
        {
            DataResult<CustomerModel> result = new DataResult<CustomerModel>();
            var connectionString = _confi.GetConnectionString("DefaultConnection");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand("GetCustomersbyID", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CustomerID", CustomerId);
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    DataTable data = new DataTable();
                    connection.Open();
                    adapter.SelectCommand = command;
                    adapter.Fill(data);

                    result.Data = (from DataRow dr in data.Rows
                                   select new CustomerModel
                                   {
                                       CustomerId = Convert.ToInt32(dr["CustomerId"]),
                                       //CustomerName = Convert.ToString(dr[" CustomerName"]),
                                       City = Convert.ToString(dr["City"]),
                                       Address = Convert.ToString(dr["Address"]),
                                       Region = Convert.ToString(dr["Region"]),
                                       Phone = Convert.ToInt64(dr["Phone"]),
                                       
                                   }).Where(w=>w.CustomerId== CustomerId).ToList();
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
    }
}
