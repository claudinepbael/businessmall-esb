using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Businessmall.Shop.Infrastructure.Commands
{
    class AddOrderForUserCommand
    {
        public string productId;
        public string userId;
        public decimal quantity;

    }
}
