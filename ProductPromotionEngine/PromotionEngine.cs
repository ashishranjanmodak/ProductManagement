using ProductPromotionEngine.Models;
using ProductPromotionsHandler.Contracts;
using ProductPromotionsHandler.Models;
using System;
using System.Diagnostics;
using System.Linq;

namespace ProductPromotionEngine
{
    public class PromotionEngine
    {
        public ProductCatalog ProductCatalog;
        public PromotionsCatalog PromotionsCatalog;
        public PromotionEngine(): this(new ProductCatalog(), new PromotionsCatalog())
        {

        }
        public PromotionEngine(IProductCatalog productCatalog, IPromotionsCatalog promotionsCatalog)
        {
            ProductCatalog = (ProductCatalog) productCatalog;
            PromotionsCatalog = (PromotionsCatalog) promotionsCatalog;
        }

        public decimal CalculateCost(OrderDetails od)
        {
            return ApplyPromotionAndCalculateCost(od);
        }

        private decimal ApplyPromotionAndCalculateCost(OrderDetails od)
        {
            var orders = od.GetOrders();
            decimal orderTotal = 0;
            foreach(var pair in orders)
            {
                var promotion = PromotionsCatalog.Promotions.First(promotion => promotion.Product.Name.Equals(pair.Key));
                var product = ProductCatalog.Products.FirstOrDefault(product => product.Name.Equals(pair.Key));
                if (promotion != null && product != null)
                {
                    var promoTemp = pair.Value / promotion.Quantity;
                    var rem = pair.Value % promotion.Quantity;
                    orderTotal += promoTemp * promotion.Price + rem * product.Price;
                }
            }
            return orderTotal;
        }
    }
}
