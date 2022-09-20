using Drinks_Delivery.Enums;
using Drinks_Delivery.Models;
using Drinks_Delivery.Repositories;
using System;

namespace Drinks_Delivery.UI
{
    public class AdminMenu
    {
        static ProductsRepository pRepo = new ProductsRepository();
        
        public void Menu()
        {
            bool chooseExit = false;

            while (!chooseExit)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("Welcome to Drinks Delivery ADMIN menu, please select a option below:\n\n1-Create Product\n2-Delete Product\n3-Products List\n4-Product Edit\n5-Logout");
                    int chooseMenu = int.Parse(Console.ReadLine());
                    eAdminMenu option = (eAdminMenu)chooseMenu;
                    switch (option)
                    {
                        case eAdminMenu.CreateProduct:
                            UICreateProduct();
                            break;
                        case eAdminMenu.DeleteProduct:
                            UIDeleteProduct();
                            break;
                        case eAdminMenu.ProdList:
                            UIProductList();
                        break;
                        case eAdminMenu.Edit:
                            UIProductEdit();
                            break;
                        case eAdminMenu.Logout:
                            chooseExit = true;
                            
                            break;

                    }
                }
                catch
                {
                    Menu();
                }
            }
            
        }

        public void UICreateProduct()
        {
            Console.Clear();
            Console.WriteLine("Enter product name:");
            string prodName = Console.ReadLine();
            Console.WriteLine("Enter product brand:");
            string prodBrand = Console.ReadLine();
            Console.WriteLine("enter product type:");
            string prodType = Console.ReadLine();
            Console.WriteLine("Enter product price:");
            int prodPrice = int.Parse(Console.ReadLine());
            var prod = pRepo.CreateProduct(prodBrand, prodName, prodPrice, prodType);
            if (prod == true)
            {
                Console.WriteLine("Product added\nPress ENTER to continue");
                Console.ReadLine();
                Menu();
            }
        }
        public void UIDeleteProduct()
        {
            Console.Clear();
            pRepo.ProductList();
            Console.WriteLine("Enter product ID:");
            int prodID = int.Parse(Console.ReadLine());
            pRepo.RemoveProduct(prodID);
            Console.WriteLine("Product removed\nPress ENTER to return");
            Console.ReadLine();
            Menu();
        }
        public void UIProductList()
        {
            Console.Clear();
            var list = pRepo.ProductList();
            Console.WriteLine("Products List:");
            Console.WriteLine("------------------------");
            foreach (Product prod in list)
            {
                Console.WriteLine($"Index ID: {prod.ID}");
                Console.WriteLine($"Name: {prod.Name}");
                Console.WriteLine($"Price: {prod.Price}");
                Console.WriteLine($"Brand: {prod.Brand}");
                Console.WriteLine($"Type: {prod.ProdType}");
                Console.WriteLine("------------------------");
            }
            Console.ReadLine();
        }
       public void UIProductEdit()
       {
            Console.Clear();
            UIProductList();
            Console.WriteLine("Product Edit Menu.");
            Console.WriteLine("Please enter the ID of the product:");
            int prodID = int.Parse(Console.ReadLine());
            bool prodExist = pRepo.ValidateProduct(prodID);

            if (prodExist == false)
            {
                Console.WriteLine("This product doesn't exist in our system.\nPress ENTER to return to menu.");
                Console.ReadLine();
                Menu();
            }

            Console.Clear();
            var info = pRepo.ProductReturn(prodID);
            Console.WriteLine($"You are editing: ");
            Console.WriteLine($"Name: {info.Name}\nType: {info.ProdType}\nPrice:{info.Price}\nBrand:{info.Brand}");
            Console.WriteLine("\nPlease select a option below:\n\n1-Name\n2-Type\n3-Price\n4-Brand\n5-Exit");
            int chooseMenu = int.Parse(Console.ReadLine());
            eProductEditMenu option = (eProductEditMenu)chooseMenu;
            switch (option)
            {
                case eProductEditMenu.Name:
                    UIUpdateName(prodID);
                    break;
                case eProductEditMenu.ProdType:
                    UIUpdateType(prodID);
                    break;
                case eProductEditMenu.Price:
                    UIUpdatePrice(prodID);
                    break;
                case eProductEditMenu.Brand:
                    UIUpdateBrand(prodID);
                    break;

            }
            

        }
        public void UIUpdateName(int prodID)
        {
            var info = pRepo.ProductReturn(prodID);
            Console.WriteLine($"Enter a new name to {info.Name}");
            string newName = Console.ReadLine();
            if (newName == null)
            {
                Console.WriteLine("No new name entered\nPress ENTER to return");
                Console.ReadLine();
                Menu();
                
            }
            bool renamed = pRepo.UpdateName(newName, prodID,info);
            if (renamed == true)
            {
                Console.WriteLine("Product renamed.\nPress ENTER to return to menu");
                Console.ReadLine();
                Menu();
            }
        }
        public void UIUpdateType(int prodID)
        {
            var info = pRepo.ProductReturn(prodID);
            Console.WriteLine($"\nEnter a new type to {info.Name}");
            string newType = Console.ReadLine();
            if (newType == null)
            {
                Console.WriteLine("No new type entered\nPress ENTER to return");
                Console.ReadLine();
                Menu();

            }
            bool retyped = pRepo.UpdateType(newType, prodID, info);
            if (retyped == true)
            {
                Console.WriteLine("Product type changed.\nPress ENTER to return to menu");
                Console.ReadLine();
                Menu();
            }
        }
        public void UIUpdatePrice(int prodID)
        {
            var info = pRepo.ProductReturn(prodID);
            Console.WriteLine($"\nEnter a new price to {info.Name}");
            float newPrice = float.Parse(Console.ReadLine());
            bool rePriced = pRepo.UpdatePrice(newPrice, prodID, info);
            if (rePriced == true)
            {
                Console.WriteLine("Product type changed.\nPress ENTER to return to menu");
                Console.ReadLine();
                Menu();
            }
        }
        public void UIUpdateBrand(int prodID)
        {
            var info = pRepo.ProductReturn(prodID);
            Console.WriteLine($"\nEnter a new price to {info.Name}");
            float newPrice = float.Parse(Console.ReadLine());
            bool rePriced = pRepo.UpdatePrice(newPrice, prodID, info);
            if (rePriced == true)
            {
                Console.WriteLine("Product type changed.\nPress ENTER to return to menu");
                Console.ReadLine();
                Menu();
            }
        }
        

    }
}

