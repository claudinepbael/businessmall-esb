using Businessmall.Models.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Businessmall.ViewModels.Orders
{
    public class ListOrdersViewModel
    {
        public List<OrderDetails> Orders { get; set; }

        public ListOrdersViewModel()
        {
            List<Order> orderList = new List<Order>();
            this.Orders = new List<OrderDetails>();
            using (var context = new BusinessmallEntities())
            {
                orderList = (from item in context.Orders select item).ToList();

                foreach(Order order in orderList){
                    this.Orders.Add(
                        new OrderDetails { 
                            orderId = order.order_id,
                            productId = order.product_id,
                            productName = order.Product.name,
                            userFullname = order.User.first_name + " " + order.User.last_name,
                            userId = order.User.id,
                            quantity = order.quantity
                        });
                }
            }
        }
    }


}