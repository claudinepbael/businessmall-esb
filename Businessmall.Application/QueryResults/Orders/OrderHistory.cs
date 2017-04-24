using Businessmall.Application.Infrastracture.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Businessmall.Application.QueryResults.Orders
{
    public class OrderHistory: IQueryResult
    {
        public Guid orderId { get; set; }
        public int productId { get; set; }
        public string productName { get; set; }
        public int userId { get; set; }
        public int quantity { get; set; }
        public decimal price { get; set; }
        public decimal totalPrice { get; set; }
        public string status { get; set; }
        public DateTime dateOrdered { get; set; }
    }
}
