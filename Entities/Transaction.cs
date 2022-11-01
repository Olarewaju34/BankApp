
namespace BankApp.Entities
{
    public class Transaction
    {
        public decimal Amount { get; set; }
        public decimal Charges { get { return 200; } }
        public DateTime Date { get; set; }


        public override string ToString()
        {
            return $"{Amount}\t{Charges}\t{Date}";
        }
    }

}