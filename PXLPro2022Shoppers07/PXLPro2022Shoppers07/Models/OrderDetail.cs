namespace PXLPro2022Shoppers07.Models
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
    }
}
