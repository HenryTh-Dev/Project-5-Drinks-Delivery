using Drinks_Delivery.Interface;
using Drinks_Delivery.Models;
using System.Collections.Generic;

namespace Drinks_Delivery.Repositories
{
    public class ProductsRepository : IProductRepository
    {
        static List<Product> Products = new List<Product>();
        static List<PurchasedProductInfo> Cart = new List<PurchasedProductInfo>();
        static List<PurchasedProductInfo> AdminCart = new List<PurchasedProductInfo>();

        public bool CreateProduct(string prodBrand, string prodName, int prodPrice, string prodType)
        {
            Product product = new Product() {Price = prodPrice, Brand = prodBrand, Name = prodName, ProdType = prodType, ID = Products.Count};
            Products.Add(product);
            
            return true;
        }
        public List<Product> ProductList()
        {
            return Products;
        }
        public void RemoveProduct(int prodID)
        {
            Products.RemoveAt(prodID);
           
        }
        public bool ValidateProduct(int prodID)
        {
            var itExists = Products.Find(c => c.ID == prodID);
            if (itExists == null)
            {
                return false;
            }
            return true;
        }
        public Product ProductReturn(int prodID)
        {
            return Products[prodID];
        }
        public bool UpdateName(string newName, int prodID, Product info)
        {
            
            var product = Products.Find(x => x.ID == prodID);
            product.Name = newName;
            return true;
        }
        public bool UpdateType(string newType, int prodID, Product info)
        {
            var product = Products.Find(x => x.ID == prodID);
            product.ProdType = newType;
            return true;
        }
        public bool UpdatePrice(float newPrice, int prodID, Product info)
        {
            var product = Products.Find(x => x.ID == prodID);
            product.Price = newPrice;

            return true;
        }
        public bool UpdateBrand(string newBrand, int prodID, Product info)
        {
            var product = Products.Find(x => x.ID == prodID);
            product.Brand = newBrand;
            return true;
        }
        public bool AddToOrder(int prodID, int qntt)
        {
            PurchasedProductInfo prodP = new PurchasedProductInfo();
            var prod = Products.Find(x => x.ID == prodID);
            prodP.prodName = prod.Name;
            prodP.qntt = qntt;
            prodP.prodPrice = prod.Price;
            prodP.prodID = Cart.Count;
            prodP.pay = "Unpayed";
            Cart.Add(prodP);
            return true;
        }
        public List<PurchasedProductInfo> GetCartList()
        {
            return Cart;
        }
        public bool removeOrder(int prodID)
        {
            Cart.RemoveAt(prodID);
            return true;
        }
        public void FinishOrder()
        {
            foreach (PurchasedProductInfo prod in Cart)
            {
                
                PurchasedProductInfo transfer = new PurchasedProductInfo();
                transfer.prodPrice = prod.prodPrice;
                transfer.prodID = prod.prodID;
                transfer.prodName = prod.prodName;
                transfer.qntt = prod.qntt;
                transfer.pay = "Payed";
                AdminCart.Add(transfer);
                Cart.Clear();
            }
        }

    }
}
