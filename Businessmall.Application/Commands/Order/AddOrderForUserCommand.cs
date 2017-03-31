using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Businessmall.Application.Commands
{
    class AddOrderForUserCommand
    {
        public string _productId { get; set; }
        public string _userId { get; set; }
        public decimal _quantity { get; set; }

    }
}
