using System.ComponentModel.DataAnnotations.Schema;

namespace TeslaACDC.Data.Models;

public class Album : BaseEntity<int>
{
    public string Name { get; set; } = string.Empty;
    public int Year { get; set; } = int.MinValue;
    public Genre Genre { get; set; } = Genre.Unknown;

    [ForeignKey("Artist")]
    public int ArtistId { get; set; }
    public virtual Artist? Artist { get; set; }

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