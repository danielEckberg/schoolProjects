using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.Models.Interfaces
{
    public interface IOrderRepository
    {
        List<Orders> GetAllOrders(DateTime OrderDate);
        Orders GetOrder(DateTime OrderDate, int OrderNumber);
        void EditOrder(Orders order, DateTime OrderDate);
        void  CreateOrder(Orders order, DateTime OrderDate);
        void DeleteOrder(DateTime OrderDate, int OrderNumber);
        int GetOrderNumber(DateTime orderDate);

    }
}
