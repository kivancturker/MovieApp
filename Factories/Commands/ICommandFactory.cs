using MovieApp.Commands;
using MovieApp.Repositories.Abstracts;

namespace MovieApp.Factories;

public interface ICommandFactory
{
    public ICommand CreateCommand(IMovieRepository movieRepository);
}