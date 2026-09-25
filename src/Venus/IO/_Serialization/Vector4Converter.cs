using System.Text.Json;
using System.Text.Json.Serialization;

namespace Venus.IO;

/// <summary>
///     
/// </summary>
public sealed class Vector4Converter : JsonConverter<Vector4>
{
    /// <inheritdoc/> 
    public override Vector4 Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType != JsonTokenType.StartObject)
        {
            throw new JsonException();
        }
        
        using var document = JsonDocument.ParseValue(ref reader);
        
        var element = document.RootElement;

        var x = element.GetProperty(nameof(Vector4.X)).GetSingle();
        var y = element.GetProperty(nameof(Vector4.Y)).GetSingle();
        var z = element.GetProperty(nameof(Vector4.Z)).GetSingle();
        var w = element.GetProperty(nameof(Vector4.W)).GetSingle();

        return new Vector4(x, y, z, w);
    }

    /// <inheritdoc/> 
    public override void Write(Utf8JsonWriter writer, Vector4 value, JsonSerializerOptions options)
    {
        writer.WriteStartObject();
        
        writer.WriteNumber(nameof(Vector4.X), value.X);
        writer.WriteNumber(nameof(Vector4.Y), value.Y);
        writer.WriteNumber(nameof(Vector4.Z), value.Z);
        writer.WriteNumber(nameof(Vector4.W), value.W);

        writer.WriteEndObject();
    }
}