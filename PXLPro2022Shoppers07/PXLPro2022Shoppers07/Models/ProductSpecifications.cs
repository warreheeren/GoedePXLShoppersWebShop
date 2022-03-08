using System.ComponentModel.DataAnnotations;

namespace PXLPro2022Shoppers07.Models
{
    public class ProductSpecifications
    {
        [Key]
        public int Id { get; set; }
        public string Color { get; set; }
        public string Description { get; set; }
        public ProductBrand Brand { get; set; }

    }
}
