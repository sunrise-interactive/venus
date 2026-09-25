namespace Venus.IO;

/// <summary>
///     Provides <see cref="BinaryReader"/> extensions.
/// </summary>
public static class BinaryReaderExtensions
{
    extension(BinaryReader reader)
    {
        public Vector2 ReadVector2() => new(reader.ReadSingle(), reader.ReadSingle());
        
        public Vector3 ReadVector3() => new(reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle());
        
        public Vector4 ReadVector4() => new(reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle());
        
        public Rectangle ReadRectangle() => new(reader.ReadInt32(), reader.ReadInt32(), reader.ReadInt32(), reader.ReadInt32());
    }
}