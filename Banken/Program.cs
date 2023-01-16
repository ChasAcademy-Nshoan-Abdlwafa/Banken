namespace file_io;

class Program
{
    static void Main(string[] args)
    {
        /*string input = "";
        try
        {
            input = File.ReadAllText(@"accounts.txt");
        }
        catch
        {
            Console.WriteLine("No file found...");
        }*/

        Console.WriteLine("Välkommen till banken!");
        bool mainMenu = true;
        while (mainMenu)
        {
            Console.WriteLine("Var vänlig och ange följande användaruppgifter: ");
            Console.WriteLine("Användarnamn: ");
            Console.ReadLine();
            Console.WriteLine("Pin-kod: ");
            Console.ReadLine();
            string? choice = Console.ReadLine().ToUpper();
            switch (choice)
            {
                case "1":
                    break;
            }
        }
    }
}