using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankApp.Shared
{
    public class Helper
    {
        public static string CreateAccNum()
        {
            Random random = new Random();
            return $"21{random.Next(1000, 99999)}";
        }

        public static int SelectEnum(string screenMessage, int validStart, int validEnd)
        {
            int outValue;
            do
            {
                Console.Write(screenMessage);
            } while (!(int.TryParse(Console.ReadLine(), out outValue) && IsValid(outValue, validStart, validEnd)));

            return outValue;
        }

        public static bool IsValid(int outValue, int start, int end)
        {
            return outValue >= start && outValue <= end;
        }
    }
}