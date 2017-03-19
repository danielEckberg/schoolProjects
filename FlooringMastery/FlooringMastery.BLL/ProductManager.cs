using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.Models.Interfaces;
using FlooringMastery.Models.RepoType;
using FlooringMastery.Models.Responses;

namespace FlooringMastery.BLL
{
    public class ProductManager
    {
        private IProductRepository _productRepository;

        public ProductManager(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public ProductListResponse ProductList()
        {
            ProductListResponse response = new ProductListResponse();

            response.Products = _productRepository.GetProductList();

            if (response.Products == null)
            {
                response.Success = false;
                response.Message = "There was an error with the Products File. Contact IT.";
            }
            else
            {
                response.Success = true;
            }
            return response;
        }


        public ProductLookupResponse ChooseProduct(string ProductType)
        {
            ProductLookupResponse response = new ProductLookupResponse();

            response.Product = _productRepository.ChooseProduct(ProductType);

            if (response.Product == null)
            {
                response.Success = false;
                response.Message = $"{ProductType} is not a product we currently sell";
            }
            else
            {
                response.Success = true;
            }
            return response;
        }
    }
}
