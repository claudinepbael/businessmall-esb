﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Shuttle.Esb;

namespace Businessmall.Shop.Infrastructure.Commands
{
    public class LoginShopUserCommand
    {
        public string _username { get; set; }
        public string _password { get; set; }

    }
}
