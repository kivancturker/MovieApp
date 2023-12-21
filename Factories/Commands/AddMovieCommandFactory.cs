using MovieApp.Commands;
using MovieApp.Repositories.Abstracts;

namespace MovieApp.Factories.Commands;

public class AddMovieCommandFactory : ICommandFactory
{
    public ICommand CreateCommand(IMovieRepository movieRepository)
    {
        return new AddMovieCommand(movieRepository);
    }
}