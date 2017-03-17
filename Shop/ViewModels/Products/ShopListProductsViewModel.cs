using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Shop.ViewModels.Products
{
    public class ShopListProductsViewModel
    {
        public List<Product> Products { get; set; }

        public ShopListProductsViewModel()
        {
            this.Products = new List<Product>();
        }
    }
}