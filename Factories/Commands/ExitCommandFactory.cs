using MovieApp.Commands;
using MovieApp.Repositories.Abstracts;

namespace MovieApp.Factories;

public class ExitCommandFactory :  ICommandFactory
{
    public ICommand CreateCommand(IMovieRepository movieRepository)
    {
        return new ExitCommand();
    }
}