namespace Venus.IO;

/// <summary>
///     Provides <see cref="Stream"/> extensions.
/// </summary>
public static class StreamExtensions
{
    extension(Stream stream)
    {
        public ReadOnlyMemory<byte> Bytes
        {
            get
            {
                using var memory = new MemoryStream();
                
                stream.CopyTo(memory);
                
                return memory.ToArray();
            }
        }
    }
}