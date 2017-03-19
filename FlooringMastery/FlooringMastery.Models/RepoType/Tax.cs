using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.Models.RepoType
{
    public class Tax
    {
        public string State { get; set; }
        public string StateName { get; set; }
        public decimal TaxRate { get; set; }
    }
}
