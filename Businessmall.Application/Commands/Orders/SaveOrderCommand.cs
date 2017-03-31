using Businessmall.Application.Infrastracture.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Businessmall.Application.Commands
{
    public class SaveOrderCommand : ICommand
    {
        public Guid _orderGUID { get; set; }
        public int _productId { get; set; }
        public int _quantity { get; set; }
        public int _userId { get; set; }

    }
    
}
