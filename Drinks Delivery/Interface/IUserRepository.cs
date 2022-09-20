namespace Drinks_Delivery.Interface
{

    public interface IUserRepository
    {
        bool CreateAccount(string newEmail, string password, string fullName, string ssn, string birthdate, string address);
        int LoginAccount(string typedEmail, string password);
       
    }
}
