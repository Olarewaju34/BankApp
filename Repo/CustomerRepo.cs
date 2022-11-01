using BankApp.Entities;
using BankApp.Constants;


namespace BankApp.Repo
{
    public class CustomerRepo : ICustomerRepo
    {

        public static List<Customer> Customers;
        public CustomerRepo()
        {
            Customers = new List<Customer>();
            ReadFromFile();
        }

        public Customer GetCustomer(string email, string password)
        {
            return Customers.Find(i => i.Email == email && i.Password == password);
        }

        public List<Customer> GetAll()
        {
            return Customers;
        }


        public void WriteToFile(Customer customer)
        {
            try
            {
                using (StreamWriter write = new StreamWriter(Constants.Constants.fullPath, true))
                {
                    write.WriteLine(customer.ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void RefreshFile()
        {
            try
            {
                using (StreamWriter write = new StreamWriter(Constants.Constants.fullPath))
                {
                    foreach (var a in Customers)
                    {
                        write.WriteLine(a.ToString());
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }



        private void ReadFromFile()
        {
            try
            {
                if (File.Exists(Constants.Constants.fullPath))
                {
                    var lines = File.ReadAllLines(Constants.Constants.fullPath);

                    foreach (var line in lines)
                    {
                        var customer = Customer.ToCustomer(line);
                        Customers.Add(customer);
                    }
                }
                else
                {

                    using (File.Create(Constants.Constants.fullPath))
                    {
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


    }
}
