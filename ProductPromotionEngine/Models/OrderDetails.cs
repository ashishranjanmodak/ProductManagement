﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ProductPromotionEngine.Models
{
    public class OrderDetails
    {
        Dictionary<string, int> Orders;
        public OrderDetails()
        {
            Orders = new Dictionary<string, int>();
        }

        public void AddOrders(string productName, int quantity)
        {
            Orders.Add(productName, quantity);
        }

        public Dictionary<string, int> GetOrders()
        {
            return Orders;
        }
    }
}
