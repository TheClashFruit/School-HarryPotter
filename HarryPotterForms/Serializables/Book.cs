using System.Text.Json.Serialization;

namespace HarryPotterForms.Serializables;

public class Book {
    [JsonPropertyName("originalTitle")]
    public string OriginalTitle { get; set; } = string.Empty;
 
    [JsonPropertyName("pages")]
    public int Pages { get; set; }
 
    [JsonPropertyName("releaseDate")]
    public string ReleaseDate { get; set; } = string.Empty;
 
    [JsonPropertyName("description")]
    public string Description { get; set; } = string.Empty;
 
    [JsonPropertyName("cover")]
    public string Cover { get; set; } = string.Empty;
}