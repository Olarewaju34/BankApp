using BankApp.Entities;
using BankApp.Enums;
using BankApp.Service;

namespace BankApp.Menus
{
    public class Menu
    {
        private static ICustomerService customerService;
        private static ITransactionService transactionService;
        private static CustomerDto customerDto;

        public Menu()
        {
            customerDto = new CustomerDto();
            customerService = new CustomerService();
            transactionService = new TransactionService();
        }
        public void MyMenu()
        {
            var flag = true;
            while (flag)
            {
                PrintMenu();
                Console.Write("Enter your option: ");
                string opt = Console.ReadLine();
                switch (opt)
                {
                    case "1":
                        Console.WriteLine("Enter your Email: ");
                        string email = Console.ReadLine();
                        Console.Write("Enter your password: ");
                        string password = Console.ReadLine();
                        var customer = customerService.Login(email);
                        if (customer == null)
                        {
                            Console.WriteLine("customer does not exist");
                        }
                        else
                        {
                            if (customer.Password == password)
                            {
                                CustomerMenu(customer);
                            }
                        }
                        break;
                    case "2":
                        customerService.Create(customerDto);
                        break;

                    case "0":
                        flag = false;
                        Console.WriteLine("Thank you for using our App...");
                        break;
                    default:
                        Console.WriteLine("Invalid input!");
                        break;
                }
            }
        }
        private static void CustomerMenu(Customer customer)
        {
            var flag = true;
            while (flag)
            {
                PrintCustomerMenu();
                Console.WriteLine("Enter Your option: ");
                string opt = Console.ReadLine();
                switch (opt)
                {
                    case "1":
                        transactionService.MakeDeposit(customer);
                        break;
                    case "2":
                        transactionService.MakeWithdrawal(customer);
                        break;
                    case "0":
                        flag = false;
                        break;
                    default:
                        Console.WriteLine("Invalid input!");
                        break;
                }
            }
        }
        private static void PrintMenu()
        {
            Console.WriteLine("Enter 1 to Login");
            Console.WriteLine("Enter 2 to create account");
            Console.WriteLine("Enter 0 to Exit");
        }
        private static void PrintCustomerMenu()
        {
            Console.WriteLine("Enter 1 to Deposit money: ");
            Console.WriteLine("Enter 2 to make withdrawal");

        }

    }
}