using Businessmall.SB.Subscriber.Order.Queries;
using Businessmall.SB.Subscriber.Order.QueryResults;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Businessmall.SB.Subscriber.Order.QueryHandlers
{
    public partial class QueryHandler
    {
        public QueryHandler(){

        }

        public ProductDetails RetriveProductDetails(GetProductDetailsQuery query){
            
            var product = new ProductDetails();

            try
            {
                SqlConnection SqlCon = new SqlConnection(Properties.Settings.Default.BackOfficeDBConnection);
                if (SqlCon.State == System.Data.ConnectionState.Closed)
                {
                    SqlCon.Open();
                }
                SqlCommand command = new SqlCommand();
                command.Connection = SqlCon;
                command.CommandText = getProductDetailsQueryString();
                command.Parameters.AddWithValue("@productId", query.productId);
                SqlDataReader dataReader = command.ExecuteReader(CommandBehavior.SingleRow);


                if (dataReader.HasRows)
                {
                    dataReader.Read();
                    product.name = dataReader["name"].ToString();
                    product.price = Convert.ToDecimal(dataReader["price"].ToString());
                    product.avaialableQty = Convert.ToInt32(dataReader["available_qty"].ToString());
                    product.productId = Convert.ToInt32(dataReader["id"].ToString());
                    
                }
                SqlCon.Close();
                return product;
            }
            catch (Exception ex)
            {
                return product;
            }

        }

        private string getProductDetailsQueryString()
        {
            return @"
                    SELECT  *
                    FROM [esb.businessmall].[dbo].Product
                    WHERE id = @productId
                    ";
        }
    }
}
