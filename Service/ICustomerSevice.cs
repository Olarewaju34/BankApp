using BankApp.Entities;

namespace BankApp.Service
{
    public interface ICustomerService
    {
        Customer Login(string email);
        void Create(CustomerDto request);
      
    }
}