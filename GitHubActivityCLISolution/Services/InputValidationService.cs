using Services;
using System.Globalization;

namespace Task_tracker.Services
{
    public class InputValidationService
    {
        public static string Validate(string userInput)
        {
            if (!string.IsNullOrWhiteSpace(userInput) && !userInput.Contains('~'))
            {
                if (!userInput.StartsWith("github-activity "))
                {
                    Console.WriteLine("Request must be started with 'github-activity'\n");
                    return string.Empty;
                }

                string lineWithUserName = userInput.Substring(15).Trim();
                if (string.IsNullOrWhiteSpace(lineWithUserName))
                {
                    Console.WriteLine("Bad request, example of correct input 'github-activity <username>'\n");
                    return string.Empty;
                }

                return lineWithUserName;
            }

            Console.WriteLine("Bad request, example of correct input 'github-activity <username>'\n");
            return string.Empty;
        }
    }
}
