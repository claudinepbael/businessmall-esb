
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Businessmall.Application.Infrastracture.Contracts;
using Businessmall.Application.Queries.Product;
using Businessmall.Application.QueryResults.Products;
using Businessmall.Application.Infrastracture.Helpers;

namespace Businessmall.Application.QueryHandlers.Products
{
    public class GetOrderCheckoutDetailsQueryHandler : IQueryHandler<GetOrderCheckoutDetailsQuery, CheckoutProduct>
    {
        private IDataContext _dataContext;

        public GetOrderCheckoutDetailsQueryHandler(IDataContext dataContext){
            _dataContext = dataContext;
        }

        public CheckoutProduct Retrieve(GetOrderCheckoutDetailsQuery query)
        {
            var result = new CheckoutProduct();

            result = _dataContext.FindOne<GetOrderCheckoutDetailsQuery, CheckoutProduct>(GetSelectQuery(), query);
            
            return result;
        }

        private string GetSelectQuery()
        {
            return AppDomain.CurrentDomain.GetResourceString("Businessmall.Application.SqlQueries.GetOrderCheckoutDetailsQuery.sql");
        }

    }
}
