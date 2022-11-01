using BankApp.Entities;
namespace BankApp.Repo
{
    public interface ITransactionRepo
    {
        List<Transaction> GetTransactions();
    }
}