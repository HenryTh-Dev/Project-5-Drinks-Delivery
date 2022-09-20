using Drinks_Delivery.UI;

namespace Drinks_Delivery
{
    public class Program
    {
        static void Main(string[] args)
        {
            UserMainMenu loginMenu = new UserMainMenu();
            loginMenu.LoginOrCreate();
        }

    }
}
