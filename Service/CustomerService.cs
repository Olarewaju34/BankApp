using BankApp.Entities;
using BankApp.Enums;
using BankApp.Repo;
using BankApp.Shared;
using BankApp.Constants;
namespace BankApp.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly CustomerRepo customerRepo;

        public CustomerService()
        {
            customerRepo = new CustomerRepo();
        }
        public void  Create(CustomerDto request)
        {
            var customers = customerRepo.GetAll();
            int id = (customers.Count != 0) ? customers[customers.Count - 1].Id + 1 : 1;
            Console.WriteLine("Enter Your Date Of Birth (MM/dd/yyyy) format: ");
            DateTime dob = DateTime.Parse(Console.ReadLine());
            Console.Write("Enter your FirstName: ");
            request.FirstName = Console.ReadLine();
            Console.Write("Enter your LastName: ");
            request.LastName = Console.ReadLine();
            Console.Write("Enter your Phone number: ");
            request.Phone = Console.ReadLine();
            int gender = Helper.SelectEnum("Enter 1 for male\n2 for female\n3 for others: ", 1, 3);
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
                Id = id,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Phone = request.Phone,
                AccountNum = accountnum,
                Pin = pin,
                Gender = request.Gender,
                Password = password,
                Email = request.Email,
                AccountBalance = amount,
                DateOfBirth = dob,
            };
            var findcustomer = customerRepo.GetById(id);
            if (findcustomer == null)
            {
                customers.Add(customer);
                customerRepo.WriteToFile(customer);
                Console.WriteLine("You have created an account with " + accountnum);
            }
            else
            {
                Console.WriteLine("Customer already exist!!!!");
            }

        }

        public Customer Login(string email)
        {
            var customer = customerRepo.GetByEmail(email);
            if (customer != null)
            {
                return customer;
            }
            return null;
        }

 
    }
}