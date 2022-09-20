using Drinks_Delivery.Enums;
using Drinks_Delivery.Models;
using Drinks_Delivery.Repositories;
using System;

namespace Drinks_Delivery.UI
{
    public class ClientMenu
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
                    var CartList = pRepo.GetCartList();
                    Console.WriteLine("--------------------------");

                    
                        float subtotal = 0f;
                        
                        var index = 0;
                        Console.WriteLine("Order added items:");
                        foreach (PurchasedProductInfo prod in CartList)
                        {
                            Console.WriteLine($"Product ID:{prod.prodID}");
                            Console.WriteLine($"Name: {prod.prodName}");
                            Console.WriteLine($"Price: {prod.prodPrice}$");
                            Console.WriteLine($"Amount added: {prod.qntt}");
                        
                            Console.WriteLine("--------------------------");
                            var total = prod.prodPrice * prod.qntt;
                            index++;
                            if (index <= CartList.Count)
                            {
                                subtotal += total;

                            }
                        }
                        Console.WriteLine("Subtotal = " + subtotal + "$");

                    Console.WriteLine("Welcome to Drinks Delivery order menu, please select a option below:\n\n1-Products list\n2-Remove Product\n3-Finish Order\n4-Logout");
                    int chooseMenu = int.Parse(Console.ReadLine());
                    eClientMenu option = (eClientMenu)chooseMenu;
                    switch (option)
                    {
                        case eClientMenu.Order:
                            ProductsList();
                            break;
                        case eClientMenu.RemoveOrder:
                            RemoveOrder();
                            break;
                        case eClientMenu.FinishOrder:
                            UIFinishOrder();
                            break;
                        case eClientMenu.Exit:
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
        public void ProductsList()
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
            Console.WriteLine("Please select a option below:");
            Console.WriteLine("1-Add to the order\n2-Back");
            var chooseMenu = int.Parse(Console.ReadLine());
            if (chooseMenu == 1) 
            {
                ProductAdd();
            }else
            {
                Menu();
            }
            


        }
        public void  ProductAdd()
        {
            Console.WriteLine("Enter the product ID:");
            int prodID = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the amount:");
            int Qntt = int.Parse(Console.ReadLine());
            bool prodAdded = pRepo.AddToOrder(prodID, Qntt);

            if(prodAdded == true)
            {
                Console.WriteLine("Product Added\nPress ENTER to continue");
                Console.ReadLine();
            }
        }
        public void RemoveOrder()
        {
            Console.WriteLine("Please enter the ID");
            int prodID = int.Parse(Console.ReadLine());
            var removed = pRepo.removeOrder(prodID);
            if (removed == true)
            {
                Console.WriteLine("Product Removed\nPress ENTER to continue");
                Console.ReadLine();
            }
        }
        public void UIFinishOrder()
        {
            Console.WriteLine("Finish your order?(Y or N)");
            string finishedConfirm = Console.ReadLine();
            if (finishedConfirm == "y" || finishedConfirm == "Y")
            {
                pRepo.FinishOrder();
                Console.WriteLine("Order completed.\nPress ENTER to continue");
            }
            else
            {
                Menu();
            }
        }
    }
}
