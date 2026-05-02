using System.Text.Json.Serialization;
using Flickr.Net.Bases;
using Flickr.Net.Internals.Attributes;
using Flickr.Net.Internals.JsonConverters;

namespace Flickr.Net;

/// <summary>
/// </summary>
[FlickrJsonPropertyName("photo")]
public record Photo : UltraDeluxePhotoBase
{
    /// <summary>
    /// </summary>
    [JsonPropertyName("datetaken")]
    [JsonConverter(typeof(DateTimeGranularityConverter))]
    public DateTime DateTaken { get; set; }
}