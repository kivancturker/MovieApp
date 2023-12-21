using MovieApp.Commands;
using MovieApp.Repositories.Abstracts;

namespace MovieApp.Factories;

public class ListMovieCommandFactory : ICommandFactory
{
    public ICommand CreateCommand(IMovieRepository movieRepository)
    {
        return new ListMovieCommand(movieRepository);
    }
}