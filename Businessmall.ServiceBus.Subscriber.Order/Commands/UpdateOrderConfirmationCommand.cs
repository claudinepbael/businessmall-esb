using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Businessmall.Application.Infrastracture.Constants;

namespace Businessmall.SB.Subscriber.Order.Commands
{
    public class UpdateOrderConfirmationCommand
    {
        public Guid _orderGUID { get; set; }
        public bool _isConfirmed { get; set; }
        public Constants.OrderStatus _status { get; set; }
        public DateTime _dateConfirmed { get; set; }
    }
}
