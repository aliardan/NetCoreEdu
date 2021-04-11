using System;

namespace BetterHexAddition
{
    class Program
    {
        static void Main(string[] args)
        {
            var first = "bc614e";
            var second = "343efcea";

            var result = Sum(first, second);

            Console.WriteLine(result);
        }

        public static string Sum(string hex1, string hex2)
        {
            var map = new[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'c', 'd', 'e', 'f' };

            var hex1Array = hex1.ToCharArray();
            Array.Reverse(hex1Array);
            var hex2Array = hex2.ToCharArray();
            Array.Reverse(hex2Array);

            var maxLength = Math.Max(hex1.Length, hex2.Length);
            var sum = new char[maxLength + 1];

            var wholePart = 0;

            for (var i = 0; i < maxLength; i++)
            {
                var decimal1 = i > hex1Array.Length - 1 ? 0 : Array.IndexOf(map, hex1Array[i]);
                var decimal2 = i > hex2Array.Length - 1 ? 0 : Array.IndexOf(map, hex2Array[i]);
                var sumPosition = decimal1 + decimal2 + wholePart;
                var remainder = sumPosition % 16;
                wholePart = sumPosition / 16;
                sum[i] = map[remainder];
            }

            sum[^1] = wholePart > 0 ? map[wholePart] : '0';

            Array.Reverse(sum);

            return new string(sum);
        }
    }
}
