using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.Models
{
    public class Orders
    {
        public int OrderNumber { get; set; }
        public string Name { get; set; }
        public string State { get; set; }
        public decimal TaxRate { get; set; }
        public string PrductType { get; set; }
        public decimal Area { get; set; }
        public decimal CostPerSqureFoot { get; set; }
        public decimal LaborCostPerSquareFoot { get; set; }
        public decimal MaterialCost { get; set; }
        public decimal LaborCost { get; set; }
        public decimal Tax { get; set; }
        public decimal Total { get; set; }
        public DateTime orderDate { get; set; }
    }

}
