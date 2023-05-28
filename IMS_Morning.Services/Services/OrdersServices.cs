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
    public class OrdersServices:IOrdersServices
    {
        private readonly IOrdersRepositories _repo;
        public OrdersServices(IOrdersRepositories repo)
        {
            _repo = repo;

        }

        public DataResult CreateOrder(OrdersModel orders)
        {
            DataResult result = new DataResult();
            if (orders.ShipAddress == null)
            {
                result.Success = false;
                result.Message = "Shipping Address is required";

            }
            result = _repo.CreateOrder(orders);
            result.Message = "Data inserted successfully and changed message from services";
            return result;
        }

        public DataResult DeleteOrder(int ProductID)
        {
            return _repo.DeleteOrder(ProductID);    
        }

        public DataResult<OrdersModel> GetAllOrders()
        {
            return _repo.GetAllOrders();
        }

        public DataResult<OrdersModel> GetOrderByID(int ProductID)
        {
            return _repo.GetOrderByID(ProductID);
        }

        public DataResult UpdateOrder(OrdersModel orders)
        {
            return _repo.UpdateOrder(orders);
        }
    }
}
