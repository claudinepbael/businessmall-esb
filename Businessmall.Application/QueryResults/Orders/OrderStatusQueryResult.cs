using Businessmall.Application.Infrastracture.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Businessmall.Application.QueryResults.Orders {
    public class OrderStatusQueryResult:IQueryResult {
        public int status {get;set;}
    }
}
