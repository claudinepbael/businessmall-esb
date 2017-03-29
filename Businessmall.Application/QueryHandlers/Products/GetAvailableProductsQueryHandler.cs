using Businessmall.Application.Infrastracture.Contracts;
using Businessmall.Application.Queries.Product;
using Businessmall.Application.QueryResults.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Businessmall.Application.Infrastracture.Helpers;

namespace Businessmall.Application.QueryHandlers.Products {
    public class GetAvailableProductsQueryHandler: IQueryHandler<GetAvailableProductsQuery,SelectList<AvailableProduct>> {
        private IDataContext _dataContext;
        public GetAvailableProductsQueryHandler(IDataContext dataContext){
            _dataContext = dataContext;
        }
        public SelectList<AvailableProduct> Retrieve(GetAvailableProductsQuery query){
             var result  = new SelectList<AvailableProduct>();

            result.Data = _dataContext.Find<AvailableProduct>(GetSelectQuery()).ToList();

            return result;
        }

         private string GetSelectQuery(){
           
            
            return AppDomain.CurrentDomain.GetResourceString("Businessmall.Application.SqlQueries.GetAvailableProducts.sql");
        }
    }
}
