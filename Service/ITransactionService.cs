using BankApp.Entities;

namespace BankApp.Service
{
    public interface ITransactionService
    {
        void MakeDeposit(Customer transaction);
        void MakeWithdrawal(Customer customer);
    }
}