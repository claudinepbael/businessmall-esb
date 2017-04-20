using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Businessmall.DTOs.Products
{
    public class UpdateProductCommand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int InitialQty { get; set; }
        public int PurchasedQty { get; set; }
        public decimal Price { get; set; }
    }
}