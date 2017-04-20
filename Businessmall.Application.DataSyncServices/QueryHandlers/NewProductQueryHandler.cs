using Businessmall.Application.DataSyncServices.Queries;
using Businessmall.Application.DataSyncServices.QueryResults;

using Businessmall.Application.Infrastracture.Contracts;
using Businessmall.Application.Infrastracture.Helpers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Businessmall.Application.DataSyncServices.QueryHandlers {
    public partial class QueriesImplementation {

        public IDataContext _dataContext;

        public QueriesImplementation (){
            
        }

        public SelectList<NewAddedProducts> RetrieveNewAddedProducts (NewProductQuery query){
            var result = new SelectList<NewAddedProducts>();
            try{
                SqlConnection SqlCon = new SqlConnection(Properties.Settings.Default.DBConnection);
                if(SqlCon.State == System.Data.ConnectionState.Closed){
                    SqlCon.Open();
                }
                SqlCommand command = new SqlCommand();
                command.Connection = SqlCon;
                command.CommandText = getNewAddedProducts();
                SqlDataReader dataReader = command.ExecuteReader();
                System.Collections.Generic.List<NewAddedProducts> newProducts = new List<NewAddedProducts>();
                if(dataReader.HasRows){
                    while(dataReader.Read()){
                        NewAddedProducts newProduct = new NewAddedProducts();
                        newProduct.id = Convert.ToInt32(dataReader["id"].ToString());
                        newProduct.name = dataReader["name"].ToString();
                        newProduct.price = Convert.ToDecimal(dataReader["price"].ToString());
                        newProduct.available_qty = Convert.ToInt32(dataReader["available_qty"].ToString());
                        newProducts.Add(newProduct);
                    }
                }


                result.Data = newProducts;
                return result;
            }catch(Exception e){
                return result;
            }
        }
        public bool AddNewProducts(){
            try{
                SqlConnection SqlCon = new SqlConnection(Properties.Settings.Default.DBConnection);
                if(SqlCon.State == System.Data.ConnectionState.Closed){
                    SqlCon.Open();
                }
                SqlCommand command = new SqlCommand();
                command.Connection = SqlCon;
                command.CommandText = SQLQuery();
                command.ExecuteNonQuery();


                return true;
            }catch(Exception e){
                return false;
            }
        }
        private string getNewAddedProducts() {
            return @"
                   
                    SELECT   bmall_prod.id as id
		                    ,bmall_prod.name as name
		                    ,bmall_prod.price as price
		                    ,bmall_prod.available_qty as available_qty
                    FROM [esb.businessmall].dbo.Product  as bmall_prod 
                    LEFT OUTER JOIN [esb.shop].dbo.Product  new_product ON new_product.product_id = bmall_prod.id
                    where new_product.product_id is null";
        }
        private string SQLQuery() {
            return @"
                    INSERT INTO [esb.shop].dbo.Product (product_id,name,price,available_qty) 
                    
                    SELECT   bmall_prod.id as id
		                    ,bmall_prod.name as name
		                    ,bmall_prod.price as price
		                    ,bmall_prod.available_qty as available_qty
                    FROM [esb.businessmall].dbo.Product  as bmall_prod 
                    LEFT OUTER JOIN [esb.shop].dbo.Product  new_product ON new_product.product_id = bmall_prod.id
                    where new_product.product_id is null ";
        }
    }
}
