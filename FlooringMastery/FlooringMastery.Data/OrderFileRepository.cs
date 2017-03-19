using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.Models;
using FlooringMastery.Models.Interfaces;

namespace FlooringMastery.Data
{
    public class OrderFileRepository : IOrderRepository
    {

        public static readonly string partialFilePath =
            @"C:\Users\dr3ek\Documents\bootcamp\daniel.eckberg.self.work\Labs\FlooringMastery\Orders_";

        public static string FilePath;

        public static string _filePath;
        
        public static string CreateFilePath(DateTime date)
        {
            FilePath = partialFilePath+ date.ToString("MMddyyyy") + ".txt";
            return FilePath;
        }

        public static bool DoesOrderFileExist(DateTime date)
        {
            CreateFilePath(date);
            if (File.Exists(FilePath)) 
            {
                return true;
            }
            else
            {
                
                return false;
            }
            

        }

        public OrderFileRepository(string FilePath)
        {
            _filePath = FilePath;
        }

        public static List<Orders> List(DateTime OrderDate, string FilePath)
        {
            List<Orders> orders = new List<Orders>();
            using (StreamReader sr = new StreamReader(FilePath))
            {
                sr.ReadLine();
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    Orders order = new Orders();

                    string[] columns = line.Split('|');

                    order.orderDate = OrderDate;
                    order.OrderNumber = int.Parse(columns[0]);
                    order.Name = columns[1];
                    order.State = columns[2];
                    order.TaxRate = decimal.Parse(columns[3]);
                    order.PrductType = columns[4];
                    order.Area = decimal.Parse(columns[5]);
                    order.CostPerSqureFoot = decimal.Parse(columns[6]);
                    order.LaborCostPerSquareFoot = decimal.Parse(columns[7]);
                    order.MaterialCost = decimal.Parse(columns[8]);
                    order.LaborCost = decimal.Parse(columns[9]);
                    order.Tax = decimal.Parse(columns[10]);
                    order.Total = decimal.Parse(columns[11]);

                    orders.Add(order);
                }

            }
            return orders;
        }

        public void EditOrder(Orders order,DateTime OrderDate)
        {
            var orders = List(OrderDate, FilePath);
            int index = orders.IndexOf(orders.FirstOrDefault(o => o.OrderNumber == order.OrderNumber));
            orders[index]= order;
            CreateOrderFile(orders);
        }

        public void CreateOrder(Orders order, DateTime OrderDate)
        {
            string line = CreateCsvForOrder(order);
            CreateFilePath(OrderDate);
            if (DoesOrderFileExist(OrderDate))
            {
                using (StreamWriter sw = new StreamWriter(FilePath, true))
                {
                    

                    sw.WriteLine(line);
                }
            }
            else
            {
                using (StreamWriter sw = new StreamWriter(FilePath,true))
                {
                    sw.WriteLine("OrderNumber|CustomerName|State|TaxRate|ProductType|Area|CostPerSquareFoot|LaborCostPerSquareFoot|MaterialCost|LaborCost|Tax|Total");
                    sw.WriteLine(line);
                }
            }
        }

        public void DeleteOrder(DateTime OrderDate, int OrderNumber)
        {
            var orders = List(OrderDate, FilePath);
            var orderToRemove = orders.SingleOrDefault(o => o.OrderNumber == OrderNumber);
            if (orderToRemove != null)
            {
                orders.Remove(orderToRemove);
            }
            CreateOrderFile(orders);

        }

        public List<Orders> GetAllOrders(DateTime OrderDate)
        {
           
            if(DoesOrderFileExist(OrderDate))
            {

                var orders = List(OrderDate, FilePath);
                return orders;
                
            }
            else
            {
                return null;
            }
        }

        public Orders GetOrder(DateTime OrderDate, int OrderNumber)
        {
            var orders = List(OrderDate, FilePath);
            foreach (var order in orders)
            {
                if (order.OrderNumber == OrderNumber)
                {
                    return order;
                }
            }
            return null;
        }

        private string CreateCsvForOrder(Orders order)
        {
            return string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9}|{10}|{11}", order.OrderNumber, order.Name,
                order.State, order.TaxRate.ToString("F"), order.PrductType, order.Area.ToString("F"), order.CostPerSqureFoot.ToString("F"),
                order.LaborCostPerSquareFoot.ToString("F"), order.MaterialCost.ToString("F"), order.LaborCost.ToString("F"), order.Tax.ToString("F"), order.Total.ToString("F"));
        }

        private void CreateOrderFile(List<Orders> orders)
        {
            if (File.Exists(FilePath))
                File.Delete(FilePath);

            using (StreamWriter sr = new StreamWriter(FilePath))
            {
                sr.WriteLine("OrderNumber|CustomerName|State|TaxRate|ProductType|Area|CostPerSquareFoot|LaborCostPerSquareFoot|MaterialCost|LaborCost|Tax|Total");
                foreach (var order in orders)
                {
                    sr.WriteLine(CreateCsvForOrder(order));
                }
            }
        }

        public int GetOrderNumber(DateTime OrderDate)
        {
            int orderNumber = 1;
            if (DoesOrderFileExist(OrderDate))
            {
                var orders = List(OrderDate, FilePath).LastOrDefault();
                orderNumber += orders.OrderNumber;
            }
            return orderNumber;
        }
    }
}
