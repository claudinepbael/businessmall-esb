using Businessmall.Application.Infrastracture.Contracts;
using Businessmall.Application.Queries;
using Businessmall.Application.QueryResults.Orders;
using Businessmall.Application.Infrastracture.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Businessmall.Application.Queries.Order;

namespace Businessmall.Application.QueryHandlers.Orders
{
    public class GetOrderTotalPriceResultHandler : IQueryHandler<GetOrderTotalPriceQuery,OrderTotalPriceResult> {

       private IDataContext _dataContext;

       public GetOrderTotalPriceResultHandler(IDataContext dataContext)
       {
           _dataContext = dataContext;

       }

       public OrderTotalPriceResult Retrieve(GetOrderTotalPriceQuery query)
       {
           var result = new OrderTotalPriceResult();

           result = _dataContext.FindOne<GetOrderTotalPriceQuery, OrderTotalPriceResult>(this.GetSQLQuery(), query);

           return result;
       }

       private string GetSQLQuery (){

           return AppDomain.CurrentDomain.GetResourceString("Businessmall.Application.SqlQueries.GetOrderTotalPriceQuery.sql");
       }

    }
}
