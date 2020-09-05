using ProductPromotionsHandler.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace ProductPromotionsHandler.Models
{
    public class PromotionsCatalog: IPromotionsCatalog
    {
        public List<Promotion> Promotions { get; }
        public List<ComboPromotion> Combos { get; }

        public PromotionsCatalog()
        {
            Promotions = new List<Promotion>();
            Combos = new List<ComboPromotion>();
            var xmlDoc = new XmlDocument();
            xmlDoc.Load(@"../../../../ProductPromotionsHandler/Configurations/PromotionsCatalog.xml");
            ExtractPromotions(xmlDoc);
            ExtractCombos(xmlDoc);
        }

        private void ExtractPromotions(XmlDocument xmlDoc)
        {
            var nodeList = xmlDoc.SelectNodes("/PROMOTIONSCATALOG/PROMOTIONS/PROMOTION");
            foreach (XmlNode node in nodeList)
            {
                Promotion promo = new Promotion();
                Product product = new Product();
                var productNode = node.FirstChild;
                product.Name = productNode.Attributes["name"].Value;
                promo.Product = product;
                promo.Quantity = int.Parse(node.Attributes["quantity"].Value);
                promo.Price = decimal.Parse(node.Attributes["price"].Value);
                Promotions.Add(promo);
            }
        }
        private void ExtractCombos(XmlDocument xmlDoc)
        {
            var nodeList = xmlDoc.SelectNodes("/PROMOTIONSCATALOG/COMBOS/COMBO");
            foreach (XmlNode node in nodeList)
            {
                ComboPromotion promo = new ComboPromotion();
                Product product = new Product();
                var productNode = node.FirstChild;
                product.Name = productNode.Attributes["name"].Value;
                promo.Product = product;
                promo.Quantity = int.Parse(node.Attributes["quantity"].Value);
                promo.Price = decimal.Parse(node.Attributes["price"].Value);
                Combos.Add(promo);
            }
        }
    }
}
