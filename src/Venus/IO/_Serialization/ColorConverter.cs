using System.Text.Json;
using System.Text.Json.Serialization;

namespace Venus.IO;

/// <summary>
///     
/// </summary>
public sealed class ColorConverter : JsonConverter<Color>
{
    /// <inheritdoc/> 
    public override Color Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType != JsonTokenType.StartObject)
        {
            throw new JsonException();
        }
        
        using var document = JsonDocument.ParseValue(ref reader);
        
        var element = document.RootElement;

        var r = element.GetProperty(nameof(Color.R)).GetByte();
        var g = element.GetProperty(nameof(Color.G)).GetByte();
        var b = element.GetProperty(nameof(Color.B)).GetByte();
        var a = element.GetProperty(nameof(Color.A)).GetByte();

        return new Color(r, g, b, a);
    }

    /// <inheritdoc/> 
    public override void Write(Utf8JsonWriter writer, Color value, JsonSerializerOptions options)
    {
        writer.WriteStartObject();
        
        writer.WriteNumber(nameof(Color.R), value.R);
        writer.WriteNumber(nameof(Color.G), value.G);
        writer.WriteNumber(nameof(Color.B), value.B);
        writer.WriteNumber(nameof(Color.A), value.A);
        
        writer.WriteEndObject();
    }
}