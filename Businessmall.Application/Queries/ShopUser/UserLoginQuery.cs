using Businessmall.Application.Infrastracture.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Businessmall.Application.Queries.ShopUser
{
    public class UserLoginQuery :IQuery {

        public string _userName {get;set;}
        public string _password {get;set;}
    }
}
