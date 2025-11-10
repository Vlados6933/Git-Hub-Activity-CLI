using Services;
using System.Text.Json;
using Task_tracker.Services;

namespace GitHubActivityCLI
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                PrintBanner();
                Console.WriteLine("Welcome! Type 'github-activity <username>' to see information about the user's recent activity.\n");
                string userName = InputValidationService.Validate(Console.ReadLine());
                if (!string.IsNullOrEmpty(userName))
                    await PrintUserActivity.PrintActivity(userName);
                Console.Write("Press any key to continue...");
                Console.ReadKey();
            }
        }
        static void PrintBanner()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╔══════════════════════╗");
            Console.WriteLine("║   Git Hub Activity   ║");
            Console.WriteLine("╚══════════════════════╝\n");
        }
    }
}
