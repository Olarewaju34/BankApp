using BankApp.Entities;

namespace BankApp.Service
{
    public interface ICustomerService
    {
        Customer Login(string email,string password);
        void Create(CustomerDto request);
        void MakeDeposit(Customer transaction);
        void MakeWithdrawal(Customer customer);
        bool AccountNumExist(string accountnum);
    }
}