using DbUp;
using System.Reflection;

namespace WeatherChecker.Database
{
    //This program is able to create a copy of the database.
    class Program
    {
        static void Main()
        {
            var connectionString = "Server=localhost;Database=weatherdb;Trusted_Connection=True;";

            EnsureDatabase.For.SqlDatabase(connectionString);

            var upgrader = DeployChanges.To
                .SqlDatabase(connectionString)
                .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
                .LogToConsole().Build();

            var result = upgrader.PerformUpgrade();

            if (!result.Successful)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(result.Error);
                Console.ResetColor();
                return;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("DB Updated Success");
            Console.ResetColor();
        }
    }
}