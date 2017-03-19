using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.Models.RepoType;

namespace FlooringMastery.Models.Responses
{
    public class ProductLookupResponse: Response
    {
        public Product Product { get; set; }
    }
}
