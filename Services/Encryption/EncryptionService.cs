using Caesar_Cipher.Models;
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

        private readonly FileService _fileService;

        public EncryptionService()
        {
            _fileService = new FileService();
        }

        public bool DecryptMessage(EncryptionAction action)
        {
            var msg = RetrieveMessageForProcessing(action);
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

            OutputTransformedMessage(action, string.Join("", secretMsg));
            return true;
        }

        public bool EncryptMessage(EncryptionAction action)
        {
            var msg = RetrieveMessageForProcessing(action);
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
            OutputTransformedMessage(action, string.Join("", secretMsg));
            return true;
        }

        private string RetrieveMessageForProcessing(EncryptionAction encryptionAction)
        {
            var message = string.Empty;

            switch (encryptionAction.Method)
            {
                case ProcessingMethod.Console:
                    Console.WriteLine("\nThank you!\nPlease enter your message:");

                    message = Console.ReadLine();
                    while (String.IsNullOrEmpty(message.TrimStart().TrimEnd()))
                    {
                        var action = encryptionAction.Choice == 1 ? "encrypt" : "decrypt";
                        Console.WriteLine($"Invalid input. Please enter the message you'd like to {action}.");
                        message = Console.ReadLine();
                    }
                    break;

                case ProcessingMethod.File:
                    Console.WriteLine("Reading file contents...");
                    message = _fileService.ReadFileContents();
                    break;
            }

            return message;
        }

        private string OutputTransformedMessage(EncryptionAction encryptionAction, string message)
        {
            switch (encryptionAction.Method)
            {
                case ProcessingMethod.Console:
                    Console.WriteLine($"\nYour message is: {FormatMessage(message)}");
                    break;

                case ProcessingMethod.File:
                    Console.WriteLine("Writing transformed message to contents...");
                    _fileService.WriteContentsToFile(message);
                    break;
            }

            return message;
        }

        private bool IsNotAlphaChar(char secretMsgChar)
        {
            return !alphabet.Any(x => x.ToString().ToLower() == secretMsgChar.ToString().ToLower());
        }

        private bool IsUpperCase(char secretMsgChar)
        {
            return secretMsgChar == char.ToUpper(secretMsgChar);
        }

        private static string FormatMessage(string msg)
        {
            var chars = msg.ToCharArray();
            chars[0] = chars[0].ToString().ToUpper().ToCharArray()[0];
            return String.Join("", chars);
        }
    }
}