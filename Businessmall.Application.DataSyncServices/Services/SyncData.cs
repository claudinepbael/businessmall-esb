using Businessmall.Application.DataSyncServices.Contracts;
using Businessmall.Application.DataSyncServices.Queries;
using Businessmall.Application.DataSyncServices.QueryHandlers;
using Businessmall.Application.DataSyncServices.QueryResults;
using Businessmall.Application.Infrastracture.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Businessmall.Application.DataSyncServices.Services {
    public class SyncData: IDataSyncService {
        private readonly IQueryDispatcher _queryDispatcher;
        private readonly ICommandDispatcher _commanddDispatcher;
        private QueriesImplementation _queryHandler;

        public SyncData(){
           _queryHandler = new QueriesImplementation();
        }
        public void SyndProductData(){

            var result  = _queryHandler.RetrieveNewAddedProducts(new NewProductQuery());
            _queryHandler.AddNewProducts();

        }

    }
}
