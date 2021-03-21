using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caesar_Cipher
{
    public static class Utils
    {
        public static bool IsNotAlphaChar(char[] alphabet, char secretMsgChar)
        {
            return !alphabet.Any(x => x.ToString().ToLower() == secretMsgChar.ToString().ToLower());
        }

        public static bool IsUpperCase(char secretMsgChar)
        {
            return secretMsgChar == char.ToUpper(secretMsgChar);
        }

        public static string FormatMessage(string msg)
        {
            var chars = msg.ToCharArray();
            chars[0] = chars[0].ToString().ToUpper().ToCharArray()[0];
            return String.Join("", chars);
        }
    }
}