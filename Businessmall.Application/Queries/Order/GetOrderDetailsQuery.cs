using Businessmall.Application.Infrastracture.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Businessmall.Application.Queries.Order {
   public class GetOrderDetailsQuery : IQuery {
       public Guid order_id {get;set;}
      
    }
}
