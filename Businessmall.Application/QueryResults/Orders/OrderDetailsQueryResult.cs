using Businessmall.Application.Infrastracture.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Businessmall.Application.QueryResults.Orders {
    public class OrderDetailsQueryResult : IQueryResult  {

        public Guid orderID {get;set;}
        public string productName {get;set;}
        public int quantity {get;set;}
        public decimal price {get;set;}

    }
}
