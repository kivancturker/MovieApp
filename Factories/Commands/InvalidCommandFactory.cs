using MovieApp.Commands;
using MovieApp.Repositories.Abstracts;

namespace MovieApp.Factories;

public class InvalidCommandFactory : ICommandFactory
{
    public ICommand CreateCommand(IMovieRepository movieRepository)
    {
        return new InvalidCommand();
    }
}