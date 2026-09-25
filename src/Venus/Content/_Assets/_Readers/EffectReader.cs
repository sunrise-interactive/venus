using Venus.IO;

namespace Venus.Content;

public sealed class EffectReader : IAssetReader<Effect>
{
    private readonly GraphicsDevice _device;

    /// <summary>
    ///     Initializes a new instance of the <see cref="EffectReader"/> class with the specified graphics device.
    /// </summary>
    /// <param name="device">
    ///     The graphics device of the reader.
    /// </param>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="device"/> is <see langword="null"/>.
    /// </exception>
    public EffectReader(GraphicsDevice device)
    {
        ArgumentNullException.ThrowIfNull(device);

        _device = device;
    }

    /// <summary>
    ///     Reads an effect from the specified stream.
    /// </summary>
    /// <param name="stream">
    ///     The stream to read the effect from.
    /// </param>
    /// <returns>
    ///     An effect read from the stream.
    /// </returns>
    public Effect Read(Stream stream) => new Effect(_device, stream.Bytes.ToArray());
}