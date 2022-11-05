using BankApp.Entities;
using BankApp.Repo;
using BankApp.Constants;

namespace BankApp.Service
{
    public class TransactionService : ITransactionService
    {
        private readonly Transaction transaction;
        private readonly TransactionRepo transactionRepos;
        private readonly CustomerRepo customerRepo;
        public TransactionService()
        {
            transaction = new Transaction();
            customerRepo = new CustomerRepo();
            transactionRepos = new TransactionRepo();
        }

        public void MakeDeposit(Customer request)
        {
            var transactions = transactionRepos.GetTransactions();
            Console.Write("Enter Amount you want to deposit: ");
            decimal amount = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Enter your accountnumber: ");
            string accountnum = Console.ReadLine();
            DateTime date = DateTime.Now;
            var transaction = new Transaction
            {
                Amount = amount,
                Date = date
            };
            if (customerRepo.AccountNumExist(accountnum))
            {
                Console.WriteLine("Enter your pin: ");
                string pin = Console.ReadLine();
                while (request.Pin != pin)
                {
                    Console.WriteLine("Invalid pin!!!");
                    pin = Console.ReadLine();
                }
                request.AccountBalance += amount;
                transactions.Add(transaction);
                customerRepo.RefreshFile();
                Console.WriteLine($"You have deposited {amount} in your account");

            }
            else
            {
                Console.WriteLine("Acount does not exist!!!");
            }
        }

        public void MakeWithdrawal(Customer customer)
        {
            decimal Totalamount = 0;
            Console.WriteLine("Enter your account number: ");
            string accountnum = Console.ReadLine();

            while (customerRepo.AccountNumExist(accountnum))
            {
                Console.Write("How much do u want to withdraw: ");
                decimal amount = Convert.ToDecimal(Console.ReadLine());
                Console.Write("Enter your pin: ");
                string pin = Console.ReadLine();
                while (customer.Pin != pin)
                {
                    Console.WriteLine("Invalid pin!!");
                    pin = Console.ReadLine();
                }
                Totalamount += amount + transaction.Charges;
                if (Totalamount > customer.AccountBalance)
                {
                    Console.WriteLine("Insufficient funds!!");
                    break;
                }
                customer.AccountBalance -= Totalamount;
                customerRepo.RefreshFile();
                Console.WriteLine($"You have withdrawn {Totalamount} from your account and your balance is {customer.AccountBalance}");
                string opt = string.Empty;
                do
                {
                    Console.WriteLine("Do u wish to continue: (yes/no) ");
                    opt = Console.ReadLine().ToLower();
                } while (!(opt.Equals("yes")) && !opt.Equals("no"));
                if (opt == "no")
                {
                    break;
                }
            }

        }

    }
}