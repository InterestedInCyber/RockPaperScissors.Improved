namespace RockPaperScissors.Improved;

internal abstract class Program
{
    private static void Main()
    {
        Console.Clear();
        var details = new Details(Console.ReadLine!, Console.Write, Console.WriteLine);
        
        details.AskForChoice();
    }
}