using MovieApp.Entities;
using MovieApp.Repositories.Abstracts;

namespace MovieApp.Repositories.Concretes;

public class InMemoryMovieRepository : IMovieRepository
{
    private List<Movie> _movies;
    private string _fileName = Constants.MovieFileName;
    private FilePersistence<Movie> _filePersistence;

    public InMemoryMovieRepository()
    {
        _filePersistence = new FilePersistence<Movie>(_fileName);
        _movies = _filePersistence.ReadFromFile() ?? new List<Movie>();
    }
    public void Add(Movie movie)
    {
        _movies.Add(movie);
        _filePersistence.WriteToFile(_movies);
    }

    public List<Movie> GetAll()
    {
        return _movies;
    }
}