using Businessmall.Application.Infrastracture.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Businessmall.SB.Subscriber.Order.Commands
{
    public class SaveOrderCommand : ICommand
    {
        public Guid _orderGUID { get; set; }
        public int _productId { get; set; }
        public int _quantity { get; set; }
        public int _userId { get; set; }
        public decimal _totalPrice { get; set; }
    }
}
