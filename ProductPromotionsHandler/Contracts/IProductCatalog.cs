using ProductPromotionsHandler.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductPromotionsHandler.Contracts
{
    public interface IProductCatalog
    {
        List<Product> Products { get; }
    }
}
