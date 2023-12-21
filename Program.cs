
using MovieApp.Repositories.Abstracts;
using MovieApp.Repositories.Concretes;

namespace MovieApp;

class Program
{
    static void Main(string[] args)
    {
        // Dependency Injection
        IMovieRepository movieRepository = new InMemoryMovieRepository();
        
        CommandLineView cmdView = new CommandLineView(movieRepository);
        cmdView.Start();
    }
}