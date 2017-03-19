using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.Models;
using FlooringMastery.Models.Interfaces;

namespace FlooringMastery.Data
{
    public class OrderTestRepository : IOrderRepository
    {
        private static Orders _order = new Orders
        {
            orderDate = DateTime.Parse("5/29/2017"),
            OrderNumber = 1,
            Name = "Eckberg",
            State = "OH",
            TaxRate = 6.25M,
            PrductType = "Carpet",
            Area = 200M,
            CostPerSqureFoot = 2.25M,
            LaborCostPerSquareFoot = 2.10M,
            MaterialCost = 450M,
            LaborCost = 420M,
            Tax = 54.38M,
            Total = 924.38M
            
        };

        private static List<Orders> orders = new List<Orders>()
        {
            _order
        };

        public void EditOrder(Orders order, DateTime OrderDate)
        {
            
            int index = orders.IndexOf(orders.FirstOrDefault(o => o.OrderNumber == order.OrderNumber));
            orders[index] = order;
        }

        public void CreateOrder(Orders order, DateTime OrderDate)
        {
            
            orders.Add(order);
        }

        public void DeleteOrder(DateTime OrderDate, int OrderNumber)
        {
            
            var orderToRemove = orders.SingleOrDefault(o => o.OrderNumber == OrderNumber);
            if (orderToRemove != null)
            {
                orders.Remove(orderToRemove);
            }
            
        }

        public List<Orders> GetAllOrders(DateTime OrderDate)
        {

            
            var firstOrder = orders.FirstOrDefault(o => o.Name != null);
            if (firstOrder.orderDate == OrderDate)
            {
                
                return orders;
            }
            return null;
        }
        
        public Orders GetOrder(DateTime OrderDate, int OrderNumber)
        {
            var orders = GetAllOrders(OrderDate);
            foreach (var order in orders)
            {
                if (order.OrderNumber == OrderNumber)
                {
                    return order;
                }
            }
            return null;
        }

        public int GetOrderNumber(DateTime OrderDate)
        {
            int orderNumber = 1;
            
                var orders = GetAllOrders(OrderDate).LastOrDefault();
                orderNumber += orders.OrderNumber;
            
            return orderNumber;
        }
    }
}
