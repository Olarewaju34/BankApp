using BankApp.Enums;
namespace BankApp.Entities
{
    public class Customer : baseEntities
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public decimal AccountBalance { get; set; }
        public string AccountNum { get; set; }
        public string Pin { get; set; }
        public Gender Gender { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public override string ToString()
        {
            return $"{FirstName}\t{LastName}\t{Phone}\t{AccountBalance}\t{AccountNum}\t{Pin}\t{Gender}\t{Email}\t{Password}\t{DateOfBirth}";
        }
        public static Customer ToCustomer(string str)
        {
            var type = str.Split("\t");
            var customer = new Customer
            {
                FirstName = type[0],
                LastName = type[1],
                Phone = type[2],
                AccountBalance = decimal.Parse(type[3]),
                AccountNum = type[4],
                Pin = type[5],
                Gender = Enum.Parse<Gender>(type[6]),
                Email = type[7],
                Password =type[8],
                DateOfBirth = DateTime.Parse(type[9])

            };
            return  customer;
        }
    }
}