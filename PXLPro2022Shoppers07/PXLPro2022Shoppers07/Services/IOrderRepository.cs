using System.Collections.Generic;
using PXLPro2022Shoppers07.Models;

namespace PXLPro2022Shoppers07.Services
{
    public interface IOrderRepository
    {
        void Purchase(ShoppingCart shoppingCarts, UserDetails identityUser);
        IEnumerable<OrderDetail> getOrderDetails(int id);
        IEnumerable<Order> getOrders(string id);

    }
}
