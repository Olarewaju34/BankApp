using BankApp.Entities;
namespace BankApp.Repo
{
    public interface ICustomerRepo
    {
        Customer GetById(int id);
        Customer GetByEmail(string email);
        List<Customer> GetAll();
        bool AccountNumExist(string accountnum);
        void WriteToFile(Customer customer);
        void RefreshFile();
    }
}