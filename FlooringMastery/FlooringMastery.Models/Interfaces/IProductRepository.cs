using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.Models.RepoType;

namespace FlooringMastery.Models.Interfaces
{
    public interface IProductRepository
    {
        List<Product> GetProductList();
        Product ChooseProduct(string productType);
    }
}
