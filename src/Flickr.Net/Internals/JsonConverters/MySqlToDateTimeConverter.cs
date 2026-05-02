using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Flickr.Net.Internals.JsonConverters;

/// <summary>
/// </summary>
public class MySqlToDateTimeConverter : JsonConverter<DateTime>
{
    /// <summary>
    /// </summary>
    public static MySqlToDateTimeConverter Instance { get; } = new();

    /// <summary>
    /// </summary>
    public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var value = reader.GetString();
        return DateTime.TryParseExact(value, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture,
            DateTimeStyles.AssumeLocal, out var result) ? result : DateTime.MinValue;
    }

    /// <summary>
    /// </summary>
    public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
    {
        var content = value.ToString("yyyy-MM-dd HH:mm:ss");
        writer.WriteRawValue(content);
    }
}