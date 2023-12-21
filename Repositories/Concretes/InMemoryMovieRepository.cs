using System.Xml.Serialization;
using MovieApp.Entities;
using MovieApp.Repositories.Abstracts;

namespace MovieApp.Repositories.Concretes;

public class InMemoryMovieRepository : IMovieRepository
{
    private List<Movie> _movies;
    private string _fileName = Constants.MovieFileName;
    private XmlSerializer _serializer;

    public InMemoryMovieRepository()
    {
        _movies = Init();
        _serializer = new XmlSerializer(typeof(Movie));
    }
    public void Add(Movie movie)
    {
        _movies.Add(movie);
        Save();
    }

    public List<Movie> GetAll()
    {
        return _movies;
    }

    private List<Movie> Init()
    {
        if (!File.Exists(_fileName))
            return new List<Movie>();
        StreamReader sr = new StreamReader(_fileName);
        using (sr)
        {
            return (List<Movie>) _serializer.Deserialize(sr);
        }
    }

    private void Save()
    {
        StreamWriter sw = File.Exists(_fileName) ? new StreamWriter(_fileName) : File.CreateText(_fileName);
        using (sw)
        {
            _serializer.Serialize(sw, _movies);
        }
    }
}