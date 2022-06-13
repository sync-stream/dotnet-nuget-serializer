using System.Text;
using System.Xml;
using System.Xml.Serialization;

// Define our namespace
namespace SyncStream.Serializer;

/// <summary>
/// This class provides XML serialization
/// </summary>
public class XmlSerializer
{
    /// <summary>
    /// This method deserializes an XML response
    /// </summary>
    /// <param name="type"></param>
    /// <param name="xml"></param>
    /// <param name="encoding"></param>
    /// <returns></returns>
    public static object Deserialize(Type type, string xml, Encoding encoding = null)
    {
        // Check for XML
        if (string.IsNullOrEmpty(xml) || string.IsNullOrWhiteSpace(xml)) return null;

        // Define our XML writer settings
        XmlReaderSettings xmlReaderSettings = new()
        {
            // Close the stream when we're done
            CloseInput = true,
            // Define our DTD processing
            DtdProcessing = DtdProcessing.Ignore,
            // Ignore comments
            IgnoreComments = true,
            // Ignore extraneous whitespace
            IgnoreWhitespace = true
        };

        // Localize our scope and instantiate our string reader
        using StringReader stringReader = new(xml);

        // Define our serializer
        System.Xml.Serialization.XmlSerializer xmlSerializer = new(type);

        // Define our reader
        using XmlReader reader = XmlReader.Create(stringReader, xmlReaderSettings);

        // We're done, deserialize the XML and return the object
        return xmlSerializer.Deserialize(reader);
    }

    /// <summary>
    /// This method deserializes a JSON XML response
    /// </summary>
    /// <typeparam name="TPayload"></typeparam>
    /// <param name="xml"></param>
    /// <param name="encoding"></param>
    /// <returns></returns>
    public static TPayload Deserialize<TPayload>(string xml, Encoding encoding = null)
        where TPayload : class, new() =>
        (TPayload)Deserialize(typeof(TPayload), xml, encoding);

    /// <summary>
    /// This method serializes the payload into XML for transmission
    /// </summary>
    /// <param name="type"></param>
    /// <param name="payload"></param>
    /// <param name="encoding"></param>
    /// <param name="pretty"></param>
    /// <returns></returns>
    public static string Serialize(Type type, object payload, Encoding encoding = null, bool pretty = true)
    {
        // Ensure we have a payload
        if (payload is null) return null;

        // Define our XML namespaces
        XmlSerializerNamespaces xmlNamespaces = new();
        // Add our default namespace
        xmlNamespaces.Add("", "");
        // Define our XML serializer
        System.Xml.Serialization.XmlSerializer xmlSerializer = new(type);
        // Define our XML builder
        StringBuilder xmlBuilder = new();
        // Define our XML writer settings
        XmlWriterSettings xmlWriterSettings = new()
        {
            // Close the stream when we're done
            CloseOutput = true,
            // We want to use UTF-8 encoding
            Encoding = encoding ?? Encoding.UTF8,
            // We want to format the XML output
            Indent = pretty,
            // Define our indentation character
            IndentChars = "    ",
            // Define our newline character
            NewLineChars = "\n",
            // We want a new line for attributes
            NewLineOnAttributes = true,
            // We want to include the XML declaration
            OmitXmlDeclaration = false,
            // Write closing tags when the stream closes
            WriteEndDocumentOnClose = true
        };

        // Localize our scope and create our writer
        using XmlWriter xmlWriter = XmlWriter.Create(xmlBuilder, xmlWriterSettings);

        // Serialize the XML
        xmlSerializer.Serialize(xmlWriter, payload, xmlNamespaces);
        // We're done with the writer
        xmlWriter.Close();

        // We're done, return the XML payload
        return xmlBuilder.ToString();
    }

    /// <summary>
    /// This method serializes the payload into XML for transmission
    /// </summary>
    /// <param name="payload"></param>
    /// <param name="encoding"></param>
    /// <param name="pretty"></param>
    /// <returns></returns>
    public static string Serialize(object payload, Encoding encoding = null, bool pretty = false) =>
        Serialize(payload?.GetType() ?? typeof(object), payload, encoding, pretty);

    /// <summary>
    /// This method serializes the payload into XML for transmission
    /// </summary>
    /// <param name="payload"></param>
    /// <param name="encoding"></param>
    /// <param name="pretty"></param>
    /// <typeparam name="TPayload"></typeparam>
    /// <returns></returns>
    public static string Serialize<TPayload>(TPayload payload, Encoding encoding = null, bool pretty = false) =>
        Serialize(typeof(TPayload), payload, encoding, pretty);

    /// <summary>
    /// This method serializes the payload into XML for transmission with formatting forced to on
    /// </summary>
    /// <param name="type"></param>
    /// <param name="payload"></param>
    /// <param name="encoding"></param>
    /// <returns></returns>
    public static string SerializePretty(Type type, dynamic payload, Encoding encoding = null) =>
        Serialize(type, payload, encoding, true);

    /// <summary>
    /// This method serializes the payload into XML for transmission with formatting forced to on
    /// </summary>
    /// <param name="payload"></param>
    /// <param name="encoding"></param>
    /// <returns></returns>
    public static string SerializePretty(dynamic payload, Encoding encoding = null) =>
        SerializePretty(payload?.GetType() ?? typeof(object), payload, encoding);

    /// <summary>
    /// This method serializes the payload into XML for transmission with formatting forced to on
    /// </summary>
    /// <param name="payload"></param>
    /// <param name="encoding"></param>
    /// <typeparam name="TPayload"></typeparam>
    /// <returns></returns>
    public static string SerializePretty<TPayload>(TPayload payload, Encoding encoding = null) =>
        SerializePretty(typeof(TPayload), payload, encoding);
}
