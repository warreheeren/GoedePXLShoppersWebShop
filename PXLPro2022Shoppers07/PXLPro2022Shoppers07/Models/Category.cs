using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace PXLPro2022Shoppers07.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public List<Product> Products { get; set; }

    }
}
