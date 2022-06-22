using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Web;
using System.Xml.Serialization;
using MimeTypes;
using SyncStream.Serializer.Converter;

// Define our namespace
namespace SyncStream.Serializer.Model;

/// <summary>
/// This class maintains the structure for a Data URI
/// </summary>
[JsonConverter(typeof(DataUriJsonConverter))]
public class DataUri
{
    /// <summary>
    /// This constant defines the pattern to match data URIs
    /// </summary>
    public const string Pattern =
        @"^(data:(?<mime>(.+?)))((;charset=(?<charset>(.+?)))|(;filename=(?<filename>(.+?)))){0,2};base64,(?<binary>(.+?))$";

    /// <summary>
    /// This property contains the binary of the file
    /// </summary>
    [JsonIgnore]
    [XmlIgnore]
    public byte[] Binary { get; set; }

    /// <summary>
    /// This property contains the filename if one was provided
    /// </summary>
    [JsonIgnore]
    [XmlIgnore]
    public string CharacterSet { get; set; }

    /// <summary>
    /// This property contains the filename if one was provided
    /// </summary>
    [JsonIgnore]
    [XmlIgnore]
    public string Filename { get; set; }

    /// <summary>
    /// This property contains the mime-type for the binary
    /// </summary>
    [JsonIgnore]
    [XmlIgnore]
    public string MimeType { get; set; }

    /// <summary>
    /// This method converts a file on the file system to a DataURI
    /// </summary>
    /// <param name="filePath"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public static DataUri FromFile(string filePath)
    {
        // Check the file for an absolute path and generate it
        if (!filePath[0].Equals(Path.DirectorySeparatorChar))
            filePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? String.Empty,
                filePath);

        // Load the file's information
        FileInfo fileInfo = new FileInfo(filePath);

        // Make sure the file exists
        if (!fileInfo.Exists) throw new Exception($"{filePath} does not exist");

        // We're done, return the new data-uri
        return new(File.ReadAllBytes(filePath), MimeTypeMap.GetMimeType(fileInfo.Extension), fileInfo.Name);
    }


    /// <summary>
    /// This method asynchronously reads the data URI from a file
    /// </summary>
    /// <param name="filePath"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public static async Task<DataUri> FromFileAsync(string filePath)
    {
        // Check the file for an absolute path and generate it
        if (!filePath[0].Equals(Path.DirectorySeparatorChar))
            filePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? String.Empty,
                filePath);

        // Load the file's information
        FileInfo fileInfo = new FileInfo(filePath);

        // Make sure the file exists
        if (!fileInfo.Exists) throw new Exception($"{filePath} does not exist");

        // We're done, return the new data-uri
        return new(await File.ReadAllBytesAsync(filePath), MimeTypeMap.GetMimeType(fileInfo.Extension), fileInfo.Name);
    }

    /// <summary>
    /// This method converts a file stream into a Data URI
    /// </summary>
    /// <param name="fileStream"></param>
    /// <param name="fileName"></param>
    /// <param name="contentType"></param>
    /// <returns></returns>
    public static DataUri FromStream(Stream fileStream, string fileName, string contentType)
    {
        // Localize the stream reader
        using StreamReader reader = new(fileStream);

        // We're done, return the new data URI
        return new(Encoding.UTF8.GetBytes(reader.ReadToEnd()), contentType, fileName,
            reader.CurrentEncoding.WebName);
    }

    /// <summary>
    /// This method asynchronously converts a file stream into a Data URI
    /// </summary>
    /// <param name="fileStream"></param>
    /// <param name="fileName"></param>
    /// <param name="contentType"></param>
    /// <returns></returns>
    public static async Task<DataUri> FromStreamAsync(Stream fileStream, string fileName, string contentType)
    {
        // Localize the stream reader
        using StreamReader reader = new(fileStream);

        // We're done, return the new data URI
        return new(Encoding.UTF8.GetBytes(await reader.ReadToEndAsync()), contentType, fileName,
            reader.CurrentEncoding.WebName);
    }

    /// <summary>
    /// This method parses a data URI into an instance
    /// </summary>
    /// <param name="dataUri"></param>
    /// <param name="instance"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public static DataUri Parse(string dataUri, DataUri instance = null)
    {
        // Define our regular expression
        Regex regex = new(Pattern, RegexOptions.IgnoreCase | RegexOptions.Multiline);
        
        // Make sure we have a valid data URI
        if (!regex.IsMatch(dataUri)) throw new System.Exception($"Invalid Data URI:\n\t{dataUri}");
        
        // Make sure we have an instance
        instance ??= new();
        
        // Localize the matches
        Match match = regex.Match(dataUri);
        
        // Set the binary into the instance
        instance.Binary = Convert.FromBase64String(match.Groups["binary"].Value);
        // Set the filename into the instance
        instance.Filename = match.Groups["filename"].Value;
        // Set the character set into the instance
        instance.CharacterSet = match.Groups["charset"].Value;
        // Set the mime-type into the instance
        instance.MimeType = match.Groups["mime"].Value;

        // We're done, return the instance
        return instance;
    }

    /// <summary>
    /// This method tries to parse a data URI
    /// </summary>
    /// <param name="dataUri"></param>
    /// <param name="output"></param>
    /// <returns></returns>
    public static bool TryParse(string dataUri, out DataUri output)
    {
        // Try to parse the data URI
        try
        {
            // Reset the output
            output = Parse(dataUri);
            // We're done
            return true;
        }
        catch (System.Exception)
        {
            // Reset the output
            output = null;
            // We're done
            return false;
        }
    }

    /// <summary>
    /// This operator provides implicit string conversion
    /// </summary>
    /// <param name="dataUri"></param>
    /// <returns></returns>
    public static implicit operator DataUri(string dataUri) =>
        new(dataUri);

    /// <summary>
    /// This method instantiates an empty data URI
    /// </summary>
    public DataUri()
    {
    }

    /// <summary>
    /// This method instantiates a populated Data URI
    /// </summary>
    /// <param name="binary"></param>
    /// <param name="mimeType"></param>
    /// <param name="filename"></param>
    /// <param name="characterSet"></param>
    public DataUri(byte[] binary, string mimeType, string filename = null, string characterSet = null)
    {
        // Set the binary into the instance
        Binary = binary;
        // Set the character set into the instance
        CharacterSet = characterSet;
        // Set the filename into the instance
        Filename = filename;
        // Set the mime-type into the instance
        MimeType = mimeType;
    }

    /// <summary>
    /// This metho instantiates a data URI from a string
    /// </summary>
    /// <param name="dataUri"></param>
    public DataUri(string dataUri) => Parse(dataUri, this);

    /// <summary>
    /// This method returns the binary in a Base64 encode string
    /// </summary>
    /// <returns></returns>
    public string ToBase64() =>
        Convert.ToBase64String(Binary);

    /// <summary>
    /// This method converts the data URI instance to a string
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        // Define our data URI string
        string dataUri = $"data:{MimeType}";

        // Check for a character set
        if (!string.IsNullOrEmpty(CharacterSet) && !string.IsNullOrWhiteSpace(CharacterSet))
            dataUri = $"{dataUri};charset={CharacterSet}";

        // Check for a file name
        if (!string.IsNullOrEmpty(Filename) && !string.IsNullOrWhiteSpace(Filename))
            dataUri = $"{dataUri};filename={HttpUtility.UrlEncode(Filename)}";

        // Finalize and return the data URI
        return $"{dataUri};base64,{ToBase64()}";
    }
}
