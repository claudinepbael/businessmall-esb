using Businessmall.Application.Infrastracture.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Businessmall.SB.Subscriber.Order.QueryResults
{
    public class ProductDetails: IQueryResult
    {
        public int productId { get; set; }
        public string name { get; set; }
        public int avaialableQty { get; set; }
        public decimal price { get; set; }
    }
}
