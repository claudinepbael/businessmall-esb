using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Businessmall.SB.Subscriber.Order.Commands
{
    public class UpdateOrderConfirmationCommand
    {
        public Guid _orderGUID { get; set; }
        public bool _isConfirmed { get; set; }
    }
}
