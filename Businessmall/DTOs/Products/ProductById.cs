using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Businessmall.DTOs.Products
{
    public class ProductById
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int QtyAtHand { get; set; }
        public decimal Price { get; set; }
    }
}