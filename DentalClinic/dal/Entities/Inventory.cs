using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dal.Entities
{
    public class Inventory
    {
        public string ToolName { get; set; }
        public int QuantitySold { get; set; }
        public int QuantityPurchased { get; set; }
        public int ConsumedQuantity { get; set; }

        public int RemainingQuantity { get; set; }

        public DateTime? LastUpdateDate { get; set; }

    }
}
