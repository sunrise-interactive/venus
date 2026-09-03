namespace Venus.IO;

public sealed class TextureReader : IAssetReader<Texture2D>
{
    private readonly GraphicsDevice device;
    
    /// <summary>
    ///     Initializes a new instance of the <see cref="TextureReader"/> class with the specified graphics device.
    /// </summary>
    /// <param name="device">
    ///     The graphics device of the reader.
    /// </param>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="device"/> is <see langword="null"/>.
    /// </exception>
    public TextureReader(GraphicsDevice device)
    {
        ArgumentNullException.ThrowIfNull(device);
        
        this.device = device;
    }

    /// <summary>
    ///     Reads a texture from the specified stream.
    /// </summary>
    /// <param name="stream">
    ///     The stream to read the texture from.
    /// </param>
    /// <returns>
    ///     The texture read from the stream.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="stream"/> is <see langword="null"/>.
    /// </exception>
    public Texture2D Read(Stream stream)
    {
        ArgumentNullException.ThrowIfNull(stream);
        
        return Texture2D.FromStream(device, stream);
    }
}