using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.BLL;
using FlooringMastery.Data;
using FlooringMastery.Models;
using FlooringMastery.Models.Responses;

namespace FlooringMastery.UI.Workflows
{
    public class ListOrdersWorkflow
    {


        public void Execute()
        {
            OrderManager manager = OrderManagerFactory.Create();
            ConsoleIO.GetDateFromUser();

            OrderFileLookupResponse response = manager.GetAllOrders(ConsoleIO.OrderDate);

            if (response.Success)
            {
                
                Console.Clear();
                Console.WriteLine("Order List");

                ConsoleIO.DisplayAllOdersForDate(response.Orders);

                
                Console.WriteLine(ConsoleIO.SeparatorBar);
                Console.WriteLine();
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
            else
            {
                Console.Write("An error occurred: ");
                Console.WriteLine(response.Message);
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }

            

          
        }
    }
}
