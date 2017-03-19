using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.BLL;

namespace FlooringMastery.UI.Workflows
{
    class RemoveOrderWorkflow
    {
        public void Execute()
        {
            OrderManager manager = OrderManagerFactory.Create();
            Console.Clear();
            Console.WriteLine(ConsoleIO.SeparatorBar);
            Console.WriteLine("Remove Order");
            Console.WriteLine();
            Console.WriteLine("What date would you like to remove an order from?");
            
            var repo = manager.GetAllOrders(ConsoleIO.GetDateFromUser());
            if (repo.Success)
            {
                ConsoleIO.DisplayAllOdersForDate(repo.Orders);
                Console.WriteLine(ConsoleIO.SeparatorBar);
                Console.WriteLine();

                int orderNumber = ConsoleIO.GetOrderNumberFromUser("Which order number would you like to remove?: ");
                var ordertoremove = manager.LookupOrder(ConsoleIO.OrderDate, orderNumber);
                if (ordertoremove.Success)
                {
                    Console.Clear();
                    ConsoleIO.DisplayOrders(ordertoremove.Order);
                    Console.WriteLine(ConsoleIO.SeparatorBar);
                    Console.WriteLine();

                    string answer = ConsoleIO.GetYesNoAnswerFromUser("Are you sure you would like to remove this order?: ");

                    if (answer == "Y")
                    {
                        var response = manager.RemoveOrder(ConsoleIO.OrderDate, orderNumber);
                        if (response.Success)
                        {
                            Console.WriteLine("The order was cancelled!");
                            Console.WriteLine("Press any key to continue...");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine(response.Message);
                            Console.WriteLine("Press any key to continue...");
                            Console.ReadKey();
                        }

                    }
                    else
                    {
                        Console.WriteLine("Remove cancelled.");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.WriteLine(ordertoremove.Message);
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }

            }
            else
            {
                Console.WriteLine(repo.Message);
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
            
        }
    }
}
