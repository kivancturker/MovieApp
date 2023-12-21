namespace MovieApp.Entities;
[Serializable]
public class Movie
{
    public string? Name { get; set; }
    public string? Director { get; set; }
    public DateTime? ReleaseDate { get; set; }

    public override string ToString()
    {
        return String.Format("Movie Name: {0} - Director: {1} - Release Date: {2}", Name, Director, ReleaseDate);
    }
}