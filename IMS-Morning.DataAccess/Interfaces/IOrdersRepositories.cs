using IMS_Morning.DataAccess.Models.DataModels;
using IMS_Morning.DataAccess.Models.Healper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS_Morning.DataAccess.Interfaces
{
    public interface IOrdersRepositories
    {
        DataResult CreateOrder(OrdersModel orders);

        DataResult DeleteOrder(int ProductID);

        DataResult UpdateOrder(OrdersModel orders );
        DataResult<OrdersModel> GetAllOrders();
        DataResult<OrdersModel> GetOrderByID(int ProductID);
    }
}
