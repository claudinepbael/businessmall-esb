using Businessmall.Application.Infrastracture.Contracts;
using Businessmall.Application.Queries.Order;
using Businessmall.Application.QueryResults.Orders;
using Businessmall.Application.Infrastracture.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Businessmall.Application.QueryHandlers.Orders {
   public class GetOrderStatusQueryHandler : IQueryHandler<GetOrderStatusQuery,OrderStatusQueryResult> {

       private IDataContext _dataContext;

       public GetOrderStatusQueryHandler(IDataContext dataContext){
           _dataContext = dataContext;

       }

       public OrderStatusQueryResult Retrieve (GetOrderStatusQuery query){
           var result = new OrderStatusQueryResult();

           result = _dataContext.FindOne<GetOrderStatusQuery,OrderStatusQueryResult>(this.GetSQLQuery(),query);

           return result;
       }

       private string GetSQLQuery (){
           
           return AppDomain.CurrentDomain.GetResourceString("Businessmall.Application.SqlQueries.GetOrderStatusQuery.sql");
       }

    }
}
