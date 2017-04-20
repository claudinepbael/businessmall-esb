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
        public bool SaveOrder(UpdateOrderConfirmationCommand updateCommand)
        {
            try
            {
                SqlConnection SqlCon = new SqlConnection(Properties.Settings.Default.BackOfficeDBConnection);
                if (SqlCon.State == System.Data.ConnectionState.Closed)
                {
                    SqlCon.Open();
                }

                SqlCommand command = new SqlCommand();
                command.Connection = SqlCon;
                command.CommandText = getUpdateConfirmationQueryString();
                command.Parameters.Add(new SqlParameter("@orderId", SqlDbType.UniqueIdentifier) { Value = updateCommand._orderGUID });
                command.Parameters.Add(new SqlParameter("@isConfirmed", SqlDbType.Int) { Value = updateCommand._isConfirmed });


                int numberOfRowsAffected = command.ExecuteNonQuery();

                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }

        private string getUpdateConfirmationQueryString()
        {

            return @"
                UPDATE [esb.shop].[dbo].[Orders]
                   SET 
                      [is_confirmed] = @isConfirmed
                WHERE
                    order_id = @orderId
            ";

        }

    }
}
