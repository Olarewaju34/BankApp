using BankApp.Entities;
namespace BankApp.Repo
{
    public interface ICustomerRepo
    {
        Customer GetCustomer(string password);
        List<Customer> GetAll();
        
        void WriteToFile(Customer customer);
        void RefreshFile();
    }
}