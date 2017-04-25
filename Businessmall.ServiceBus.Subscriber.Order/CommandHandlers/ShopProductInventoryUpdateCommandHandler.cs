using Businessmall.SB.Subscriber.Order.Commands;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Businessmall.SB.Subscriber.Order.CommandHandlers {
    public partial class CommandHandler {
        


        public bool UpdateShopProductInventory(ShopProductInventoryUpdateCommand command){

            try{
                SqlConnection SqlCon = new SqlConnection(Properties.Settings.Default.ShopDBConnection);
                if (SqlCon.State == System.Data.ConnectionState.Closed)
                {
                    SqlCon.Open();
                }

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = SqlCon;
                sqlCommand.CommandText = UpdateSqlQuery();
                sqlCommand.Parameters.Add(new SqlParameter("@productID", SqlDbType.Int) { Value = command.productID });
               


                int numberOfRowsAffected = sqlCommand.ExecuteNonQuery();

                return true;
            }catch(Exception e ){
                return false;
            }
            
            

        }

        private string UpdateSqlQuery (){
            return @"
                
                    Update S set S.available_qty= bo.available_qty FROM [esb.shop].dbo.Product S
                    INNER JOIN(
	                    SELECT id, available_qty 
	                    FROM [esb.businessmall].dbo.Product 
	                    WHERE id = @productID
                    ) as bo ON bo.id  = S.product_id
                    WHERE S.product_id = @productID


            ";
        }

    }
}
