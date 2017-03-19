using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.Models;
using FlooringMastery.Models.RepoType;
using FlooringMastery.Models.Responses;

namespace FlooringMastery.UI
{
    public class ConsoleIO
    {
        public const string SeparatorBar = "*************************************************************************";

        public static DateTime OrderDate;

        public static void DisplayOrders(Orders order)
        {
            Console.WriteLine(SeparatorBar);
            Console.WriteLine($"{order.OrderNumber} | {order.orderDate.ToString("d")}");
            Console.WriteLine($"{order.Name}");
            Console.WriteLine($"{order.State}");
            Console.WriteLine($"Product:  {order.PrductType}");
            Console.WriteLine($"Materials: {order.MaterialCost.ToString("C")}");
            Console.WriteLine($"Labor: {order.LaborCost.ToString("C")}");
            Console.WriteLine($"Tax: {order.Tax.ToString("C")}");
            Console.WriteLine($"Total: {order.Total.ToString("C")}");
            
        }

        public static void DisplayAllOdersForDate(List<Orders> orders)
        {
            foreach (var order in orders)
            {
                DisplayOrders(order);
            }
        }

        public static DateTime GetDateFromUser()
        {
            while (true)
            {
                Console.Write("Please enter a date, ex: 2/28/2016: ");
                string input = Console.ReadLine();

                DateTime date;
                if (DateTime.TryParse(input, out date))
                {

                    OrderDate = date;
                    return OrderDate;
                }
                Console.WriteLine("That is not a valid date.");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();

            }
        }

               public static DateTime GetFutureDateFromUser()
        {
            while (true)
            {
                Console.Write("Please enter a date, ex: 2/28/2016: ");
                string input = Console.ReadLine();

                DateTime date;
                if (DateTime.TryParse(input, out date))
                {
                    if (date > DateTime.Today)
                    {
                        OrderDate = date;
                        return OrderDate;
                    }
                    else
                    {
                        Console.WriteLine("The date for the order must be a future date");

                    }

                }
                Console.WriteLine("That is not a valid date.");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }


        public static int GetOrderNumberFromUser(string prompt)
        {
            int output;

            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();

                if (!int.TryParse(input, out output))
                {
                    Console.WriteLine("You must enter valid number.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
                else
                {
                    return output;
                }
            }
        }

        public static string GetYesNoAnswerFromUser(string prompt)
        {
            while (true)
            {
                Console.Write(prompt + " (Y/N)? ");
                string input = Console.ReadLine().ToUpper();

                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("You must enter Y/N.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
                else
                {
                    if (input != "Y" && input != "N")
                    {
                        Console.WriteLine("You must enter Y/N.");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        continue;
                    }
                    return input;
                }
            }
        }

        public static void DisplayAllProducts(List<Product> products)
        {
            Console.WriteLine(SeparatorBar);
            Console.WriteLine("Product Type, Cost per Square Foot, Labor Cost per Square Foot");
            foreach (var product in products)
            {
                DisplayProduct(product);
            }
            Console.WriteLine(SeparatorBar);
        }

        public static void DisplayProduct(Product product)
        {

            Console.WriteLine("{0}, {1}, {2}", product.ProductType, product.CostPerSquareFoot,
                product.LaborCostPerSquareFoot);
        }

        public static void DisplayAllStates(List<Tax> states)
        {
            Console.WriteLine(SeparatorBar);
            Console.WriteLine("State, State Name, Tax Rate");
            foreach (var state in states)
            {
                DisplayState(state);
            }
            Console.WriteLine(SeparatorBar);
        }

        public static void DisplayState(Tax stateTax)
        {
            Console.WriteLine("{0}, {1}, {2}", stateTax.State, stateTax.StateName, stateTax.TaxRate);
        }

        public static string GetCustomerNameFromUserForAdd()
        {
            while (true)
            {
                Console.Write("Enter the customer name: ");
                string input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("You must enter valid text.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();

                }
                else if (input.Contains('|'))
                {
                    Console.WriteLine("| character is not allowed.");
                    EnterKeyToContinue();
                }
                else
                {
                    return input;
                }
            }
        }

        public static string GetStateFromUserForAdd()
        {
            while (true)
            {
                Console.Write("Enter the State's two character abbreviation to choose state: ");
                string input = Console.ReadLine().ToUpper();

                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("You must enter valid text.");
                    EnterKeyToContinue();
                }
                else if (input.Length > 2)
                {
                    Console.WriteLine("You must enter valid text.");
                    EnterKeyToContinue();
                }
                else
                {
                    return input;
                }
            }
        }

        public static string GetProductTypeFromUser()
        {
            while (true)
            {
                Console.Write("Enter the Product Name: ");
                string input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("You must enter valid text.");
                    EnterKeyToContinue();
                }
                else if (input.Length < 2)
                {
                    return input;
                }
                else
                {
                    return char.ToUpper(input[0]) + input.Substring(1);
                }
            }
        }

        public static void EnterKeyToContinue()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        public static decimal GetAreaFromUser()
        {

            decimal area;
            while (true)
            {
                Console.Write("Enter the squarefootage for the floor: ");
                string input = Console.ReadLine();


                
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
                    return area;
                }

            }
        }

        public static string GetCustomerNameEdit(string name)
        {
            while (true)
            {
                Console.Write($"Enter the customer name ({name}): ");
                string input = Console.ReadLine();

                if (input.Contains('|'))
                {
                    Console.WriteLine("| character is not allowed.");
                    EnterKeyToContinue();
                }
                else
                {
                    return input;
                }
            }
        }

        public static string GetStateForEdit(string orderState)
        {
            while (true)
            {
                Console.Write($"Enter the State's two character abbreviation to choose state({orderState}): ");
                string input = Console.ReadLine().ToUpper();

                if (input.Length > 2)
                {
                    Console.WriteLine("You must enter valid text.");
                    EnterKeyToContinue();
                }
                else
                {
                    return input;
                }
            }
        }

        public static string GetProductTypeForEdit(string orderPrductType)
        {
            while (true)
            {
                Console.Write("Enter the Product Name: ");
                string input = Console.ReadLine();

                if (!string.IsNullOrEmpty(input) && input.Length >=2)
                {
                    return char.ToUpper(input[0]) + input.Substring(1);
                    
                }
                else
                {
                    return input;
                }
            }
        }

        public static void OrderHeader(string headerText)
        {
            Console.Clear();
            Console.WriteLine(SeparatorBar);
            Console.WriteLine();
            Console.WriteLine($"{headerText}");
            Console.WriteLine();
            Console.WriteLine(SeparatorBar);
            Console.WriteLine();
        }
    }
}
