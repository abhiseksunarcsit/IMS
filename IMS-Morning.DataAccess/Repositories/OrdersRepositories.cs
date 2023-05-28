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
    public class OrdersRepositories : IOrdersRepositories
    {
        private readonly IConfiguration _confi;
        public OrdersRepositories(IConfiguration confi) 
        {
            _confi = confi;
        }
        public DataResult CreateOrder(OrdersModel orders)
        {
            DataResult result = new DataResult();
            var connectionString = _confi.GetConnectionString("Defaultconnection");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                try
                {
                    SqlCommand command = new SqlCommand("InsertOrders", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    
                    command.Parameters.AddWithValue("@CustomerID", orders.CustomerID);
                    command.Parameters.AddWithValue("OrderDate", orders.OrderDate);
                    command.Parameters.AddWithValue("@RequiredDate", orders.RequiredDate);
                    command.Parameters.AddWithValue("@ShippedDate", orders.ShippedDate);
                    command.Parameters.AddWithValue("@ShipAddress", orders.ShipAddress);



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

        public DataResult DeleteOrder(int OrderID)
        {
            DataResult result = new DataResult();
            var connectionString = _confi.GetConnectionString("Defaultconnection");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand("DeleteOrders", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@OrderID", OrderID);
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

        public DataResult<OrdersModel> GetAllOrders()
        {
            DataResult<OrdersModel> result = new DataResult<OrdersModel>();
            var connectionString = _confi.GetConnectionString("DefaultConnection");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand("GetOrders", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    DataTable data = new DataTable();
                    connection.Open();
                    adapter.SelectCommand = command;
                    adapter.Fill(data);

                    result.Data = (from DataRow dr in data.Rows
                                   select new OrdersModel
                                   {
                                       OrderID = Convert.ToInt32(dr["OrderID"]),

                                       CustomerID = Convert.ToInt32(dr["CustomerID"]),
                                       OrderDate = Convert.ToDateTime(dr["OrderDate"]),
                                       RequiredDate = Convert.ToDateTime(dr["RequiredDate"]),
                                       ShippedDate = Convert.ToDateTime(dr["ShippedDate"]),
                                       ShipAddress = Convert.ToString(dr["ShipAddress"]),
                                   }).ToList();


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

        public DataResult<OrdersModel> GetOrderByID(int OrderID )
        {
            DataResult<OrdersModel> result = new DataResult<OrdersModel>();
            var connectionString = _confi.GetConnectionString("DefaultConnection");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand("GetOrders", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    DataTable data = new DataTable();
                    connection.Open();
                    adapter.SelectCommand = command;
                    adapter.Fill(data);

                    result.Data = (from DataRow dr in data.Rows
                                   select new OrdersModel
                                   {
                                       OrderID = Convert.ToInt32(dr["OrderID"]),

                                       CustomerID = Convert.ToInt32(dr["CustomerID"]),
                                       OrderDate = Convert.ToDateTime(dr["OrderDate"]),
                                       RequiredDate = Convert.ToDateTime(dr["RequiredDate"]),
                                       ShippedDate = Convert.ToDateTime(dr[" ShippedDate"]),
                                       ShipAddress = Convert.ToString(dr["ShipAddress"]),
                                   }).Where(w => w.OrderID == OrderID).ToList();


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

        public DataResult UpdateOrder(OrdersModel orders)
        {
            DataResult result = new DataResult();
            var connectionString = _confi.GetConnectionString("DefaultConnection");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand("UpdateOrders", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CustomerID", orders.CustomerID);
                    command.Parameters.AddWithValue("OrderDate", orders.OrderDate);
                    command.Parameters.AddWithValue("@RequiredDate", orders.RequiredDate);
                    command.Parameters.AddWithValue("@ShippedDate", orders.ShippedDate);
                    command.Parameters.AddWithValue("@ShipAddress", orders.ShipAddress);

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
    }
}
