namespace Venus.IO;

public sealed class TextureReader : IAssetReader<Texture2D>
{
    private readonly GraphicsDevice _device;
    
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
        
        _device = device;
    }

    /// <summary>
    ///     Reads a texture from the specified stream.
    /// </summary>
    /// <param name="stream">
    ///     The stream to read the texture from.
    /// </param>
    /// <returns>
    ///     A texture read from the stream.
    /// </returns>
    public Texture2D Read(Stream stream) => Texture2D.FromStream(_device, stream);
}