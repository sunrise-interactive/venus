using Silk.NET.Maths;

namespace Venus.Graphics;

public sealed class Texture : GraphicsResource
{
    /// <summary>
    ///     Gets the path of the texture.
    /// </summary>
    public string Path { get; }

    /// <summary>
    ///     Gets the width of the texture, in pixels.
    /// </summary>
    public int Width { get; }
    
    /// <summary>
    ///     Gets the height of the texture, in pixels.
    /// </summary>
    public int Height { get; }
    
    /// <summary>
    ///     Gets the size of the texture, in pixels.
    /// </summary>
    public Vector2D<int> Size { get; }

    internal Texture(string path)
    {
        ArgumentException.ThrowIfNullOrEmpty(path);
        
        Path = path;
        
        Size = new Vector2D<int>(Width, Height);
    }

    protected override void Dispose(bool disposing) => throw new NotImplementedException();
}