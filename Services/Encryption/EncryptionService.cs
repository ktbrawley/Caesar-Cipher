using Caesar_Cipher.Services.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caesar_Cipher.Services.Encryption
{
    public class EncryptionService : IEncryptionService
    {
        private static char[] alphabet = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };

        private static char[] specialChars = new char[] { '?', '!', '^', '%', '*', '(', ')', '&', '$' };

        public string DecryptMessage(string msg)
        {
            var secretMsg = msg.ToCharArray();

            for (int i = 0; i < secretMsg.Length; i++)
            {
                var isUpperCase = IsUpperCase(secretMsg[i]);
                if (IsNotAlphaChar(secretMsg[i]))
                {
                    continue;
                }

                var newCharacterIndex = Array.IndexOf(alphabet, char.ToLower(secretMsg[i])) - 3;
                if (newCharacterIndex < 0)
                {
                    newCharacterIndex += alphabet.Length;
                }
                secretMsg[i] = isUpperCase ? char.ToUpper(alphabet[newCharacterIndex]) : alphabet[newCharacterIndex];
            }
            return String.Join("", secretMsg);
        }

        public string EncryptMessage(string msg)
        {
            var secretMsg = msg.ToCharArray();
            for (int i = 0; i < secretMsg.Length; i++)
            {
                var isUpperCase = IsUpperCase(secretMsg[i]);

                if (IsNotAlphaChar(secretMsg[i]))
                {
                    continue;
                }
                var newCharacterIndex = Array.IndexOf(alphabet, char.ToLower(secretMsg[i])) + 3;
                if (newCharacterIndex > (alphabet.Length - 1))
                {
                    newCharacterIndex -= alphabet.Length;
                }
                secretMsg[i] = isUpperCase ? char.ToUpper(alphabet[newCharacterIndex]) : alphabet[newCharacterIndex];
            }
            return String.Join("", secretMsg);
        }

        private bool IsNotAlphaChar(char secretMsgChar)
        {
            return !alphabet.Any(x => x.ToString().ToLower() == secretMsgChar.ToString().ToLower());
        }

        private bool IsUpperCase(char secretMsgChar)
        {
            return secretMsgChar == char.ToUpper(secretMsgChar);
        }
    }
}