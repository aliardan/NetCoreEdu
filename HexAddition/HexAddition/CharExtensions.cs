using System;

namespace HexAddition
{
    public static class CharExtensions
    {
        public static int HexCharToInt(this char hexChar)
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

        public static (char, char) HexCharAddition(this char hexA, char hexB, char hexRemainder = '0')
        {
            int sum = hexA.HexCharToInt() + hexB.HexCharToInt() + hexRemainder.HexCharToInt();
            char remainder = (sum % 16).IntToHexChar();
            char value = (sum / 16).IntToHexChar();
            return (value, remainder);
        }
    }
}
