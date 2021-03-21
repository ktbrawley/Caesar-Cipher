using System;
using Caesar_Cipher.Models;
using Caesar_Cipher.Services.Encryption;
using Caesar_Cipher.Services.IO;

namespace Caesar_Cipher
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("===================================================");
            Console.WriteLine("===================CAESAR-CRYPT====================");
            Console.WriteLine("===================================================\n");

            try
            {
                var tryAgain = true;
                do
                {
                    StartProgram(out tryAgain);
                    Console.WriteLine("\n===================================================");
                }
                while (tryAgain);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Invalid input: {ex.Message}");
            }
            return;
        }

        private static void StartProgram(out bool tryAgain)
        {
            var encryptionService = new EncryptionService();

            var userInput = ConfirmUserAction();

            switch (userInput.Choice)
            {
                case TransformMethod.Encrypt:
                    encryptionService.EncryptMessage(userInput);
                    break;

                case TransformMethod.Decrypt:
                    encryptionService.DecryptMessage(userInput);
                    break;
            }

            Console.WriteLine("\nWould you like to perform another action? (y/n)");
            tryAgain = (Console.ReadLine().Trim().ToLower() == "y");
        }

        private static EncryptionAction ConfirmUserAction()
        {
            var choice = 0;
            var outputMethod = 0;
            var userInput = string.Empty;

            do
            {
                Console.WriteLine("\nPlease select an action you'd like to perform: \n1) Encrypt a message \n2) Decrypt a message");
                userInput = Console.ReadLine();
                var successful = Int32.TryParse(userInput, out choice);
            }
            while (!(choice == 1 || choice == 2));

            do
            {
                Console.WriteLine("\nWould you like to perform chosen action: \n1) In the console \n2) In a text file");
                userInput = Console.ReadLine();
                var successful = Int32.TryParse(userInput, out outputMethod);
            }
            while (!(outputMethod == 1 || outputMethod == 2));

            return new EncryptionAction { Choice = (TransformMethod)choice, Method = (ProcessingMethod)outputMethod };
        }
    }

    public enum ProcessingMethod
    {
        Console = 1,
        File = 2
    }

    public enum TransformMethod
    {
        Encrypt = 1,
        Decrypt = 2
    }
}