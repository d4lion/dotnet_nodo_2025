using System.ComponentModel.DataAnnotations.Schema;

namespace TeslaACDC.Data.Models;

public class Artist : BaseEntity<int>
{
    public string Name { get; set; } = string.Empty;
    public string Label { get; set; } = string.Empty;
    public bool IsOnTour { get; set; } = false;
}
