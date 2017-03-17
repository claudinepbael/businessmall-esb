using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Businessmall.ViewModels.Products
{
    public class ListProductsViewModel
    {
        public List<Product> Products { get; set; }

        public ListProductsViewModel() { 
            using (var context = new BusinessmallEntities())
            {
                this.Products = (from item in context.Products select item).ToList();
            }
        }
    }
}