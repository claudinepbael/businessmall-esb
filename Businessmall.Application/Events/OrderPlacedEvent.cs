using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Businessmall.Application.Infrastracture.Contracts;

namespace Businessmall.Application.Events
{
    public class OrderPlacedEvent : IEvent
    {
        public Guid _orderGUID { get; set; }
        public int _productId { get; set; }
        public int _quantity { get; set; }
        public int _userId { get; set; }
    }

}
