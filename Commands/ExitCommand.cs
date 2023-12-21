namespace MovieApp.Commands;

public class ExitCommand : ICommand
{
    public void ExecuteCommand()
    {
        Console.WriteLine("Exiting...");
    }
}