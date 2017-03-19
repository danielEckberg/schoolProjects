using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.BLL;

namespace FlooringMastery.UI.Workflows
{
    public class EditOrderWorkflow
    {
        public void Execute()
        {
            OrderManager manager = OrderManagerFactory.Create();
            StateManager stateManager = StateManagerFactory.Create();
            ProductManager productManager = ProductManagerFactory.Create();


            ConsoleIO.OrderHeader("Edit an Order:");
            Console.WriteLine("Please enter the date of the order you would like to edit.");
            
            var repo = manager.GetAllOrders(ConsoleIO.GetDateFromUser());
            if (repo.Success)
            {
                ConsoleIO.OrderHeader("Edit an Order:");
                ConsoleIO.DisplayAllOdersForDate(repo.Orders);
                Console.WriteLine(ConsoleIO.SeparatorBar);
                Console.WriteLine();

                int orderNumber = ConsoleIO.GetOrderNumberFromUser("Which order number would you like to edit?: ");
                var ordertoedit = manager.LookupOrder(ConsoleIO.OrderDate, orderNumber);
                if (ordertoedit.Success)
                {
                    ConsoleIO.OrderHeader("Edit an Order:");
                   Console.WriteLine("Type the information to edit in the following prompts.\n If you wish to keep the information in parenthesis simply press enter.");
                    string name = ConsoleIO.GetCustomerNameEdit(ordertoedit.Order.Name);
                    if (!string.IsNullOrEmpty(name))
                    {
                        ordertoedit.Order.Name = name;
                    }
                    var response = stateManager.ListAllStates();
                    if (response.Success)
                    {
                        ConsoleIO.OrderHeader("Edit an Order:Type the information to edit in the following prompts.\n If you wish to keep the information in parenthesis simply press enter.");
                        ConsoleIO.DisplayAllStates(response.StateList);
                        Console.WriteLine();
                        while (true)
                        {
                            string state = ConsoleIO.GetStateForEdit(ordertoedit.Order.State);
                            if (!string.IsNullOrEmpty(state))
                            {
                                var StateTax = stateManager.LookupState(state);
                                if (StateTax.Success)
                                {
                                    ordertoedit.Order.State = StateTax.StateTax.State;
                                    ordertoedit.Order.TaxRate = StateTax.StateTax.TaxRate;
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine(StateTax.Message);
                                    ConsoleIO.EnterKeyToContinue();
                                }
                            }
                            break;

                        }
                    }
                    ConsoleIO.OrderHeader("Edit an Order:Type the information to edit in the following prompts.\n If you wish to keep the information in parenthesis simply press enter.");
                    var productresponse = productManager.ProductList();
                    if (productresponse.Success)
                    {
                        ConsoleIO.DisplayAllProducts(productresponse.Products);
                        Console.WriteLine();

                        while (true)
                        {
                            string product = ConsoleIO.GetProductTypeForEdit(ordertoedit.Order.PrductType);
                            if (!string.IsNullOrEmpty(product))
                            {
                                var customerProduct = productManager.ChooseProduct(product);
                                if (customerProduct.Success)
                                {
                                    ordertoedit.Order.PrductType = customerProduct.Product.ProductType;
                                    ordertoedit.Order.CostPerSqureFoot = customerProduct.Product.CostPerSquareFoot;
                                    ordertoedit.Order.LaborCostPerSquareFoot =
                                        customerProduct.Product.LaborCostPerSquareFoot;
                                    break;
                                }

                                else
                                {
                                    Console.WriteLine(customerProduct.Message);
                                    ConsoleIO.EnterKeyToContinue();
                                }
                            }
                            break;
                        }

                        while (true)
                        {
                            decimal area;
                            ConsoleIO.OrderHeader("Edit an Order:Type the information to edit in the following prompts. \nIf you wish to keep the information in parenthesis simply press enter.");
                            Console.Write($"Enter the squarefootage for the floor ({ordertoedit.Order.Area}): ");
                            string input = Console.ReadLine();
                            if (string.IsNullOrEmpty(input))
                            {
                                break;
                            }
                            if (!decimal.TryParse(input, out area))
                            {
                                Console.WriteLine("You must enter valid number.");
                                Console.WriteLine("Press any key to continue...");
                                Console.ReadKey();
                            }
                            if (area < 100)
                            {
                                Console.WriteLine("The square foot area must be at least 100 square feet.");
                                ConsoleIO.EnterKeyToContinue();
                            }

                            else
                            {
                                ordertoedit.Order.Area = area;
                                break;
                            }
                        }
                        ConsoleIO.OrderHeader("Edit an Order:");
                        ConsoleIO.DisplayOrders(ordertoedit.Order);
                        string answer = ConsoleIO.GetYesNoAnswerFromUser("Would you like to update this order?: ");
                        if (answer == "Y")
                        {
                            var editResponse = manager.EditOrder(ordertoedit.Order, ConsoleIO.OrderDate);
                            if (editResponse.Success)
                            {
                                Console.WriteLine("The order was updated!");
                                ConsoleIO.EnterKeyToContinue();
                            }
                            else
                            {
                                Console.WriteLine(editResponse.Message);
                                ConsoleIO.EnterKeyToContinue();
                            }

                        }
                        else
                        {
                            Console.WriteLine("The edit was cancelled.");
                            ConsoleIO.EnterKeyToContinue();

                        }


                        ordertoedit.Order.MaterialCost = ordertoedit.Order.Area * ordertoedit.Order.CostPerSqureFoot;
                        ordertoedit.Order.LaborCost = ordertoedit.Order.Area * ordertoedit.Order.LaborCostPerSquareFoot;
                        ordertoedit.Order.Tax = (ordertoedit.Order.MaterialCost + ordertoedit.Order.LaborCost) *
                                                (ordertoedit.Order.TaxRate / 100);
                        ordertoedit.Order.Total = ordertoedit.Order.MaterialCost + ordertoedit.Order.LaborCost +
                                                  ordertoedit.Order.Tax;

                        Console.Clear();
                        ConsoleIO.DisplayOrders(ordertoedit.Order);
                        Console.WriteLine(ConsoleIO.SeparatorBar);
                    }

                    else
                    {
                        Console.WriteLine(response.Message);
                        ConsoleIO.EnterKeyToContinue();
                    }
                }

                else
                {
                    Console.WriteLine(ordertoedit.Message);
                    ConsoleIO.EnterKeyToContinue();
                }
            }
            else
            {
                Console.WriteLine(repo.Message);
                ConsoleIO.EnterKeyToContinue();
            }
        }
    }
}




