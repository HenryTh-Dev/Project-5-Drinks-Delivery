using Drinks_Delivery.Enums;
using Drinks_Delivery.Repositories;
using System;

namespace Drinks_Delivery.UI
{

    public class UserMainMenu
    {

        static UserRepository uRepo = new UserRepository();
        
        public void LoginOrCreate()
        {
            bool chooseExit = false;

            while (!chooseExit)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("Welcome to Drinks Delivery, please select a option below:\n\n1-Login\n2-Create Account\n3-Exit");
                    int chooseMenu = int.Parse(Console.ReadLine());
                    eUserMainMenu option = (eUserMainMenu)chooseMenu;
                    switch (option)
                    {
                        case eUserMainMenu.Login:
                            UILoginAccount();
                            break;
                        case eUserMainMenu.CreateAccount:
                            UICreateAccount();
                            break;
                        case eUserMainMenu.Exit:
                            chooseExit = true;
                            break;

                    }
                } catch
                {
                    LoginOrCreate();
                }
            }
        }



        public void UICreateAccount()
        {

            Console.Clear();
            Console.WriteLine("Enter your email:");
            string newEmail = Console.ReadLine();

            var emailExists = uRepo.ValidateEmail(newEmail);

            if (emailExists == true)
            {
                Console.WriteLine("Email already registered\nPress ENTER to try again");
                Console.ReadLine();
                LoginOrCreate();
            }

            Console.WriteLine("Create a password:");
            string password = Console.ReadLine();
            Console.WriteLine("Confirm your password");
            string confirmPassword = Console.ReadLine();

            if (confirmPassword != password)
            {
                Console.Clear();
                Console.WriteLine("Passwords doesn't match\nPress enter to try again");
                Console.ReadLine();
                LoginOrCreate();
            }

            Console.WriteLine("Enter your full name:");
            string fullName = Console.ReadLine();
            Console.WriteLine("Enter your SNN:");
            string ssn = Console.ReadLine();
            Console.WriteLine("Enter your birthdate DD/MM/YYYY (no special characters):");
            string birthdate = Console.ReadLine();
            Console.WriteLine("Enter your address:");
            string address = Console.ReadLine();

            var created = uRepo.CreateAccount(newEmail, password, fullName, ssn, birthdate, address);
            if (created == true)
            {
                Console.WriteLine("Account Created!");

                Console.ReadLine();
                LoginOrCreate();
            }


        }
        public void UILoginAccount()
        {
            Console.Clear();
            Console.WriteLine("Enter your email");
            string typedEmail = Console.ReadLine();
            Console.WriteLine("Enter your password");
            string typedPass = Console.ReadLine();
            var logon = uRepo.LoginAccount(typedEmail, typedPass);

            if (logon == 1)
            {
                AdminMenu adm = new AdminMenu();
                Console.WriteLine("Admin login successfully!\nPress ENTER to continue");
                Console.ReadLine();
                adm.Menu();

            } else if (logon == 2)
            {
                Console.WriteLine("Email not registred.\nPress ENTER to try again");
                Console.ReadLine();
                LoginOrCreate();
            }
            else if (logon == 3)
            {
                Console.WriteLine("Invalid password\n Press ENTER to try again");
                Console.ReadLine();
                LoginOrCreate();
            } else if (logon == 4)
            {
                ClientMenu Cli = new ClientMenu();
                Console.WriteLine("Successfully logged in\nPress enter to try again");
                Console.ReadLine();
                Cli.Menu();
            }
        }


    }
}
