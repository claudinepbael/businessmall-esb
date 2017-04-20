using Businessmall.Application.Infrastracture.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Businessmall.Application.CommandResults
{
    public class CheckoutShopOrderCommandResult : ICommandResult
    {
        public Guid order_id { get; set; }
    }
}
