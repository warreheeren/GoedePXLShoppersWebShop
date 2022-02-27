using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PXLPro2022Shoppers07.Data;
using PXLPro2022Shoppers07.Models;

namespace PXLPro2022Shoppers07.Services
{
    public class OrderRepository : IOrderRepository
    {
        appDbContext _context;
        public OrderRepository(appDbContext context)
        {
            _context = context;
        }



        public void Purchase(ShoppingCart items, UserDetails identityUser)
        {
            var orderdetails = new List<OrderDetail>();
            foreach (var x in items.ShoppingCartItems)
            {
                var orderdetail = new OrderDetail()
                {
                    Amount = x.Amount,
                    Price = x.Amount * x.Product.Price,
                    ProductId = x.Product.ProductId,
                };

                orderdetails.Add(orderdetail);
            }
            var order = new Order();
            order.OrderDate = DateTime.Now.ToShortDateString();
            order.Name = identityUser.Email;
            order.IdentityUser = identityUser;
            order.OrderDetails.AddRange(orderdetails);
            _context.Orders.Add(order);
            _context.ShoppingCarts.Remove(items);
            _context.SaveChanges();
        }

        public IEnumerable<Order> getOrders(string id)
        {

            return _context.Orders.Where(x => x.IdentityUser.Id == id);
        }


        public IEnumerable<OrderDetail> getOrderDetails(int id)
        {

            return _context.OrderDetails.Where(x => x.OrderId == id).Include(x => x.Product).ThenInclude(x => x.ProductImage); 
        }

    }
}
