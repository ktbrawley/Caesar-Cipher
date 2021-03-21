using System;
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
            var choice = 0;
            var userInput = string.Empty;

            var encryptionService = new EncryptionService();

            do
            {
                Console.WriteLine("\nPlease select an action you'd like to perform: \n1) Encrypt a message \n2) Decrypt a message");
                userInput = Console.ReadLine();
                var successful = Int32.TryParse(userInput, out choice);
            }
            while (!(choice == 1 || choice == 2));

            Console.WriteLine("\nThank you!\nPlease enter your message:");
            var message = Console.ReadLine();
            while (String.IsNullOrEmpty(message.TrimStart().TrimEnd()))
            {
                var action = choice == 1 ? "encrypt" : "decrypt";
                Console.WriteLine($"Invalid input. Please enter the message you'd like to {action}.");
                message = Console.ReadLine();
            }

            var outputToFile = 0;

            do
            {
                Console.WriteLine("\nHow would you like display the result of your action: \n1) Output on screen \n2) Output to file");
                userInput = Console.ReadLine();
                var successful = Int32.TryParse(userInput, out outputToFile);
            }
            while (!(outputToFile == 1 || outputToFile == 2));

            switch (choice)
            {
                case 1:
                    message = encryptionService.EncryptMessage(message);
                    break;

                case 2:
                    message = encryptionService.DecryptMessage(message);
                    break;
            }

            GenerateMessage((OutputMethod)outputToFile, message);

            Console.WriteLine("\nWould you like to perform another action? (y/n)");
            tryAgain = (Console.ReadLine().Trim().ToLower() == "y");
        }

        private static string FormatMessage(string msg)
        {
            var chars = msg.ToCharArray();
            chars[0] = chars[0].ToString().ToUpper().ToCharArray()[0];
            return String.Join("", chars);
        }

        private static void GenerateMessage(OutputMethod method, string message)
        {
            var fileService = new FileService();

            switch (method)
            {
                case OutputMethod.Console:
                    Console.WriteLine($"\nYour message is: {FormatMessage(message)}");
                    break;

                case OutputMethod.File:
                    fileService.WriteContentsToFile(message);
                    break;
            }
        }
    }

    public enum OutputMethod
    {
        Console = 1,
        File = 2
    }
}