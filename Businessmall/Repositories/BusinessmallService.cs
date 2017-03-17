using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Businessmall.Interfaces;


namespace Businessmall.Repositories
{
    public partial class BusinessmallService : IBusinessmallService, IDisposable
    {

        private readonly IDBContext _dbContext;
        private bool disposed = false;

        public BusinessmallService()
            : this(null)
        {

        }

        public BusinessmallService(IDBContext dbContext)
        {

            _dbContext = dbContext ?? BMallContext.InProcessMallContext();
        }

       public void Dispose(){
           if(!disposed){
               this.disposed = true;
               this.Dispose();
           }
        }


    }
}