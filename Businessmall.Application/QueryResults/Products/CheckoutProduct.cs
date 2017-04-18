using Businessmall.Application.Infrastracture.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Businessmall.Application.QueryResults.Products
{
    public class CheckoutProduct : IQueryResult
    {
        public string productId { get; set; }
        public string productName { get; set; }
        public string price { get; set; }
        public int availableQty { get; set; }
    }
}
