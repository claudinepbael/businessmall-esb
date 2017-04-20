using Businessmall.Application.Infrastracture.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Businessmall.SB.Subscriber.Order.Queries
{
    public class GetProductDetailsQuery : IQuery
    {
        public int productId { get; set; }
    }
}
