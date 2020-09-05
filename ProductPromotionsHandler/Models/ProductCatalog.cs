﻿using System.Xml;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ProductPromotionsHandler.Models
{
    class ProductCatalog
    {
        public List<Product> Products;
        public ProductCatalog()
        {
            var xmlDoc = new XmlDocument();
            xmlDoc.Load(@"../Configurations/ProductCatalog.xml");
            ExtractProducts(xmlDoc);
        }

        private void ExtractProducts(XmlDocument xmlDoc)
        {
            var nodeList = xmlDoc.SelectNodes("/PRODUCTS/PRODUCT");
            foreach (XmlNode node in nodeList)
            {
                Product product = new Product();
                product.Name = node.Attributes["name"].Value;
                product.Price = decimal.Parse(node.Attributes["price"].Value);
                Products.Add(product);
            }
        }
    }
}