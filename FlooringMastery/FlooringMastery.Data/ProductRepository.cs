using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.Models.Interfaces;
using FlooringMastery.Models.RepoType;

namespace FlooringMastery.Data
{
    public class ProductRepository :IProductRepository
    {
        public const string productFilePath =
            @"C:\Users\dr3ek\Documents\bootcamp\daniel.eckberg.self.work\Labs\FlooringMastery\Products.txt";

        private string _productFilePath;

        public ProductRepository(string productFilePath)
        {
            _productFilePath = productFilePath;
        }


        public List<Product> GetProductList()
        {
            List<Product> products = new List<Product>();
            using (StreamReader sr = new StreamReader(productFilePath))
            {
                sr.ReadLine();
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    Product product = new Product();

                    string[] columns = line.Split('|');

                    product.ProductType = columns[0];
                    product.CostPerSquareFoot = decimal.Parse(columns[1]);
                    product.LaborCostPerSquareFoot = decimal.Parse(columns[2]);

                    products.Add(product);
                }
            }
            return products;
        }

        public Product ChooseProduct(string productType)
        {
            foreach (var product in GetProductList())
            {
                if (product.ProductType == productType)
                    return product;
            }
           return null;
        }
    }
}
