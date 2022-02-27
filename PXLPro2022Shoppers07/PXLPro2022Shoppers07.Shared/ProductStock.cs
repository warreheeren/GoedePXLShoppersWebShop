using System;
using System.Collections.Generic;
using System.Text;

namespace PXLPro2022Shoppers07.Shared
{
    public class ProductStock
    {
        public int ProductStockId { get; set; }
        public string? ProductName { get; set; }
        public int Amount { get; set; }
        public bool InStock => Amount > 0;
    }
}
