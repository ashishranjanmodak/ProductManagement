using System;
using ProductPromotionEngine;
using ProductPromotionEngine.Models;

namespace ProductManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Your Order");
            var order = new OrderDetails();
            var promotionEngine = new PromotionEngine();
            bool i = true;
            do
            {
                Console.Write("Enter Product Name: ");
                var name = Console.ReadLine();
                Console.Write("Enter Product Quantity: ");
                var quantity = int.Parse(Console.ReadLine());
                order.AddOrders(name, quantity);
                Console.WriteLine("Do you want to add another product?");
                Console.WriteLine("Enter 'Y' for Yes or 'N' for No");
                var response = Console.ReadLine();
                i = response == "Y" || response == "y";
            } while (i);
            var cost = promotionEngine.CalculateCost(order);
            Console.Write("Total: {0}", cost);
            Console.ReadKey();
        }
    }
}
