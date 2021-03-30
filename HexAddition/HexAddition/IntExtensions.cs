using System;

namespace HexAddition
{
    public static class IntExtensions
    {
        public static char IntToHexChar(this int val)
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
    }
}
