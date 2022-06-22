using System.Text.Json;
using System.Text.Json.Serialization;
using SyncStream.Serializer.Model;


// Define our namespace
namespace SyncStream.Serializer.Converter;

/// <summary>
/// This class maintains the JSON converter structures for reading and writing JSON data URIs
/// </summary>
public class DataUriJsonConverter : JsonConverter<DataUri>
{
    /// <summary>
    /// This method reads the DataURI value from a JSON string
    /// </summary>
    /// <param name="reader"></param>
    /// <param name="typeToConvert"></param>
    /// <param name="options"></param>
    /// <returns></returns>
    public override DataUri Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) =>
        DataUri.Parse(reader.GetString());

    /// <summary>
    /// This method writes a DataURI value to a JSON string
    /// </summary>
    /// <param name="writer"></param>
    /// <param name="value"></param>
    /// <param name="options"></param>
    public override void Write(Utf8JsonWriter writer, DataUri value, JsonSerializerOptions options) =>
        writer.WriteStringValue(value?.ToString());
}
