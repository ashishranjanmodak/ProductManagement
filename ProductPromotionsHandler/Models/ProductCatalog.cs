using System.Xml;
using System.Collections.Generic;
using System.Text;
using System.IO;
using ProductPromotionsHandler.Contracts;

namespace ProductPromotionsHandler.Models
{
    public class ProductCatalog: IProductCatalog
    {
        public List<Product> Products { get; private set; }
        public ProductCatalog()
        {
            Products = new List<Product>();
            var xmlDoc = new XmlDocument();
            xmlDoc.Load(@"../../../../ProductPromotionsHandler/Configurations/ProductCatalog.xml");
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
