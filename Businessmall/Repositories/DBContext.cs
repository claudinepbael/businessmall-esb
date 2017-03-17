using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Businessmall.Interfaces;

namespace Businessmall.Repositories
{
    public class DBContext : IDBContext
    {

        private BusinessmallEntities context = new BusinessmallEntities();
        public BusinessmallEntities GetDBContext()
        {

            return context;
        }

    }

}
