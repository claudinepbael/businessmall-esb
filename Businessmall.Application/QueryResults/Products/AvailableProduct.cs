using Businessmall.Application.Infrastracture.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Businessmall.Application.QueryResults.Products {
    public class AvailableProduct:IQueryResult {

        public int id {get;set;}
        public string name {get;set;}
        public decimal price {get;set;}
        public int availableQty {get;set;}

    }
}
