namespace Venus.Graphics;

public readonly record struct RenderLayer
{
    /// <summary>
    ///     Gets the name of the render layer.
    /// </summary>
    public string Name { get; }
    
    /// <summary>
    ///     Gets the depth of the render layer.
    /// </summary>
    public int Depth { get; }
    
    /// <summary>
    ///     Initializes a new instance of the <see cref="RenderLayer"/> struct with the specified name and depth.
    /// </summary>
    /// <param name="name">
    ///     The name of the render layer.
    /// </param>
    /// <param name="depth">
    ///     The depth of the render layer.
    /// </param>
    /// <exception cref="ArgumentException">
    ///     <paramref name="name"/> is <see langword="null"/> or empty.
    /// </exception>
    internal RenderLayer(string name, int depth)
    {
        ArgumentException.ThrowIfNullOrEmpty(name);

        Name = name;
        Depth = depth;
    }
}