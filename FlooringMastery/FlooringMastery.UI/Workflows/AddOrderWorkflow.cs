using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.BLL;
using FlooringMastery.Data;
using FlooringMastery.Models;
using FlooringMastery.Models.RepoType;

namespace FlooringMastery.UI.Workflows
{
    public class AddOrderWorkflow
    {
        public void Execute()
        {
            Console.Clear();
            StateManager stateManager = StateManagerFactory.Create();
            ProductManager productManager = ProductManagerFactory.Create();
            OrderManager orderManager = OrderManagerFactory.Create();
            Orders newOrder = new Orders();


            ConsoleIO.OrderHeader("Add an Order");
            Console.WriteLine("Please enter a future date for the order.");
            newOrder.orderDate = ConsoleIO.GetFutureDateFromUser();
            var numberResponse = orderManager.GetOrderNumber(ConsoleIO.OrderDate);
            newOrder.OrderNumber = numberResponse.OrderNumber;
            newOrder.Name = ConsoleIO.GetCustomerNameFromUserForAdd();
            Console.Clear();
            var response = stateManager.ListAllStates();
            if (response.Success)
            {
                ConsoleIO.OrderHeader("Add an Order");
                ConsoleIO.DisplayAllStates(response.StateList);
                while (true)
                {
                    string state = ConsoleIO.GetStateFromUserForAdd();
                    var StateTax = stateManager.LookupState(state);
                    if (StateTax.Success)
                    {
                        newOrder.State = StateTax.StateTax.State;
                        newOrder.TaxRate = StateTax.StateTax.TaxRate;
                        break;
                    }
                    else
                    {
                        Console.WriteLine(StateTax.Message);
                        ConsoleIO.EnterKeyToContinue();
                    }
                }
                ConsoleIO.OrderHeader("Add an Order");
                var productresponse = productManager.ProductList();
                if (productresponse.Success)
                {
                    ConsoleIO.DisplayAllProducts(productresponse.Products);

                    while (true)
                    {
                        string product = ConsoleIO.GetProductTypeFromUser();
                        var customerProduct = productManager.ChooseProduct(product);
                        if (customerProduct.Success)
                        {
                            newOrder.PrductType = customerProduct.Product.ProductType;
                            newOrder.CostPerSqureFoot = customerProduct.Product.CostPerSquareFoot;
                            newOrder.LaborCostPerSquareFoot = customerProduct.Product.LaborCostPerSquareFoot;
                            break;
                        }

                        else
                        {
                            Console.WriteLine(customerProduct.Message);
                            ConsoleIO.EnterKeyToContinue();
                        }
                    }
                    ConsoleIO.OrderHeader("Add an Order");
                    Console.WriteLine(ConsoleIO.SeparatorBar);
                    newOrder.Area = ConsoleIO.GetAreaFromUser();




                    newOrder.MaterialCost = newOrder.Area * newOrder.CostPerSqureFoot;
                    newOrder.LaborCost = newOrder.Area * newOrder.LaborCostPerSquareFoot;
                    newOrder.Tax = (newOrder.MaterialCost + newOrder.LaborCost) * (newOrder.TaxRate / 100);
                    newOrder.Total = newOrder.MaterialCost + newOrder.LaborCost + newOrder.Tax;

                    ConsoleIO.OrderHeader("Add an Order");
                    ConsoleIO.DisplayOrders(newOrder);
                    Console.WriteLine(ConsoleIO.SeparatorBar);
                    string answer = ConsoleIO.GetYesNoAnswerFromUser("Would you like to place this order?: ");
                    if (answer == "Y")
                    {
                        var createresponse = orderManager.CreateOrder(newOrder, ConsoleIO.OrderDate);
                        if (createresponse.Success)
                        {
                            Console.WriteLine("The order was placed!");
                            ConsoleIO.EnterKeyToContinue();
                        }
                        else
                        {
                            Console.WriteLine(createresponse.Message);
                            ConsoleIO.EnterKeyToContinue();
                        }

                    }
                    else
                    {
                        Console.WriteLine("The order was cancelled.");
                        ConsoleIO.EnterKeyToContinue();

                    }
                }
                else
                {
                    Console.WriteLine(productresponse.Message);
                    ConsoleIO.EnterKeyToContinue();
                }
            }

            else
            {
                Console.WriteLine(response.Message);
                ConsoleIO.EnterKeyToContinue();
            }

        }
    }
}
