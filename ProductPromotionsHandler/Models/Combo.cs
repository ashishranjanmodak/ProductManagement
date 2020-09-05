using System;
using System.Collections.Generic;
using System.Text;

namespace ProductPromotionsHandler.Models
{
    class Combo
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
