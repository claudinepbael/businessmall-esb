using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Businessmall.Application.Infrastracture.Contracts;
using Businessmall.Application.Commands.Orders;
using Businessmall.Application.CommandResults;
using Businessmall.Application.Infrastracture.Helpers;
using Businessmall.Application.QueryResults.Orders;
using Businessmall.Application.Queries;

namespace Businessmall.Application.CommandHandlers
{
    public class CheckoutOrderCommandHandlerWithResult : ICommandHandlerWithReturn<CheckoutOrderCommand, CheckoutShopOrderCommandResult>
    {
        private IDataContext _dataContext;
        public CheckoutOrderCommandHandlerWithResult(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public CheckoutShopOrderCommandResult Execute(CheckoutOrderCommand command)
        {
            Guid result_order_id = _dataContext.ExecuteWithResult<CheckoutOrderCommand, Guid>(GetCommandQuery(), command);

            return new CheckoutShopOrderCommandResult {order_id = result_order_id};
        }
        

        private string GetCommandQuery(){
            return AppDomain.CurrentDomain.GetResourceString("Businessmall.Application.SqlQueries.CheckoutShopOrderQuery.sql");
        }

    }
}
