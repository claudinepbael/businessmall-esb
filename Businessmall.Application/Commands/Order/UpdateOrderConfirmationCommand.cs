using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Businessmall.Application.Infrastracture.Contracts;

namespace Businessmall.Application.Commands.Orders
{
    public class UpdateOrderConfirmationCommand : ICommand
    {
        public Guid _orderGUID { get; set; }
        public bool _isConfirmed { get; set; }
    }
}
