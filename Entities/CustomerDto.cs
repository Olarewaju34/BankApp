using BankApp.Enums;
namespace BankApp.Entities
{
    public class CustomerDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public Gender Gender { get; set; }
        public string Email { get; set; }
    

    }
}