using BankApp.Entities;
namespace BankApp.Repo
{
    public class TransactionRepo : ITransactionRepo
    {

        public static List<Transaction> AllTransaction;
        public TransactionRepo()
        {
            AllTransaction = new List<Transaction>();
        }
        public List<Transaction> GetTransactions()
        {
            return AllTransaction;
        }
    }
}