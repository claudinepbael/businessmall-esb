using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Businessmall.Application.Infrastracture.Contracts;

namespace Businessmall.Application.Commands
{
    public class PlaceOrderCommand :ICommand
    {
        public int _productId { get; set; }
        public int _qunatity { get; set; }
        public int _userId { get; set; }

    }
}
