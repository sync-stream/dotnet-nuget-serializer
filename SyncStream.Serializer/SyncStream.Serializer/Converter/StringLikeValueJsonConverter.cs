using System.Text.Json;
using System.Text.Json.Serialization;
using SyncStream.Serializer.Model;

// Define our namespace
namespace SyncStream.Serializer.Converter;

/// <summary>
/// This class maintains our custom JSON converter for string-like values
/// </summary>
public class StringLikeValueJsonConverter : JsonConverter<StringLikeValue>
{
    /// <summary>
    /// This method reads the string-like value from JSON
    /// </summary>
    /// <param name="reader">The reference instance of the JSON reader</param>
    /// <param name="typeToConvert">The type to be converted</param>
    /// <param name="options">The JSON serializer options</param>
    /// <returns>The deserialized typed value</returns>
    public override StringLikeValue
        Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) => reader.GetString();

    /// <summary>
    /// This method writes an string-like value to a JSON string
    /// </summary>
    /// <param name="writer">The JSON writer</param>
    /// <param name="value">The typed value to serialize</param>
    /// <param name="options">The JSON serializer options</param>
    public override void Write(Utf8JsonWriter writer, StringLikeValue value, JsonSerializerOptions options) =>
        writer.WriteStringValue(value?.ToString());
}
