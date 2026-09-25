using System.Text.Json;
using System.Text.Json.Serialization;

namespace Venus.IO;

/// <summary>
///     
/// </summary>
public sealed class Vector2Converter : JsonConverter<Vector2>
{
    /// <inheritdoc/> 
    public override Vector2 Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType != JsonTokenType.StartObject)
        {
            throw new JsonException();
        }
        
        using var document = JsonDocument.ParseValue(ref reader);
        
        var element = document.RootElement;

        var x = element.GetProperty(nameof(Vector2.X)).GetSingle();
        var y = element.GetProperty(nameof(Vector2.Y)).GetSingle();

        return new Vector2(x, y);
    }

    /// <inheritdoc/> 
    public override void Write(Utf8JsonWriter writer, Vector2 value, JsonSerializerOptions options)
    {
        writer.WriteStartObject();
        
        writer.WriteNumber(nameof(Vector2.X), value.X);
        writer.WriteNumber(nameof(Vector2.Y), value.Y);

        writer.WriteEndObject();
    }
}