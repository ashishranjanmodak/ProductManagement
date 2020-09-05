using ProductPromotionsHandler.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductPromotionsHandler.Contracts
{
    public interface IPromotionsCatalog
    {
        List<Promotion> Promotions { get; }
        List<ComboPromotion> Combos { get; }
    }
}
