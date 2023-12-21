namespace MovieApp.Commands;

public class InvalidCommand : ICommand
{
    public void ExecuteCommand()
    {
        Console.WriteLine("Invalid Command");
    }
}