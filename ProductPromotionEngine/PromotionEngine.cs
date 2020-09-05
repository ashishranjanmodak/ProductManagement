﻿using ProductPromotionEngine.Models;
using ProductPromotionsHandler.Contracts;
using ProductPromotionsHandler.Models;
using System;
using System.Collections.Generic;
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
                var promotion = PromotionsCatalog.Promotions.FirstOrDefault(promotion => promotion.Product.Name.Equals(pair.Key));
                var product = ProductCatalog.Products.FirstOrDefault(product => product.Name.Equals(pair.Key));
                var combo = PromotionsCatalog.Combos.Find(combo => combo.Product.Name.Contains(pair.Key));
                
                if (combo != null)
                {
                    var productNames = combo.Product.Name.Split(',');
                    Dictionary<string, int> prod = new Dictionary<string, int>();
                    foreach(var name in productNames)
                    {
                        prod.Add(name, orders[name]);
                    }
                    var minOrder = prod.Values.Min();
                    orderTotal += combo.Price * minOrder;
                    foreach(var item in prod)
                    {
                        var productForItem = ProductCatalog.Products.FirstOrDefault(prod => prod.Name.Equals(item.Key));
                        orderTotal += (item.Value - minOrder) * productForItem.Price;
                    }
                }
                else if (promotion != null && product != null)
                {
                    var promoTemp = pair.Value / promotion.Quantity;
                    var rem = pair.Value % promotion.Quantity;
                    orderTotal += promoTemp * promotion.Price + rem * product.Price;
                }
                else
                {
                    orderTotal += pair.Value * product.Price;
                }
            }
            return orderTotal;
        }
    }
}
