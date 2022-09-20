using Drinks_Delivery.Models;
using System.Collections.Generic;

namespace Drinks_Delivery.Interface
{
    public interface IProductRepository
    {
        bool CreateProduct(string prodBrand, string prodName, int prodPrice, string prodType);
        void RemoveProduct(int prodID);
        List<Product> ProductList();
    }
}
