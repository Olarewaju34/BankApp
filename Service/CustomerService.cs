using BankApp.Entities;
using BankApp.Enums;
using BankApp.Repo;
using BankApp.Shared;
using BankApp.Constants;
namespace BankApp.Service
{
    public class CustomerService : ICustomerService
    {
        public static TransactionRepo transactionRepos;
        public static CustomerRepo customerRepo;
        public static Transaction transaction;
        public CustomerService()
        {
            transactionRepos = new TransactionRepo();
            customerRepo = new CustomerRepo();
            transaction = new Transaction();
        }

        public bool AccountNumExist(string accountnum)
        {
            var customers = customerRepo.GetAll();
            foreach (var customer in customers)
            {
                if (customer.AccountNum == accountnum)
                {
                    return true;
                }
            }
            return false;
        }

        public void Create(CustomerDto request)
        {
            var customers = customerRepo.GetAll();
            Console.WriteLine("Enter Your Date Of Birth (MM/dd/yyyy) format: ");
            DateTime dob = DateTime.Parse(Console.ReadLine());
            Console.Write("Enter your FirstName: ");
            request.FirstName = Console.ReadLine();
            Console.Write("Enter your LastName: ");
            request.LastName = Console.ReadLine();
            Console.Write("Enter your Phone number: ");
            request.Phone = Console.ReadLine();
            int gender = Helper.SelectEnum("Enter 1 for male\n2 for female\n3 for others", 1, 3);
            request.Gender = (Gender)gender;
            Console.Write("Enter your Email: ");
            request.Email = Console.ReadLine();
            while (!(request.Email.Contains("@")))
            {
                Console.WriteLine("Email Must have an @ sign");
                request.Email = Console.ReadLine();
            }
            Console.Write("Enter your password: ");
            string password = Console.ReadLine();
            
            Console.Write("Enter your 4 unique pin: ");
            string pin = Console.ReadLine();
            while (pin.Length < 4 || pin.Length > 4)
            {
                Console.Write("Pin cannot be more or less than 4 digits!!");
                pin = Console.ReadLine();
            }
            string accountnum = Helper.CreateAccNum();
            Console.WriteLine("Enter Amount u want to deposit: ");
            decimal amount = Convert.ToDecimal(Console.ReadLine());
            while (amount < 1000)
            {
                Console.WriteLine("You cannot deposit less than  a thousand");
                amount = Convert.ToDecimal(Console.ReadLine());
            }

            var customer = new Customer
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Phone = request.Phone,
                AccountNum = accountnum,
                Pin = pin,
                Gender = request.Gender,
                Password = password,
                Email = request.Email,
                AccountBalance = amount,
                Date = dob,
            };
            var findcustomer = customerRepo.GetCustomer(request.Email,password);
            if (findcustomer == null)
            {
                customers.Add(customer);
                customerRepo.WriteToFile(customer);
                Console.WriteLine("You have created an account with " + accountnum);
            }
            else
            {
                Console.WriteLine("Email already exist!!!!");
            }

        }

        public Customer Login(string email,string password)
        {
            var customer = customerRepo.GetCustomer(email,password);
            if (customer != null)
            {
                return customer;
            }
            return null;
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
            if (AccountNumExist(accountnum))
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

            while (AccountNumExist(accountnum))
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