using System.Text.Json;
using System.Text.Json.Serialization;

// Define our namespace
namespace SyncStream.Serializer;

/// <summary>
/// This class maintains our JSON serialization capabilities
/// </summary>
public class JsonSerializer
{
    /// <summary>
    /// This property contains our JSON serializer settings
    /// </summary>
    public static readonly JsonSerializerOptions JsonSerializerSettings = new()
    {
        // We want to include null values
        DefaultIgnoreCondition = JsonIgnoreCondition.Never,
        // We want minified output
        WriteIndented = false
    };

    /// <summary>
    /// This method bootstraps our serializer settings
    /// </summary>
    static JsonSerializer()
    {
        // Add the JSON Enum converter
        JsonSerializerSettings?.Converters.Add(new JsonStringEnumConverter());
    }

    /// <summary>
    /// This method deserializes a JSON string into a dynamic object
    /// </summary>
    /// <param name="type"></param>
    /// <param name="json"></param>
    /// <returns></returns>
    public static object Deserialize(Type type, string json) =>
        System.Text.Json.JsonSerializer.Deserialize(json, type, JsonSerializerSettings);

    /// <summary>
    /// This method deserializes a JSON string into a type object
    /// </summary>
    /// <param name="json"></param>
    /// <typeparam name="TPayload"></typeparam>
    /// <returns></returns>
    public static TPayload Deserialize<TPayload>(string json) =>
        System.Text.Json.JsonSerializer.Deserialize<TPayload>(json, JsonSerializerSettings);

    /// <summary>
    /// This method serializes an object into JSON
    /// </summary>
    /// <param name="type"></param>
    /// <param name="payload"></param>
    /// <param name="pretty"></param>
    /// <returns></returns>
    public static string Serialize(Type type, object payload, bool pretty = false)
    {
        // Check the payload
        if (payload is null) return null;

        // Localize the serializer options
        JsonSerializerOptions options = new()
        {
            // We want to include null values
            DefaultIgnoreCondition = JsonIgnoreCondition.Never,
            // Set the maximum depth
            MaxDepth = int.MaxValue,
            // We want minified output
            WriteIndented = pretty
        };

        // We're done, serialize the object and return it
        return System.Text.Json.JsonSerializer.Serialize(payload, type, options);
    }

    /// <summary>
    /// This method serializes an object into JSON
    /// </summary>
    /// <param name="payload"></param>
    /// <param name="pretty"></param>
    /// <returns></returns>
    public static string Serialize(object payload, bool pretty = false)
    {
        // Ensure we have a payload
        if (payload is null) return null;

        // We're done, serialize the payload and return the JSON
        return Serialize(payload.GetType(), payload, pretty);
    }

    /// <summary>
    /// This method serializes a typed object into JSON
    /// </summary>
    /// <param name="payload"></param>
    /// <param name="pretty"></param>
    /// <typeparam name="TPayload"></typeparam>
    /// <returns></returns>
    public static string Serialize<TPayload>(TPayload payload, bool pretty = false) =>
        Serialize(typeof(TPayload), payload, pretty);

    /// <summary>
    /// This method serializes an object into JSON with formatting forced to on
    /// </summary>
    /// <param name="type"></param>
    /// <param name="payload"></param>
    /// <returns></returns>
    public static string SerializePretty(Type type, object payload) =>
        Serialize(type, payload, true);

    /// <summary>
    /// This method serializes an object into JSON with formatting forced to on
    /// </summary>
    /// <param name="payload"></param>
    /// <returns></returns>
    public static string SerializePretty(object payload)
    {
        // Ensure we have a payload
        if (payload is null) return null;

        // We're done, serialize the object to JSON
        return SerializePretty(payload.GetType(), payload);
    }

    /// <summary>
    /// This method serializes a typed object into JSON with formatting forced to on
    /// </summary>
    /// <param name="payload"></param>
    /// <typeparam name="TPayload"></typeparam>
    /// <returns></returns>
    public static string SerializePretty<TPayload>(TPayload payload) =>
        SerializePretty(typeof(TPayload), payload);
}
