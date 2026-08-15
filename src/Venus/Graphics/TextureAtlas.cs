using System.Diagnostics.CodeAnalysis;

namespace Venus.Graphics;

public readonly record struct TextureAtlasRegion
{
    /// <summary>
    ///     Gets the bounds of the region, in pixels.
    /// </summary>
    public required Rectangle Bounds { get; init; }

    /// <summary>
    ///     Gets the size of the region, in pixels.
    /// </summary>
    public Vector2 Size => Bounds.Size;

    /// <summary>
    ///     Gets the width of the region, in pixels.
    /// </summary>
    public int Width => Bounds.Width;
    
    /// <summary>
    ///     Gets the height of the region, in pixels.
    /// </summary>
    public int Height => Bounds.Height;

    /// <summary>
    ///     Initializes a new instance of the <see cref="TextureAtlasRegion"/> class with the specified bounds.
    /// </summary>
    /// <param name="bounds">
    ///     The bounds of the region.
    /// </param>
    [SetsRequiredMembers]
    public TextureAtlasRegion(Rectangle bounds) => Bounds = bounds;
    
    public static implicit operator Rectangle(TextureAtlasRegion region) => region.Bounds;
}

public sealed class TextureAtlas : IDisposable
{
    private readonly Dictionary<string, TextureAtlasRegion> regions = [];

    /// <summary>
    ///     Gets the path to the texture of the atlas.
    /// </summary>
    public required string Path { get; init; }

    /// <summary>
    ///     Gets a value indicating whether the atlas has been disposed.
    /// </summary>
    /// <value>
    ///     <see langword="true"/> if the atlas has been disposed; otherwise, <see langword="false"/>.
    /// </value>
    public bool Disposed { get; private set; }

    /// <summary>
    ///     Gets a read-only dictionary containing all regions in the atlas by name.
    /// </summary>
    public IReadOnlyDictionary<string, TextureAtlasRegion> Regions => regions;

    /// <summary>
    ///     Initializes a new instance of the <see cref="TextureAtlas" /> class with the specified texture asset and name.
    /// </summary>
    /// <param name="path">
    ///     The path to the texture of the atlas.
    /// </param>
    /// <exception cref="ArgumentException">
    ///     <paramref name="path"/> is <see langword="null" /> or empty.
    /// </exception>
    [SetsRequiredMembers]
    internal TextureAtlas(string path)
    {
        ArgumentException.ThrowIfNullOrEmpty(path);
        
        Path = path;
    }

    /// <summary>
    ///     Gets the region with the specified name.
    /// </summary>
    /// <param name="name">
    ///     The name of the region to get.
    /// </param>
    public TextureAtlasRegion this[string name] => regions[name];

    public void Dispose()
    {
        if (Disposed)
        {
            return;
        }
        
        Disposed = true;
    }
}