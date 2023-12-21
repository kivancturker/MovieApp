using MovieApp.Entities;
using MovieApp.Repositories.Abstracts;

namespace MovieApp.Commands;

public class ListMovieCommand :ICommand
{
    private readonly IMovieRepository _movieRepository;
    public ListMovieCommand(IMovieRepository movieRepository)
    {
        _movieRepository = movieRepository;
    }
    public void ExecuteCommand()
    {
        var movies = _movieRepository.GetAll();
        Console.WriteLine("Here are the list of movies");
        foreach (var movie in movies)
        {
            Console.WriteLine(movie);
        }
    }
}