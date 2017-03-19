using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.BLL;
using FlooringMastery.Models.Responses;
using FlooringMastery.Models;
using NUnit.Framework;

namespace FlooringMastery.Tests
{

    [TestFixture]
    public class FlooringMasteryTests
    {
        private const string _filePath = @"C:\Users\dr3ek\Documents\bootcamp\daniel.eckberg.self.work\Labs\FlooringMastery\Orders_05294017.txt";
        private const string _originalData = @"C:\Users\dr3ek\Documents\bootcamp\daniel.eckberg.self.work\Labs\FlooringMastery\OrdersTestSeed_05294017.txt";

        [SetUp]
        public void Setup()
        {
            if (File.Exists(_filePath))
            {
                File.Delete(_filePath);
            }

            File.Copy(_originalData, _filePath);
        }

        [Test]
        public void CanLoadOrderTestData()
        {
            OrderManager manager = OrderManagerFactory.Create();
            DateTime date = DateTime.Parse("5/29/4017");

            OrderFileLookupResponse response = manager.GetAllOrders(date);

            Assert.IsNotNull(response.Orders);
            Assert.IsTrue(response.Success);

        }

        [Test]
        public void CanLoadASingleOrderTest()
        {
            OrderManager manager = OrderManagerFactory.Create();
            DateTime date = DateTime.Parse("5/29/4017");

            OrderLookupResponse response = manager.LookupOrder(date, 1);

            Assert.IsNotNull(response.Order);
            Assert.IsTrue(response.Success);
            Assert.AreEqual(1, response.Order.OrderNumber);
        }

        [Test]
        public void AddOrderTest()
        {


            OrderManager manager = OrderManagerFactory.Create();
            DateTime date = DateTime.Parse("5/29/4017");
            Orders newOrder = new Orders();
            newOrder.OrderNumber = 1;
            newOrder.Name = "Eckberg";
            newOrder.State = "OH";
            newOrder.TaxRate = 6.25M;
            newOrder.PrductType = "Carpet";
            newOrder.Area = 100M;
            newOrder.CostPerSqureFoot = 2.25M;
            newOrder.LaborCostPerSquareFoot = 2.10M;
            newOrder.MaterialCost = 450M;
            newOrder.LaborCost = 420M;
            newOrder.Tax = 54.38M;
            newOrder.Total = 924.38M;

            CreateOrderResponse response = manager.CreateOrder(newOrder, date);
            var orders = manager.GetAllOrders(date);
            Assert.AreEqual(2, orders.Orders.Count);

            Orders check = orders.Orders[1];

            Assert.AreEqual("Eckberg", check.Name);
            Assert.AreEqual("OH", check.State);
        }
        [Test]
        public void EditOrderTest()
        {
            OrderManager manager = OrderManagerFactory.Create();
            DateTime date = DateTime.Parse("5/29/4017");
            var orders = manager.GetAllOrders(date);
            Orders editedOrder = orders.Orders[0];
            editedOrder.Area = 100M;
            editedOrder.MaterialCost = editedOrder.Area * editedOrder.CostPerSqureFoot;
            editedOrder.LaborCost = editedOrder.Area * editedOrder.LaborCostPerSquareFoot;
            editedOrder.Tax = (editedOrder.MaterialCost + editedOrder.LaborCost) *
                                    (editedOrder.TaxRate / 100);
            editedOrder.Total = editedOrder.MaterialCost + editedOrder.LaborCost +
                                      editedOrder.Tax;

            manager.EditOrder(editedOrder, date);

            Assert.AreEqual(1, orders.Orders.Count);
            orders = manager.GetAllOrders(date);
            Orders check = orders.Orders[0];

            Assert.AreEqual(100M, check.Area);
            Assert.AreEqual("462.19", check.Total.ToString("F"));
        }

        [Test]
        public void CanRemoveOrderTest()
        {
            OrderManager manager = OrderManagerFactory.Create();
            DateTime date = DateTime.Parse("5/29/4017");
            var orders = manager.GetAllOrders(date);
            manager.RemoveOrder(date, 1);

            Assert.AreEqual(1,orders.Orders.Count);
        }

        [Test]
        public void CanLoadProductTestData()
        {
            ProductManager manager = ProductManagerFactory.Create();

            ProductListResponse response = manager.ProductList();

            Assert.IsNotNull(response.Products);
            Assert.IsTrue(response.Success);
        }

        [Test]
        public void CanChooseProductTest()
        {
            ProductManager manager = ProductManagerFactory.Create();

            ProductLookupResponse response = manager.ChooseProduct("Carpet");

            Assert.IsNotNull(response.Product.ProductType);
            Assert.IsTrue(response.Success);
            Assert.AreEqual("Carpet", response.Product.ProductType);

        }

        [Test]
        public void StateFileListLookupTest()
        {
            StateManager manager = StateManagerFactory.Create();

            StateFileLookup response = manager.ListAllStates();

            Assert.IsNotNull(response.StateList);
            Assert.IsTrue(response.Success);
        }

        [Test]
        public void StateFileChoseTest()
        {
            StateManager manager = StateManagerFactory.Create();

            StateLookupResponse response = manager.LookupState("OH");

            Assert.IsNotNull(response.StateTax.State);
            Assert.IsTrue(response.Success);
            Assert.AreEqual("OH", response.StateTax.State);
        }
    }
}
