using System;
using System.Linq;
using System.Text;

namespace HexAddition
{
    class Program
    {
        static void Main(string[] args)
        {
            string c = HexStringAddition("bc614e", "343efcea");
            Console.WriteLine(c);
        }

        public static int HexCharToInt(char hexChar)
        {
            int result;
            if
                (hexChar >= '0' && hexChar <= '9') result = hexChar - '0';
            else if
                (hexChar >= 'A' && hexChar <= 'F') result = hexChar - 'A' + 10;
            else if
                (hexChar >= 'a' && hexChar <= 'f') result = hexChar - 'a' + 10;
            else
                throw new ArgumentOutOfRangeException("hexChar");
            return result;
        }

        public static char IntToHexChar(int val)
        {
            char result;
            if
                (val >= 0 && val <= 9) result = (char)(val + 48);
            else if
                (val >= 10 && val <= 15) result = (char)(val + 87);
            else
                throw new ArgumentOutOfRangeException("val");
            return result;
        }

        public static (char, char) HexCharAddition(char hexA, char hexB, char hexRemainder = '0')
        {
            int sum = HexCharToInt(hexA) + HexCharToInt(hexB) + HexCharToInt(hexRemainder);
            char remainder = IntToHexChar(sum % 16);
            char value = IntToHexChar(sum / 16);
            return (value, remainder);
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
                var (a, b) = HexCharAddition(hex[hex.Length - i - 1], hex2[hex2.Length - i - 1], hexRemainder);
                result = result.Append(b);
                hexRemainder = a;
            }

            for (int i = minLength; i < hex.Length; i++)
            {
                var (a, b) = HexCharAddition(hex[hex.Length - i - 1], '0', hexRemainder);
                result = result.Append(b);
                hexRemainder = a;
            }

            for (int i = minLength; i < hex2.Length; i++)
            {
                var (a, b) = HexCharAddition(hex2[hex2.Length - i - 1], '0', hexRemainder);
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
