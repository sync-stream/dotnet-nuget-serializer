using System.Globalization;
using System.Text.Json.Serialization;
using System.Xml.Serialization;
using SyncStream.Serializer.Converter;

// Define our namespace
namespace SyncStream.Serializer.Model;

/// <summary>
/// This class maintain the model structure of our string-like value
/// </summary>
[JsonConverter(typeof(StringLikeValueJsonConverter))]
[XmlRoot("string")]
public class StringLikeValue
{
    /// <summary>
    /// This property contains the actual string value
    /// </summary>
    protected string Value;

    /// <summary>
    /// This property contains the serializable data for XML
    /// </summary>
    [JsonIgnore]
    [XmlText]
    public string ValueString
    {
        get => Value;
        set => Value = value;
    }

    /// <summary>
    /// This method implicitly converts a <code>string</code>
    /// </summary>
    /// <param name="value">The value to convert</param>
    /// <returns>A new <code>StringLikeValue</code> instance</returns>
    public static implicit operator StringLikeValue(string value) => new(value);

    /// <summary>
    /// This method implicitly converts a <code>bool</code>
    /// </summary>
    /// <param name="value">The value to convert</param>
    /// <returns>A new <code>StringLikeValue</code> instance</returns>
    public static implicit operator StringLikeValue(bool value) => new(value.ToString().ToLower());

    /// <summary>
    /// This method implicitly converts a <code>bool?</code>
    /// </summary>
    /// <param name="value">The value to convert</param>
    /// <returns>A new <code>StringLikeValue</code> instance</returns>
    public static implicit operator StringLikeValue(bool? value) => new(value?.ToString().ToLower());

    /// <summary>
    /// This method implicitly converts a <code>decimal</code>
    /// </summary>
    /// <param name="value">The value to convert</param>
    /// <returns>A new <code>StringLikeValue</code> instance</returns>
    public static implicit operator StringLikeValue(decimal value) => new(value);

    /// <summary>
    /// This method implicitly converts a <code>decimal?</code>
    /// </summary>
    /// <param name="value">The value to convert</param>
    /// <returns>A new <code>StringLikeValue</code> instance</returns>
    public static implicit operator StringLikeValue(decimal? value) => new(value);

    /// <summary>
    /// This method implicitly converts a <code>double</code>
    /// </summary>
    /// <param name="value">The value to convert</param>
    /// <returns>A new <code>StringLikeValue</code> instance</returns>
    public static implicit operator StringLikeValue(double value) => new(value);

    /// <summary>
    /// This method implicitly converts a <code>double?</code>
    /// </summary>
    /// <param name="value">The value to convert</param>
    /// <returns>A new <code>StringLikeValue</code> instance</returns>
    public static implicit operator StringLikeValue(double? value) => new(value);

    /// <summary>
    /// This method implicitly converts a <code>float</code>
    /// </summary>
    /// <param name="value">The value to convert</param>
    /// <returns>A new <code>StringLikeValue</code> instance</returns>
    public static implicit operator StringLikeValue(float value) => new(value);

    /// <summary>
    /// This method implicitly converts a <code>float?</code>
    /// </summary>
    /// <param name="value">The value to convert</param>
    /// <returns>A new <code>StringLikeValue</code> instance</returns>
    public static implicit operator StringLikeValue(float? value) => new(value);

    /// <summary>
    /// This method implicitly converts a <code>int</code>
    /// </summary>
    /// <param name="value">The value to convert</param>
    /// <returns>A new <code>StringLikeValue</code> instance</returns>
    public static implicit operator StringLikeValue(int value) => new(value);

    /// <summary>
    /// This method implicitly converts a <code>int?</code>
    /// </summary>
    /// <param name="value">The value to convert</param>
    /// <returns>A new <code>StringLikeValue</code> instance</returns>
    public static implicit operator StringLikeValue(int? value) => new(value);

    /// <summary>
    /// This method implicitly converts a <code>long</code>
    /// </summary>
    /// <param name="value">The value to convert</param>
    /// <returns>A new <code>StringLikeValue</code> instance</returns>
    public static implicit operator StringLikeValue(long value) => new(value);

    /// <summary>
    /// This method implicitly converts a <code>long?</code>
    /// </summary>
    /// <param name="value">The value to convert</param>
    /// <returns>A new <code>StringLikeValue</code> instance</returns>
    public static implicit operator StringLikeValue(long? value) => new(value);

    /// <summary>
    /// This method implicitly converts a <code>DateTime</code>
    /// </summary>
    /// <param name="value">The value to convert</param>
    /// <returns>A new <code>StringLikeValue</code> instance</returns>
    public static implicit operator StringLikeValue(DateTime value) => new(value);

    /// <summary>
    /// This method implicitly converts a <code>DateTime?</code>
    /// </summary>
    /// <param name="value">The value to convert</param>
    /// <returns>A new <code>StringLikeValue</code> instance</returns>
    public static implicit operator StringLikeValue(DateTime? value) => new(value);

    /// <summary>
    /// This method implicitly converts a <code>Enum</code>
    /// </summary>
    /// <param name="value">The value to convert</param>
    /// <returns>A new <code>StringLikeValue</code> instance</returns>
    public static implicit operator StringLikeValue(Enum value) => new(value);

    /// <summary>
    /// This method instantiates an empty string-like value
    /// </summary>
    public StringLikeValue()
    {
    }

    /// <summary>
    /// This method instantiates a string-like value from <code>string</code> <paramref name="value" />
    /// </summary>
    /// <param name="value">The value to convert</param>
    public StringLikeValue(string value)
    {
        // Set the value into the instance
        Value = value;
    }

    /// <summary>
    /// This method instantiates a string-like value from <code>DateTime</code> <paramref name="value" />
    /// </summary>
    /// <param name="value">The value to convert</param>
    public StringLikeValue(DateTime value) : this(value.ToString("O"))
    {
    }

    /// <summary>
    /// This method instantiates a string-like value from <code>DateTime?</code> <paramref name="value" />
    /// </summary>
    /// <param name="value">The value to convert</param>
    public StringLikeValue(DateTime? value) : this(value?.ToString("O"))
    {
    }

    /// <summary>
    /// This method instantiates a string-like value from <code>Enum</code> <paramref name="value" />
    /// </summary>
    /// <param name="value">The value to convert</param>
    public StringLikeValue(Enum value) : this(value?.ToString())
    {
    }

    /// <summary>
    /// This method instantiates a string-like value from <code>object</code> <paramref name="value" />
    /// </summary>
    /// <param name="value">The value to convert</param>
    public StringLikeValue(object value) : this(value?.ToString())
    {
    }

    /// <summary>
    /// This method determines whether another string-like value is equal to the current instance
    /// </summary>
    /// <param name="other">The other string-like value to compare</param>
    /// <param name="comparisonType">Optional string comparison settings</param>
    /// <returns>A boolean denoting equality or not</returns>
    public bool Equals(StringLikeValue other,
        StringComparison comparisonType = StringComparison.CurrentCultureIgnoreCase) =>
        Value.Equals(other?.ToString(), comparisonType);

    /// <summary>
    /// This method determines whether another string-like value is equal to the current instance
    /// </summary>
    /// <param name="other">The other string-like value to compare</param>
    /// <param name="comparisonType">Optional string comparison settings</param>
    /// <returns>A boolean denoting equality or not</returns>
    public bool Equals(string other, StringComparison comparisonType = StringComparison.CurrentCultureIgnoreCase) =>
        Value.Equals(other, comparisonType);

    /// <summary>
    /// This method determines whether another string-like value is equal to the current instance
    /// </summary>
    /// <param name="other">The other string-like value to compare</param>
    /// <param name="comparisonType">Optional string comparison settings</param>
    /// <returns>A boolean denoting equality or not</returns>
    public bool Equals(bool other, StringComparison comparisonType = StringComparison.CurrentCultureIgnoreCase) =>
        Value.Equals(other.ToString().ToLower(), comparisonType);

    /// <summary>
    /// This method determines whether another string-like value is equal to the current instance
    /// </summary>
    /// <param name="other">The other string-like value to compare</param>
    /// <param name="comparisonType">Optional string comparison settings</param>
    /// <returns>A boolean denoting equality or not</returns>
    public bool Equals(bool? other, StringComparison comparisonType = StringComparison.CurrentCultureIgnoreCase) =>
        Value.Equals(other?.ToString().ToLower(), comparisonType);

    /// <summary>
    /// This method determines whether another string-like value is equal to the current instance
    /// </summary>
    /// <param name="other">The other string-like value to compare</param>
    /// <param name="comparisonType">Optional string comparison settings</param>
    /// <param name="cultureInfo">The culture by which to convert the decimal to a string</param>
    /// <returns>A boolean denoting equality or not</returns>
    public bool Equals(decimal other, StringComparison comparisonType = StringComparison.CurrentCultureIgnoreCase,
        CultureInfo cultureInfo = null) =>
        Value.Equals(other.ToString(cultureInfo ?? CultureInfo.CurrentCulture), comparisonType);

    /// <summary>
    /// This method determines whether another string-like value is equal to the current instance
    /// </summary>
    /// <param name="other">The other string-like value to compare</param>
    /// <param name="comparisonType">Optional string comparison settings</param>
    /// /// <param name="cultureInfo">The culture by which to convert the decimal to a string</param>
    /// <returns>A boolean denoting equality or not</returns>
    public bool Equals(decimal? other, StringComparison comparisonType = StringComparison.CurrentCultureIgnoreCase,
        CultureInfo cultureInfo = null) =>
        Value.Equals(other?.ToString(cultureInfo ?? CultureInfo.CurrentCulture), comparisonType);

    /// <summary>
    /// This method determines whether another string-like value is equal to the current instance
    /// </summary>
    /// <param name="other">The other string-like value to compare</param>
    /// <param name="comparisonType">Optional string comparison settings</param>
    /// <param name="cultureInfo">The culture by which to convert the double to a string</param>
    /// <returns>A boolean denoting equality or not</returns>
    public bool Equals(double other, StringComparison comparisonType = StringComparison.CurrentCultureIgnoreCase,
        CultureInfo cultureInfo = null) =>
        Value.Equals(other.ToString(cultureInfo ?? CultureInfo.CurrentCulture), comparisonType);

    /// <summary>
    /// This method determines whether another string-like value is equal to the current instance
    /// </summary>
    /// <param name="other">The other string-like value to compare</param>
    /// <param name="comparisonType">Optional string comparison settings</param>
    /// <param name="cultureInfo">The culture by which to convert the double? to a string</param>
    /// <returns>A boolean denoting equality or not</returns>
    public bool Equals(double? other, StringComparison comparisonType = StringComparison.CurrentCultureIgnoreCase,
        CultureInfo cultureInfo = null) =>
        Value.Equals(other?.ToString(cultureInfo ?? CultureInfo.CurrentCulture), comparisonType);

    /// <summary>
    /// This method determines whether another string-like value is equal to the current instance
    /// </summary>
    /// <param name="other">The other string-like value to compare</param>
    /// <param name="comparisonType">Optional string comparison settings</param>
    /// <param name="cultureInfo">The culture by which to convert the float to a string</param>
    /// <returns>A boolean denoting equality or not</returns>
    public bool Equals(float other, StringComparison comparisonType = StringComparison.CurrentCultureIgnoreCase,
        CultureInfo cultureInfo = null) =>
        Value.Equals(other.ToString(cultureInfo ?? CultureInfo.CurrentCulture), comparisonType);

    /// <summary>
    /// This method determines whether another string-like value is equal to the current instance
    /// </summary>
    /// <param name="other">The other string-like value to compare</param>
    /// <param name="comparisonType">Optional string comparison settings</param>
    /// <param name="cultureInfo">The culture by which to convert the float? to a string</param>
    /// <returns>A boolean denoting equality or not</returns>
    public bool Equals(float? other, StringComparison comparisonType = StringComparison.CurrentCultureIgnoreCase,
        CultureInfo cultureInfo = null) =>
        Value.Equals(other?.ToString(cultureInfo ?? CultureInfo.CurrentCulture), comparisonType);

    /// <summary>
    /// This method determines whether another string-like value is equal to the current instance
    /// </summary>
    /// <param name="other">The other string-like value to compare</param>
    /// <param name="comparisonType">Optional string comparison settings</param>
    /// <param name="cultureInfo">The culture by which to convert the long to a string</param>
    /// <returns>A boolean denoting equality or not</returns>
    public bool Equals(long other, StringComparison comparisonType = StringComparison.CurrentCultureIgnoreCase,
        CultureInfo cultureInfo = null) =>
        Value.Equals(other.ToString(cultureInfo ?? CultureInfo.CurrentCulture), comparisonType);

    /// <summary>
    /// This method determines whether another string-like value is equal to the current instance
    /// </summary>
    /// <param name="other">The other string-like value to compare</param>
    /// <param name="comparisonType">Optional string comparison settings</param>
    /// <param name="cultureInfo">The culture by which to convert the long? to a string</param>
    /// <returns>A boolean denoting equality or not</returns>
    public bool Equals(long? other, StringComparison comparisonType = StringComparison.CurrentCultureIgnoreCase,
        CultureInfo cultureInfo = null) =>
        Value.Equals(other?.ToString(cultureInfo ?? CultureInfo.CurrentCulture), comparisonType);

    /// <summary>
    /// This method determines whether another string-like value is equal to the current instance
    /// </summary>
    /// <param name="other">The other string-like value to compare</param>
    /// <param name="comparisonType">Optional string comparison settings</param>
    /// <returns>A boolean denoting equality or not</returns>
    public bool Equals(DateTime other, StringComparison comparisonType = StringComparison.CurrentCultureIgnoreCase) =>
        Value.Equals(other.ToString("O"), comparisonType);

    /// <summary>
    /// This method determines whether another string-like value is equal to the current instance
    /// </summary>
    /// <param name="other">The other string-like value to compare</param>
    /// <param name="comparisonType">Optional string comparison settings</param>
    /// <returns>A boolean denoting equality or not</returns>
    public bool Equals(DateTime? other, StringComparison comparisonType = StringComparison.CurrentCultureIgnoreCase) =>
        Value.Equals(other?.ToString("O"), comparisonType);

    /// <summary>
    /// This method determines whether another string-like value is equal to the current instance
    /// </summary>
    /// <param name="other">The other string-like value to compare</param>
    /// <param name="comparisonType">Optional string comparison settings</param>
    /// <returns>A boolean denoting equality or not</returns>
    public bool Equals(Enum other, StringComparison comparisonType = StringComparison.CurrentCultureIgnoreCase) =>
        Value.Equals(other?.ToString(), comparisonType);

    /// <summary>
    /// This method converts the instance to a string
    /// </summary>
    /// <returns>The string value of the instance</returns>
    public override string ToString() => Value;
}
