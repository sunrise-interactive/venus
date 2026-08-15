namespace Venus.IO;

public sealed class TextureReader : AssetReader<Texture2D>
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
    
    public override Texture2D Read(string path)
    {
        using var stream = new FileStream(path, FileMode.Open, FileAccess.Read);

        return Texture2D.FromStream(device, stream);
    }
}