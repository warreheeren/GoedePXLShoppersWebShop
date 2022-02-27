using PXLPro2022Shoppers07.Helpers;

namespace PXLPro2022Shoppers07.Models
{
    public class ProductImage
    {
        public int ProductImageId { get; set; }
        public string Name { get; set; }
        public byte[] ProductImageByte { get; set; }


        public string Base64String => ImageHelper.CreateBase64StringFromByteArray(ProductImageByte);




    }
}
