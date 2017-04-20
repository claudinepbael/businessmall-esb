using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Businessmall.DTOs.Products;
using System.Data;
using Businessmall.Interfaces;
using System.Data.Entity;

namespace Businessmall.Repositories
{
    public partial class BusinessmallService : IBusinessmallService
    {

        public Product AddProduct(AddProductCommand addProductCommand)
        {
            Product newlyAddedProduct = GetNewProductInstance(addProductCommand);
            _dbContext.GetDBContext().Products.AddObject(newlyAddedProduct);
            _dbContext.GetDBContext().SaveChanges();
            return newlyAddedProduct;
        }

        public Product GetNewProductInstance(AddProductCommand addProductCommand)
        {
            return new Product
            {
                name = addProductCommand.Name,
                price = addProductCommand.Price,
                initial_qty = addProductCommand.InitialQty,
                purchased_qty = addProductCommand.PurchasedQty
            };
        }
            
        public Product GetProductById(int ID)
        {
            Product productToGet;
            productToGet = (from product in _dbContext.GetDBContext().Products
                                      where product.id == ID
                                      select product).First();

            return productToGet;
        }

        public bool UpdateProduct(UpdateProductCommand updateProductCommand)
        {
            Product productToBeUpdated = GetProductById(updateProductCommand.Id);
            //using (var db = new BusinessmallEntities())
            //{
                productToBeUpdated.name         = updateProductCommand.Name;
                productToBeUpdated.price        = updateProductCommand.Price;
                productToBeUpdated.initial_qty  = updateProductCommand.InitialQty;
                productToBeUpdated.purchased_qty = updateProductCommand.PurchasedQty;
                //_dbContext.GetDBContext().Entry(productToBeUpdated).State = EntityState.Modified;
                _dbContext.GetDBContext().ObjectStateManager.ChangeObjectState(productToBeUpdated,EntityState.Modified);
                _dbContext.GetDBContext().SaveChanges();
            //}
            return true;
        }

        
    }
}