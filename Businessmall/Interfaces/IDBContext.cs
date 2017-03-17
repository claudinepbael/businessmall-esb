using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Businessmall.Interfaces
{
    public  interface IDBContext {
      BusinessmallEntities GetDBContext();
       
    }
}