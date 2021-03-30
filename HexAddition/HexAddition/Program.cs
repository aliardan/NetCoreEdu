using System;
using System.Linq;
using System.Text;

namespace HexAddition
{
    class Program
    {
        static void Main(string[] args)
        {
            string result = HexStringAddition("bc614e", "343efcea");
            Console.WriteLine($"Sum of hexadecimal numbers = {result}");
        }

        public static string HexStringAddition(string hex, string hex2)
        {
            if (string.IsNullOrEmpty(hex))
                throw new ArgumentException(nameof(hex));

            if (string.IsNullOrEmpty(hex2))
                throw new ArgumentException(nameof(hex2));

            int minLength = Math.Min(hex.Length, hex2.Length);

            StringBuilder result = new StringBuilder();
            char hexRemainder = '0';

            for (int i = 0; i < minLength; i++)
            {                
                var (a, b) = (hex[hex.Length - i - 1]).HexCharAddition(hex2[hex2.Length - i - 1], hexRemainder);
                result = result.Append(b);
                hexRemainder = a;
            }

            for (int i = minLength; i < hex.Length; i++)
            {
                var (a, b) = hex[hex.Length - i - 1].HexCharAddition('0', hexRemainder);
                result = result.Append(b);
                hexRemainder = a;
            }

            for (int i = minLength; i < hex2.Length; i++)
            {
                var (a, b) = hex2[hex2.Length - i - 1].HexCharAddition('0', hexRemainder);
                result = result.Append(b);
                hexRemainder = a;
            }

            if (hexRemainder != '0')
            {
                result = result.Append(hexRemainder);
            }

            return new string(result.ToString().ToCharArray().Reverse().ToArray());
        }
    }
}
