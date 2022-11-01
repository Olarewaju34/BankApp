using BankApp.Entities;

namespace BankApp.Service
{
    public interface ICustomerService
    {
        Customer Login(string password);
        void Create(CustomerDto request);
        void MakeDeposit(Customer transaction);
        void MakeWithdrawal(Transaction money);
        bool AccountNumExist(string accountnum);
    }
}