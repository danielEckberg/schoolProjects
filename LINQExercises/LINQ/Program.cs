using LINQ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Security.Cryptography.X509Certificates;

namespace LINQ
{
    class Program
    {
        static void Main()
        {
            //PrintAllProducts();
            //PrintAllCustomers();

            Exercise21();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        #region "Sample Code"
        /// <summary>
        /// Sample, load and print all the product objects
        /// </summary>
        static void PrintAllProducts()
        {
            List<Product> products = DataLoader.LoadProducts();
            PrintProductInformation(products);
        }

        /// <summary>
        /// This will print a nicely formatted list of products
        /// </summary>
        /// <param name="products">The collection of products to print</param>
        static void PrintProductInformation(IEnumerable<Product> products)
        {
            string line = "{0,-5} {1,-35} {2,-15} {3,6:c} {4,6}";
            Console.WriteLine(line, "ID", "Product Name", "Category", "Unit", "Stock");
            Console.WriteLine("==============================================================================");

            foreach (var product in products)
            {
                Console.WriteLine(line, product.ProductID, product.ProductName, product.Category,
                    product.UnitPrice, product.UnitsInStock);
            }

        }

        /// <summary>
        /// Sample, load and print all the customer objects and their orders
        /// </summary>
        static void PrintAllCustomers()
        {
            var customers = DataLoader.LoadCustomers();
            PrintCustomerInformation(customers);
        }

        /// <summary>
        /// This will print a nicely formated list of customers
        /// </summary>
        /// <param name="customers">The collection of customer objects to print</param>
        static void PrintCustomerInformation(IEnumerable<Customer> customers)
        {
            foreach (var customer in customers)
            {
                Console.WriteLine("==============================================================================");
                Console.WriteLine(customer.CompanyName);
                Console.WriteLine(customer.Address);
                Console.WriteLine("{0}, {1} {2} {3}", customer.City, customer.Region, customer.PostalCode, customer.Country);
                Console.WriteLine("p:{0} f:{1}", customer.Phone, customer.Fax);
                Console.WriteLine();
                Console.WriteLine("\tOrders");
                foreach (var order in customer.Orders)
                {
                    Console.WriteLine("\t{0} {1:MM-dd-yyyy} {2,10:c}", order.OrderID, order.OrderDate, order.Total);
                }
                Console.WriteLine("==============================================================================");
                Console.WriteLine();
            }
        }
        #endregion

        /// <summary>
        /// Print all products that are out of stock.
        /// </summary>
        static void Exercise1()
        {
            List<Product> products = DataLoader.LoadProducts();
            //var result = from p in products
            //    where p.UnitsInStock == 0
            //    select p;

            var result = products.Where(p => p.UnitsInStock == 0);

            foreach (var product in result)
            {
                Console.WriteLine($"{product.ProductName} {product.UnitsInStock}");
            }
        }

        /// <summary>
        /// Print all products that are in stock and cost more than 3.00 per unit.
        /// </summary>
        static void Exercise2()
        {
            List<Product> products = DataLoader.LoadProducts();

            //var result = from p in products
            //             where p.UnitsInStock != 0 && p.UnitPrice > 3
            //             select p;

            var result = products.Where(p => p.UnitsInStock != 0 && p.UnitPrice > 3);

            PrintProductInformation(result);
        }

        /// <summary>
        /// Print all customer and their order information for the Washington (WA) region.
        /// </summary>
        static void Exercise3()
        {
            List<Customer> customers = DataLoader.LoadCustomers();

            //var result = from c in customers
            //    where c.Region == "WA"
            //    select c;

            var result = customers.Where(c => c.Region == "WA");

            PrintCustomerInformation(result);
        }

        /// <summary>
        /// Create and print an anonymous type with just the ProductName
        /// </summary>
        static void Exercise4()
        {
            List<Product> products = DataLoader.LoadProducts();

            //var result = from p in products
            //             select new
            //             {
            //                 ProductName = p.ProductName
            //             };

            var result = products.Select(p => new
            {
                ProductName = p.ProductName
            });
            foreach (var p in result)
            {
                Console.WriteLine($"{p.ProductName}");
            }
        }

        /// <summary>
        /// Create and print an anonymous type of all product information but increase the unit price by 25%
        /// </summary>
        static void Exercise5()
        {
            List<Product> products = DataLoader.LoadProducts();

            var result = from p in products
                         select new
                         {
                             ProductID = p.ProductID,
                             ProductName = p.ProductName,
                             Category = p.Category,
                             UnitPrice = p.UnitPrice * 1.25M,
                             UnitsInStock = p.UnitsInStock
                         };

            string line = "{0,-5} {1,-35} {2,-15} {3,6:c} {4,6}";
            Console.WriteLine(line, "ID", "Product Name", "Category", "Unit", "Stock");
            Console.WriteLine("==============================================================================");

            foreach (var p in result)
            {
                Console.WriteLine(line, p.ProductID, p.ProductName, p.Category, p.UnitPrice, p.UnitsInStock);
            }



        }

        /// <summary>
        /// Create and print an anonymous type of only ProductName and Category with all the letters in upper case
        /// </summary>
        static void Exercise6()
        {
            List<Product> products = DataLoader.LoadProducts();

            var result = from p in products
                         select new
                         {
                             ProductName = p.ProductName.ToUpper(),
                             Category = p.Category.ToUpper()
                         };
            foreach (var p in result)
            {
                Console.WriteLine($"{p.ProductName}, {p.Category}");
            }

        }

        /// <summary>
        /// Create and print an anonymous type of all Product information with an extra bool property ReOrder which should 
        /// be set to true if the Units in Stock is less than 3
        /// 
        /// Hint: use a ternary expression
        /// </summary>
        static void Exercise7()
        {
            List<Product> products = DataLoader.LoadProducts();

            var result = from p in products
                         select new
                         {
                             ProductID = p.ProductID,
                             ProductName = p.ProductName,
                             Category = p.Category,
                             UnitPrice = p.UnitPrice,
                             UnitsInStock = p.UnitsInStock,
                             ReOrder = (p.UnitsInStock < 3) ? "true" : "false"
                         };

            string line = "{0,-5} {1,-35} {2,-15} {3,6:c} {4,6} {5,6}";
            Console.WriteLine(line, "ID", "Product Name", "Category", "Unit", "Stock", "Reorder");
            Console.WriteLine("==============================================================================");

            foreach (var p in result)
            {
                Console.WriteLine(line, p.ProductID, p.ProductName, p.Category, p.UnitPrice, p.UnitsInStock, p.ReOrder);
            }



        }

        /// <summary>
        /// Create and print an anonymous type of all Product information with an extra decimal called 
        /// StockValue which should be the product of unit price and units in stock
        /// </summary>
        static void Exercise8()
        {
            List<Product> products = DataLoader.LoadProducts();

            var result = from p in products
                         select new
                         {
                             ProductID = p.ProductID,
                             ProductName = p.ProductName,
                             Category = p.Category,
                             UnitPrice = p.UnitPrice,
                             UnitsInStock = p.UnitsInStock,
                             StockValue = p.UnitPrice * p.UnitsInStock
                         };

            string line = "{0,-5} {1,-35} {2,-15} {3,6:c} {4,6} {5,6:c}";
            Console.WriteLine(line, "ID", "Product Name", "Category", "Unit", "Stock", "Stock Value");
            Console.WriteLine("=================================================================================");

            foreach (var p in result)
            {
                Console.WriteLine(line, p.ProductID, p.ProductName, p.Category, p.UnitPrice, p.UnitsInStock, p.StockValue);
            }



        }

        /// <summary>
        /// Print only the even numbers in NumbersA
        /// </summary>
        static void Exercise9()
        {
            int[] numbers = DataLoader.NumbersA;

            //var onlyEvens = from n in numbers
            //    where n >0 && n % 2 == 0
            //    select n;

            var onlyEvens = numbers.Where(n => n > 0 && n % 2 == 0);

            foreach (var n in onlyEvens)
            {
                Console.WriteLine(n);
            }

        }

        /// <summary>
        /// Print only customers that have an order whose total is less than $500
        /// </summary>
        static void Exercise10()
        {
            List<Customer> customers = DataLoader.LoadCustomers();

            var result = from c in customers
                         from t in c.Orders
                         where t.Total < 500
                         select new
                         {
                             CompanyName = c.CompanyName,
                             ordersLessThan500 = t.Total
                         };


            foreach (var c in result)
            {
                Console.WriteLine($"{c.CompanyName}, {c.ordersLessThan500}");

            }




        }

        /// <summary>
        /// Print only the first 3 odd numbers from NumbersC
        /// </summary>
        static void Exercise11()
        {
            int[] numbers = DataLoader.NumbersC;

            //var onlyOdds = (from n in numbers
            //                where n % 2 == 1
            //                select n).Take(3);
            var onlyOdds = numbers.Where(n => n % 2 == 1).Take(3);

            foreach (var n in onlyOdds)
            {
                Console.WriteLine(n);
            }

        }

        /// <summary>
        /// Print the numbers from NumbersB except the first 3
        /// </summary>
        static void Exercise12()
        {
            int[] numbers = DataLoader.NumbersB;

            //var results = (from n in numbers
            //               select n).Skip(3);
            var results = numbers.Skip(3);


            foreach (var n in results)
            {
                Console.WriteLine(n);
            }
        }

        /// <summary>
        /// Print the Company Name and most recent order for each customer in Washington
        /// </summary>
        static void Exercise13()
        {
            List<Customer> customers = DataLoader.LoadCustomers();

            var results = from c in customers
                          where c.Region == "WA"
                          select new
                          {
                              CustomerName = c.CompanyName,
                              mostRecentOrder = (from o in c.Orders
                                                 orderby o.OrderDate descending
                                                 select o).First()
                          };


            foreach (var c in results)
            {
                foreach (var o in results)
                {
                    Console.WriteLine($"{c.CustomerName},{o.mostRecentOrder.OrderID}, {o.mostRecentOrder.Total}, {o.mostRecentOrder.OrderDate:MM-dd-yyyy}");
                }
            }


        }

        /// <summary>
        /// Print all the numbers in NumbersC until a number is >= 6
        /// </summary>
        static void Exercise14()
        {
            int[] numbers = DataLoader.NumbersC;

            //var result = from n in numbers
            //             where n >= 6
            //             select n;
            var result = numbers.Where(n => n >= 6);

            foreach (var n in result)
            {
                Console.WriteLine(n);
            }
        }

        /// <summary>
        /// Print all the numbers in NumbersC that come after the first number divisible by 3
        /// </summary>
        static void Exercise15()
        {
            int[] numbers = DataLoader.NumbersC;

            var result = numbers.SkipWhile(n => n % 3 != 0 || n == 3);
            foreach (var n in result)
            {
                Console.WriteLine(n);
            }

        }

        /// <summary>
        /// Print the products alphabetically by name
        /// </summary>
        static void Exercise16()
        {
            List<Product> products = DataLoader.LoadProducts();

            var results = from p in products
                          orderby p.ProductName
                          select p;
            PrintProductInformation(results);

        }

        /// <summary>
        /// Print the products in descending order by units in stock
        /// </summary>
        static void Exercise17()
        {
            List<Product> products = DataLoader.LoadProducts();

            var results = from p in products
                          orderby p.UnitsInStock descending
                          select p;
            PrintProductInformation(results);
        }

        /// <summary>
        /// Print the list of products ordered first by category, then by unit price, from highest to lowest.
        /// </summary>
        static void Exercise18()
        {
            List<Product> products = DataLoader.LoadProducts();

            //var results = products.OrderBy(p => p.Category).ThenByDescending(p => p.UnitPrice);

            var results = from p in products
                          orderby p.Category, p.UnitPrice descending
                          select p;


            PrintProductInformation(results);

        }

        /// <summary>
        /// Print NumbersB in reverse order
        /// </summary>
        static void Exercise19()
        {
            var reverse = DataLoader.NumbersB.Reverse().ToArray();

            Console.WriteLine(string.Join(",", reverse));

        }

        /// <summary>
        /// Group products by category, then print each category name and its products
        /// ex:
        /// 
        /// Beverages
        /// Tea
        /// Coffee
        /// 
        /// Sandwiches
        /// Turkey
        /// Ham
        /// </summary>
        static void Exercise20()
        {
            List<Product> products = DataLoader.LoadProducts();

            var groups = from p in products
                         group p by p.Category
                into newgroup
                         orderby newgroup.Key
                         select newgroup;
            foreach (var group in groups)
            {
                Console.WriteLine(" Category: {0}", group.Key);
                Console.WriteLine("-------------------------------------");

                foreach (var p in group)
                {
                    Console.WriteLine(p.ProductName);
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Print all Customers with their orders by Year then Month
        /// ex:
        /// 
        /// Joe's Diner
        /// 2015
        ///     1 -  $500.00
        ///     3 -  $750.00
        /// 2016
        ///     2 - $1000.00
        /// </summary>
        static void Exercise21()
        {
            List<Customer> customers = DataLoader.LoadCustomers();

            var result = from c in customers
                         select new
                         {
                             CustomerName = c.CompanyName,
                             OrderbyYears = from o in c.Orders
                                            group o by o.OrderDate.Year
                             into orderYear
                                            select new
                                            {
                                                Year = orderYear.Key,
                                                OrderbyMonths = (from mo in orderYear
                                                                group mo by mo.OrderDate.Month
                                                                into orderMonth
                                                                select new
                                                                 {
                                                                     month = orderMonth.Key,
                                                                     orders = orderMonth.Sum(v=>v.Total)
                                                                     
                                                                     
                                                                 })
                                            }
                         };

            
                
                foreach (var year in result)
                {
                    Console.WriteLine(year.CustomerName);
                    foreach (var x in year.OrderbyYears)
                    {
                        Console.WriteLine(x.Year);
                        foreach (var m in x.OrderbyMonths)
                        {

                            
                            Console.WriteLine($"{m.month} - {m.orders}");
                            

                        }
                    }
                }
            
        }

        /// <summary>
        /// Print the unique list of product categories
        /// </summary>
        static void Exercise22()
        {
            var categories = DataLoader.LoadProducts().OrderBy(p => p.Category);

            Console.WriteLine(categories);
        }

        /// <summary>
        /// Write code to check to see if Product 789 exists
        /// </summary>
        static void Exercise23()
        {
            var results = DataLoader.LoadProducts().Any(p => p.ProductID == 789);

            Console.WriteLine(results);
        }

        /// <summary>
        /// Print a list of categories that have at least one product out of stock
        /// </summary>
        static void Exercise24()
        {
            List<Product> products = DataLoader.LoadProducts();

            var results = (from p in products
                           where p.UnitsInStock == 0
                           select new
                           {
                               outofStock = p.Category
                           }).Distinct();
            foreach (var p in results)
            {
                Console.WriteLine(p.outofStock);
            }
        }

        /// <summary>
        /// Print a list of categories that have no products out of stock
        /// </summary>
        static void Exercise25()
        {
            List<Product> products = DataLoader.LoadProducts();

            //var results = products.Select(p => p.UnitsInStock).Min();
            var results = from p in products
                          group p by p.Category
                into newgroup
                          where newgroup.All(a => a.UnitsInStock > 0)
                          orderby newgroup.Key
                          select newgroup;
            foreach (var p in results)
            {
                Console.WriteLine(p.Key);
            }
        }

        // <summary>
        // Count the number of odd numbers in NumbersA
        // </summary>
        static void Exercise26()
        {
            int[] numbers = DataLoader.NumbersA;

            var results = (from n in numbers
                           where n % 2 == 1
                           select n).Count();

            Console.WriteLine("There are {0} odd numbers in the array.", results);

        }

        /// <summary>
        /// Create and print an anonymous type containing CustomerId and the count of their orders
        /// </summary>
        static void Exercise27()
        {
            List<Customer> customers = DataLoader.LoadCustomers();

            var result = from c in customers
                         select new
                         {
                             customerID = c.CustomerID,
                             orderCount = (from o in c.Orders
                                           select o).Count()
                         };

            foreach (var c in result)
            {

                Console.WriteLine($"{c.customerID}, {c.orderCount}");

            }
        }

        /// <summary>
        /// Print a distinct list of product categories and the count of the products they contain
        /// </summary>
        static void Exercise28()
        {
            List<Product> products = DataLoader.LoadProducts();

            var results = from p in products
                          select new
                          {
                              Categories = p.Category,
                              productCount = (from c in p.ProductName
                                              select c).Count()

                          };
            foreach (var c in results)
            {
                Console.WriteLine($"{c.Categories}, {c.productCount}");
            }
        }

        /// <summary>
        /// Print a distinct list of product categories and the total units in stock
        /// </summary>
        static void Exercise29()
        {
            List<Product> products = DataLoader.LoadProducts();

            var results = products.GroupBy(p => p.Category).Select(g => new
            {
                Key = g.Key,
                totalUnits = g.Sum(s => s.UnitsInStock),

            });

            foreach (var p in results)
            {
                Console.WriteLine($"{p.Key}, {p.totalUnits}");
            }
        }

        /// <summary>
        /// Print a distinct list of product categories and the lowest priced product in that category
        /// </summary>
        static void Exercise30()
        {
            List<Product> products = DataLoader.LoadProducts();

            var results = products.GroupBy(p => p.Category).Select(g => new
            {
                Key = g.Key,
                lowestprice = g.Min(s => s.UnitPrice),
                lowestpriceditem = g.OrderBy(p => p.UnitPrice).Select(n => n.ProductName).FirstOrDefault()
            });

            foreach (var p in results)
            {
                Console.WriteLine($"{p.Key},{p.lowestpriceditem}, {p.lowestprice:C}");
            }
        }

        /// <summary>
        /// Print the top 3 categories by the average unit price of their products
        /// </summary>
        static void Exercise31()
        {
            List<Product> products = DataLoader.LoadProducts();

            var results = products.GroupBy(p => p.Category).Select(g => new
            {
                Key = g.Key,
                averageprice = g.Average(u => u.UnitPrice)

            }).OrderByDescending(x => x.averageprice).Take((3));

            foreach (var p in results)
            {
                Console.WriteLine($"{p.Key}, {p.averageprice:C}");
            }
        }
    }
}
