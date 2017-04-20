using Businessmall.Application.Infrastracture.Contracts;
using Businessmall.Application.Queries.Order;
using Businessmall.Application.QueryResults.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Businessmall.Application.Infrastracture.Helpers;

namespace Businessmall.Application.QueryHandlers.Orders {
    public class GetOrderDetailsQueryHandler: IQueryHandler<GetOrderDetailsQuery,OrderDetailsQueryResult> {

        private IDataContext _dataContext;

        public GetOrderDetailsQueryHandler(IDataContext dataContext){
            _dataContext = dataContext;
        }



        public OrderDetailsQueryResult Retrieve (GetOrderDetailsQuery query){
            var result = new OrderDetailsQueryResult();

            result = _dataContext.FindOne<GetOrderDetailsQuery,OrderDetailsQueryResult>(GetSqlQuery(),query);

            return result;
        }

        private string GetSqlQuery(){
            return AppDomain.CurrentDomain.GetResourceString("Businessmall.Application.SqlQueries.GetOrderDetailsQuery.sql");
        }
    }
}
