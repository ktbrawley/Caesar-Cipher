﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caesar_Cipher.Services
{
    public class EncryptionService : IEncryptionService
    {
        private static char[] alphabet = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };

        private static char[] specialChars = new char[] { '?', '!', '^', '%', '*', '(', ')', '&', '$' };

        public string DecryptMessage(string msg)
        {
            var secretMsg = msg.ToLower().ToCharArray();

            for (int i = 0; i < secretMsg.Length; i++)
            {
                if (IsNotAlphaChar(secretMsg[i]))
                {
                    continue;
                }

                var newCharacterIndex = Array.IndexOf(alphabet, secretMsg[i]) - 3;
                if (newCharacterIndex < 0)
                {
                    newCharacterIndex += alphabet.Length;
                }
                secretMsg[i] = alphabet[newCharacterIndex];
            }
            return String.Join("", secretMsg);
        }

        public string EncryptMessage(string msg)
        {
            var secretMsg = msg.ToLower().ToCharArray();
            for (int i = 0; i < secretMsg.Length; i++)
            {
                if (IsNotAlphaChar(secretMsg[i]))
                {
                    continue;
                }
                var newCharacterIndex = Array.IndexOf(alphabet, secretMsg[i]) + 3;
                if (newCharacterIndex > (alphabet.Length - 1))
                {
                    newCharacterIndex -= alphabet.Length;
                }
                secretMsg[i] = alphabet[newCharacterIndex];
            }
            return String.Join("", secretMsg);
        }

        private bool IsNotAlphaChar(char secretMsgChar)
        {
            return !alphabet.Any(x => x.ToString().ToLower() == secretMsgChar.ToString().ToLower());
        }
    }
}