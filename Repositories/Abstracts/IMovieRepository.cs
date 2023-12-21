using System.Net.Sockets;
using MovieApp.Entities;

namespace MovieApp.Repositories.Abstracts;

public interface IMovieRepository
{
    void Add(Movie movie);
    List<Movie> GetAll();
}