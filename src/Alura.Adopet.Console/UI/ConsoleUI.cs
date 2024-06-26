using Project.Adopet.Console.Comandos;
using Project.Adopet.Console.Results;
using FluentResults;

namespace Project.Adopet.Console.UI
{
    internal static class ConsoleUI
    {
        public static void displayResult(Result result)
        {
            System.Console.ForegroundColor = ConsoleColor.Green;
            try
            {
                if (result.IsFailed)
                {
                    displayFailure(result);
                }
                else
                {
                    displaySuccess(result);
                }
            }   
            finally
            {
                System.Console.ForegroundColor = ConsoleColor.White;
            }

        }

        private static void displaySuccess(Result result)
        {
            var sucesso = result.Successes.First();
            switch (sucesso)
            {
                case SuccessWithPets s:
                    displayPets(s);
                    break;
                case SuccessWithDocs d:
                    displayDocs(d);
                    break;
                case SuccessWithClients c:
                    displayClients(c);
                    break;
            }
        }

        private static void displayClients(SuccessWithClients clients)
        {
            foreach (var client in clients.Data)
            {
                System.Console.WriteLine(client);
            }
            System.Console.WriteLine(clients.Message);
        }

        private static void displayDocs(SuccessWithDocs docCommand)
        {
            System.Console.WriteLine($"#############    Adopet (1.0)    #############");
            //System.Console.WriteLine($"");
            foreach (var doc in docCommand.Documentation)
            {
                System.Console.WriteLine(doc);
            }
        }

        private static void displayPets(SuccessWithPets success)
        {
            foreach (var pet in success.Data)
            {
                System.Console.WriteLine(pet);
            }
            System.Console.WriteLine(success.Message);
        }

        private static void displayFailure(Result result)
        {
            System.Console.ForegroundColor = ConsoleColor.Red;
            var error = result.Errors.First();
            System.Console.WriteLine($"An exception happened: {error.Message}");
        }
    }
}
