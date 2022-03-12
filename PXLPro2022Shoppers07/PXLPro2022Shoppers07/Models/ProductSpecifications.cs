using System.ComponentModel.DataAnnotations;

namespace PXLPro2022Shoppers07.Models
{
    public class ProductSpecifications
    {
        [Key]
        public int Id { get; set; }
        public string TitleSpecification { get; set; }
        public string TextSpecification { get; set; }

    }
}
