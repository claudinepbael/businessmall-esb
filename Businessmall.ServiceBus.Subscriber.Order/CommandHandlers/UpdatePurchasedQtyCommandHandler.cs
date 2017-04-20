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

        public bool updatePurchasedQty(UpdatePurchasedQtyCommand updateCommand) {

            try
            {
                SqlConnection SqlCon = new SqlConnection(Properties.Settings.Default.BackOfficeDBConnection);
                if (SqlCon.State == System.Data.ConnectionState.Closed)
                {
                    SqlCon.Open();
                }

                SqlCommand command = new SqlCommand();
                command.Connection = SqlCon;
                command.CommandText = getUpdatePurchasedQtyQuery();
                command.Parameters.Add(new SqlParameter("@productId", SqlDbType.Int) { Value = updateCommand.productId });
                command.Parameters.Add(new SqlParameter("@getUpdatePurchasedQtyQuery", SqlDbType.Int) { Value = updateCommand.additionalPurchasedQty });

                int numberOfRowsAffected = command.ExecuteNonQuery();

                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }

        private string getUpdatePurchasedQtyQuery() {
            return @"
                UPDATE [esb.businessmall].[dbo].[Product]
                SET purchased_qty = purchased_qty + @getUpdatePurchasedQtyQuery
                WHERE id = @productId
            ";
        }

    }
}
