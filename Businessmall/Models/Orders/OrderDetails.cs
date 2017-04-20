using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Businessmall.Models.Orders
{
    public class OrderDetails
    {
        public Guid orderId { get; set; }
        public int productId { get; set; }
        public string productName {get;set;}
        public string userFullname {get;set;}
        public int userId { get; set; }
        public int quantity { get; set; }

    }
}