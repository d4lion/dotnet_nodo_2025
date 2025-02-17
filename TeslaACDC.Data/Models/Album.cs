namespace TeslaACDC.Data.Models;

public class Album : BaseEntity<int>
{
    public string Name { get; set; } = string.Empty;
    public string Year { get; set; } = string.Empty;
    public Genre Genre { get; set; } = Genre.Unknown;
    public Artist Artist { get; set; } = new Artist();
}

public enum Genre
{
    Pop,
    Rock,
    Metal,
    Jazz,
    Blues,
    Reggae,
    HipHop,
    Rap,
    Country,
    Electronic,
    Unknown
}