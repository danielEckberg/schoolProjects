using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.Data;

namespace FlooringMastery.BLL
{
    public class ProductManagerFactory
    {
        public static ProductManager Create()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();

            switch (mode)
            {
                case "Test":
                    return new ProductManager(new ProductTestRepo());
                case "Live":
                    return new ProductManager(new ProductRepository(ProductRepository.productFilePath));
                default:

                    throw new Exception("Mode value in app config is not valid");

            }
        }
    }
}
