using Businessmall.Application.Infrastracture.Contracts;
using Businessmall.Application.Queries.Order;
using Businessmall.Application.QueryResults.Orders;
using Businessmall.Application.Infrastracture.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Businessmall.Application.QueryHandlers.Orders
{
    public class GetOrderHistoryQueryHandler : IQueryHandler<GetOrderHistoryQuery, SelectList<OrderHistory>>
    {
         private IDataContext _dataContext;

         public GetOrderHistoryQueryHandler(IDataContext dataContext)
         {
            _dataContext = dataContext;
        }

         public SelectList<OrderHistory> Retrieve(GetOrderHistoryQuery query)
         {
             SelectList<OrderHistory> result = new SelectList<OrderHistory>();

             result.Data = _dataContext.Query<GetOrderHistoryQuery,OrderHistory>(this.GetSQLQuery(),query).ToList();
             
             return result;
         }

         private string GetSQLQuery()
         {

             return AppDomain.CurrentDomain.GetResourceString("Businessmall.Application.SqlQueries.GetOrderHistoryQuery.sql");
         }
    }
}
