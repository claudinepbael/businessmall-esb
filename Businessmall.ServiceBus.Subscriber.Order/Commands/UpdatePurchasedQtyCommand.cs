using Businessmall.Application.Infrastracture.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Businessmall.SB.Subscriber.Order.Commands
{
    public class UpdatePurchasedQtyCommand:ICommand
    {
        public int productId { get; set; }
        public int additionalPurchasedQty { get; set; }
    }
}
