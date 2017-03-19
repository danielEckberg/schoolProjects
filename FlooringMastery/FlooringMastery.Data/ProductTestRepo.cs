using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.Models.Interfaces;
using FlooringMastery.Models.RepoType;

namespace FlooringMastery.Data
{
    public class ProductTestRepo : IProductRepository
    {

        private static Product _product = new Product()
        {
            ProductType = "Carpet",
            CostPerSquareFoot = 2.25M,
            LaborCostPerSquareFoot = 2.10M
        };


        public List<Product> GetProductList()
        {
            List<Product> products = new List<Product>();
            {
                products.Add(_product);
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
