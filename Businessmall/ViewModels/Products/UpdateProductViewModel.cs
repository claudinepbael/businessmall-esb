﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Businessmall.ViewModels.Products
{
    public class UpdateProductViewModel
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int InitialQty { get; set; }
        public int PurchasedQty { get; set; }

        public UpdateProductViewModel(int id)
        {
            Product productToBeUpdated;
            using (var context = new BusinessmallEntities())
            { 
                productToBeUpdated = (from product in context.Products 
                                where product.id == id 
                                select product).First();
            }

            this.Id = id;
            this.Name = productToBeUpdated.name;
            this.Price = productToBeUpdated.price;
            this.InitialQty = productToBeUpdated.initial_qty;
            this.PurchasedQty = (int)productToBeUpdated.purchased_qty;
        }
    }
}