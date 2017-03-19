using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.Data;
using FlooringMastery.Models;
using FlooringMastery.Models.Interfaces;
using FlooringMastery.Models.Responses;

namespace FlooringMastery.BLL
{
    public class OrderManager
    {
        
        private IOrderRepository _orderRepository;
        
        public OrderManager(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }


        public OrderLookupResponse LookupOrder(DateTime OrderDate, int OrderNumber)
        {
            OrderLookupResponse response = new OrderLookupResponse();

            
            response.Order = _orderRepository.GetOrder(OrderDate, OrderNumber);

            if (response.Order == null)
            {
                response.Success = false;
                response.Message = $"{OrderNumber} is not a valid order.";
            }
            else
            {
                response.Success = true;
            }
            return response;

        }

        public OrderFileLookupResponse GetAllOrders(DateTime OrderDate)
        {
            OrderFileLookupResponse response = new OrderFileLookupResponse();

            response.Orders = _orderRepository.GetAllOrders(OrderDate);

            if (response.Orders == null)
            {
                response.Success = false;
                response.Message = $"There are no orders for {OrderDate.ToString("d")}.";
            }
            else
            {
                response.Success = true;
            }
            return response;
        }

        public RemoveOrderResponse RemoveOrder(DateTime orderDate, int ordernumber)
        {
            RemoveOrderResponse response = new RemoveOrderResponse();

            try
            {
                _orderRepository.DeleteOrder(orderDate, ordernumber);
                response.Success = true;
            }
            catch (Exception e)
            {
                response.Message = "The order was not able to be removed";
            }
            return response;
        }

        public CreateOrderResponse CreateOrder(Orders order, DateTime orderDate)
        {
            CreateOrderResponse response = new CreateOrderResponse();

            try
            {
                _orderRepository.CreateOrder(order, orderDate);
                response.Success = true;
            }
            catch (Exception e)
            {
                response.Message = "The order was not able to be created. Contact IT.";
            }
            return response;

        }

        public EditOrderResponse EditOrder(Orders order, DateTime orderDate)
        {
            EditOrderResponse response = new EditOrderResponse();
            try
            {
                _orderRepository.EditOrder(order, orderDate);
                response.Success = true;
            }
            catch (Exception e)
            {
                response.Message = "The edited order was not saved. Contact IT.";
                throw;
            }
            return response;
        }

        public GetOrderNumberResponse GetOrderNumber(DateTime orderDate)
        {
            GetOrderNumberResponse response = new GetOrderNumberResponse();

            response.OrderNumber = _orderRepository.GetOrderNumber(orderDate);
            if (response.OrderNumber == null)
            {
                response.Success = false;
                response.Message = $"There was an error with the program. Contact IT.";
            }
            else
            {
                response.Success = true;
            }
            return response;
        }
    }
}
