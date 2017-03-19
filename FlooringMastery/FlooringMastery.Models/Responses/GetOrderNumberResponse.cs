using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.Models.Responses
{
    public class GetOrderNumberResponse:Response
    {
        public int OrderNumber { get; set; }
        public List<Orders> Orders { get; set; }
    }
}
