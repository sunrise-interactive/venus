using System.Diagnostics.CodeAnalysis;

namespace Venus.Graphics;

public readonly record struct RenderLayer
{
    /// <summary>
    ///     Gets the name of the render layer.
    /// </summary>
    public readonly required string Name { get; init; }

    /// <summary>
    ///     Gets the depth of the render layer.
    /// </summary>
    public readonly required float Depth { get; init; }

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
    [SetsRequiredMembers]
    internal RenderLayer(string name, float depth)
    {
        ArgumentException.ThrowIfNullOrEmpty(name);
        
        Name = name;
        Depth = depth;
    }
}