using System.Text.Json;
using System.Text.Json.Serialization;

namespace Venus.IO;

/// <summary>
///     
/// </summary>
public sealed class RectangleConverter : JsonConverter<Rectangle>
{
    /// <inheritdoc/> 
    public override Rectangle Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType != JsonTokenType.StartObject)
        {
            throw new JsonException();
        }
        
        using var document = JsonDocument.ParseValue(ref reader);
        
        var element = document.RootElement;
        
        var x = element.GetProperty(nameof(Rectangle.X)).GetInt32();
        var y = element.GetProperty(nameof(Rectangle.Y)).GetInt32();
        
        var width = element.GetProperty(nameof(Rectangle.Width)).GetInt32();
        var height = element.GetProperty(nameof(Rectangle.Height)).GetInt32();

        return new Rectangle(x, y, width, height);
    }

    /// <inheritdoc/> 
    public override void Write(Utf8JsonWriter writer, Rectangle value, JsonSerializerOptions options)
    {
        writer.WriteStartObject();

        writer.WriteNumber(nameof(Rectangle.X), value.X);
        writer.WriteNumber(nameof(Rectangle.Y), value.Y);
        writer.WriteNumber(nameof(Rectangle.Width), value.Width);
        writer.WriteNumber(nameof(Rectangle.Height), value.Height);

        writer.WriteEndObject();
    }
}