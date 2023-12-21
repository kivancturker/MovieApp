using System.Text;
using MovieApp.Commands;
using MovieApp.Factories;
using MovieApp.Factories.Commands;
using MovieApp.Repositories.Abstracts;

namespace MovieApp;

public class CommandLineView
{
    private Dictionary<int, string> _options;
    private readonly IMovieRepository _movieRepository;
    public CommandLineView(IMovieRepository movieRepository)
    {
        _movieRepository = movieRepository;
        _options = GetCommandLineOptions();
    }

    private Dictionary<int, string> GetCommandLineOptions()
    {
        var options = new Dictionary<int, string>();
        options.Add((int) CommandLineSelection.Exit, "Exit");
        options.Add((int)CommandLineSelection.AddMovie, "Add Movie");
        options.Add((int)CommandLineSelection.ListMovies, "List Movies");
        return options;
    }

    public void Start()
    {
        bool isTerminated = false;
        while (!isTerminated)
        {
            ShowOptions();
            CommandLineSelection selection = SelectOption();
            if (selection is CommandLineSelection.Exit)
                isTerminated = true;
            ICommandFactory commandFactory = GetCommandFactory(selection);
            ICommand command = commandFactory.CreateCommand(_movieRepository);
            command.ExecuteCommand();
        }
    }
    
    private void ShowOptions()
    {
        Console.WriteLine("These are the options");
        foreach (KeyValuePair<int, string> option in _options)
        {
            Console.WriteLine(FullOptionMessage(option.Key, option.Value));
        }
    }

    private string FullOptionMessage(int optionNumber, string optionMessage)
    {
        return String.Format("{0}. {1}", optionNumber, optionMessage);
    }

    private CommandLineSelection SelectOption()
    {
        int selected = Int32.Parse(Console.ReadLine());
        return (CommandLineSelection)Enum.ToObject(typeof(CommandLineSelection), selected);
    }

    private ICommandFactory GetCommandFactory(CommandLineSelection selection)
    {
        switch (selection)
        {
            case CommandLineSelection.Exit:
                return new ExitCommandFactory();
            case CommandLineSelection.AddMovie:
                return new AddMovieCommandFactory();
            case CommandLineSelection.ListMovies:
                return new ListMovieCommandFactory();
        }
        return new InvalidCommandFactory();
    }
}