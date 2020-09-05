using System;
using System.Collections.Generic;
using System.Text;

namespace ProductPromotionsHandler.Models
{
    public class ComboPromotion
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
