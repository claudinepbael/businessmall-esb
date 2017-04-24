using Businessmall.SB.Subscriber.Order.Commands;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Businessmall.SB.Subscriber.Order.CommandHandlers
{
    public partial class CommandHandler
    {
        public CommandHandler()
        {

        }

        public bool SaveOrder(SaveOrderCommand saveCommand) {
            try
            {
                SqlConnection SqlCon = new SqlConnection(Properties.Settings.Default.BackOfficeDBConnection);
                if (SqlCon.State == System.Data.ConnectionState.Closed)
                {
                    SqlCon.Open();
                }

                SqlCommand command = new SqlCommand();
                command.Connection = SqlCon;
                command.CommandText = getSaveOrderQueryString();
                command.Parameters.Add( new SqlParameter("@orderId", SqlDbType.UniqueIdentifier) { Value = saveCommand._orderGUID });
                command.Parameters.Add(new SqlParameter("@productId", SqlDbType.Int){ Value = saveCommand._productId});
                command.Parameters.Add(new SqlParameter("@userId", SqlDbType.Int) { Value = saveCommand._userId });
                command.Parameters.Add(new SqlParameter("@quantity", SqlDbType.Int) { Value = saveCommand._quantity });
                command.Parameters.Add(new SqlParameter("@total_price", SqlDbType.Decimal) { Value = saveCommand._totalPrice });

                int numberOfRowsAffected = command.ExecuteNonQuery();
                
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
           
        }

        private string getSaveOrderQueryString()
        {
            
            return @"
                INSERT INTO [esb.businessmall].[dbo].[Order]
                    (order_id, product_id, user_id, quantity,total_price)
	                SELECT
		                @orderId,
		                @productId,
		                @userId,
		                @quantity,
                        @total_price
	                FROM [esb.businessmall].[dbo].[Product]
	                WHERE 
		                id = @productId and
		                available_qty >= @quantity
                ";
        }
    }
}
