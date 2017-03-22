using Businessmall.Application.Infrastracture.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Businessmall.Application.QueryResults.ShopUsers {
   public class LoggedInUser :IQueryResult {

       public int userID {get;set;}
       public string userName {get;set;}
       public string fullName {get;set;}
    }
}
