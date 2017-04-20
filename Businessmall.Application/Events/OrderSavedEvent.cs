using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Businessmall.Application.Infrastracture.Contracts;
using Businessmall.Application.Infrastracture.Constants;

namespace Businessmall.Application.Events
{
    public class OrderSavedEvent : IEvent
    {
        public Guid _orderGUID { get; set; }
        public bool _isConfirmed { get; set; }
        public Constants.OrderStatus _status { get; set; }
    }
}
