using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Businessmall.Application.Infrastracture.Contracts;

namespace Businessmall.Application.Commands.Orders
{
    public class CheckoutOrderCommand :ICommand
    {
        public int productId { get; set; }
        public int quantity { get; set; }
        public int userId { get; set; }

    }
}
