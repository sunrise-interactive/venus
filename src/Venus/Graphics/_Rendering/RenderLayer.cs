namespace Venus.Graphics;

public readonly record struct RenderLayer
{
    /// <summary>
    ///     Gets the name of the render layer.
    /// </summary>
    public string Name { get; }

    /// <summary>
    ///     Initializes a new instance of the <see cref="RenderLayer"/> struct with the specified name.
    /// </summary>
    /// <param name="name">
    ///     The name of the render layer.
    /// </param>
    /// <exception cref="ArgumentException">
    ///     <paramref name="name"/> is <see langword="null"/> or empty.
    /// </exception>
    internal RenderLayer(string name)
    {
        ArgumentException.ThrowIfNullOrEmpty(name);

        Name = name;
    }
}