using System.Globalization;
using System.Reflection.Metadata.Ecma335;
using MovieApp.Entities;
using MovieApp.Repositories.Abstracts;

namespace MovieApp.Commands;

public class AddMovieCommand : ICommand
{
    private readonly IMovieRepository _movieRepository;
    public AddMovieCommand(IMovieRepository movieRepository)
    {
        _movieRepository = movieRepository;
    }
    
    public void ExecuteCommand()
    {
        string dateFormat = "dd-MM-yyyy";
        // Ask for Movie Information { Name, Director, Release Date DD-MM-YYYY }
        Console.Write("Movie Name: ");
        string? name = Console.ReadLine();
        Console.Write("Director: ");
        string? director = Console.ReadLine();
        Console.Write("Release Year ({0}): ", dateFormat);
        string? releaseYearFormatted = Console.ReadLine();

        DateTime releaseDate;
        try
        {
            releaseDate = DateTime.ParseExact(releaseYearFormatted, dateFormat, CultureInfo.InvariantCulture);
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid Format For Date Please Follow this format: {0}", dateFormat);
            return;
        }

        Movie movie = new Movie
        {
            Name = name,
            Director = director,
            ReleaseDate = releaseDate
        };
        
        _movieRepository.Add(movie);
    }
}