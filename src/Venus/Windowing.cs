using Silk.NET.Maths;
using Silk.NET.Windowing;

namespace Venus;

public sealed class Windowing
{
    private IWindow _window;

    /// <summary>
    ///     Gets or sets the title of the window.
    /// </summary>
    public string Title
    {
        get => _window.Title;
        set => _window.Title = value;
    }

    /// <summary>
    ///     Gets or sets the size of the window.
    /// </summary>
    public Vector2D<int> Size
    {
        get => _window.Size;
        set => _window.Size = value;
    }
    
    /// <summary>
    ///     Gets the width of the window.
    /// </summary>
    public int Width => _window.Size.X;
    
    /// <summary>
    ///     Gets the height of the window.
    /// </summary>
    public int Height => _window.Size.Y;
    
    /// <summary>
    ///     Gets the position of the window.
    /// </summary>
    public Vector2D<int> Position => _window.Position;
    
    /// <summary>
    ///     Gets the center position of the window.
    /// </summary>
    public Vector2D<int> Center => _window.Position + _window.Size / 2;
}