using System.Text.Json;
using System.Text.Json.Serialization;

namespace Venus.IO;

/// <summary>
///     
/// </summary>
public sealed class Vector3Converter : JsonConverter<Vector3>
{
    /// <inheritdoc/> 
    public override Vector3 Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType != JsonTokenType.StartObject)
        {
            throw new JsonException();
        }
        
        using var document = JsonDocument.ParseValue(ref reader);
        
        var element = document.RootElement;

        var x = element.GetProperty(nameof(Vector3.X)).GetSingle();
        var y = element.GetProperty(nameof(Vector3.Y)).GetSingle();
        var z = element.GetProperty(nameof(Vector3.Z)).GetSingle();

        return new Vector3(x, y, z);
    }

    /// <inheritdoc/> 
    public override void Write(Utf8JsonWriter writer, Vector3 value, JsonSerializerOptions options)
    {
        writer.WriteStartObject();
        
        writer.WriteNumber(nameof(Vector3.X), value.X);
        writer.WriteNumber(nameof(Vector3.Y), value.Y);
        writer.WriteNumber(nameof(Vector3.Z), value.Y);

        writer.WriteEndObject();
    }
}