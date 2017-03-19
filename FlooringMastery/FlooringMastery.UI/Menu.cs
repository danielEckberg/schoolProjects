using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.UI.Workflows;

namespace FlooringMastery.UI
{
    public class Menu
    {
        public static void Start()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("*************************************************************************");
                Console.WriteLine("*Flooring Program");
                Console.WriteLine("*");
                Console.WriteLine("*1. Display Orders");
                Console.WriteLine("*2. Add an Order");
                Console.WriteLine("*3. Edit an Order");
                Console.WriteLine("*4. Remove an Order");
                Console.WriteLine("*5. Quit");
                Console.WriteLine("*************************************************************************");


                Console.Write("Please enter a selection: ");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        ListOrdersWorkflow ordersWorkflow = new ListOrdersWorkflow();
                        ordersWorkflow.Execute();
                        break;
                    case "2":
                        AddOrderWorkflow addOrderWorkflow = new AddOrderWorkflow();
                        addOrderWorkflow.Execute();
                        break;
                    case "3":
                        EditOrderWorkflow editOrderWorkflow = new EditOrderWorkflow();
                        editOrderWorkflow.Execute();
                        break;
                    case "4":
                        RemoveOrderWorkflow removeOrderWorkflow = new RemoveOrderWorkflow();
                        removeOrderWorkflow.Execute();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("That is not a valid selection.");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadLine();
                        break;

                }
            }
        }

    }
}
