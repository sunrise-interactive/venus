using Silk.NET.WebGPU;

namespace Venus.Graphics;

public static class Colors
{
    /// <summary>
    ///     Represents a fully transparent color.
    /// </summary>
    /// <value>
    ///     A color with red, green, blue, and alpha components set to <c>0.0</c>.
    /// </value>
    public static readonly Color Transparent = new(0.0, 0.0, 0.0, 0.0);
    
    /// <summary>
    ///     Represents a fully opaque black color.
    /// </summary>
    /// <value>
    ///     A color with red, green, and blue components set to <c>0.0</c> and the alpha component set to <c>1.0</c>.
    /// </value>
    public static readonly Color Black = new(0.0, 0.0, 0.0, 1.0);
    
    /// <summary>
    ///     Represents a fully opaque white color.
    /// </summary>
    /// <value>
    ///     A color with red, green, blue, and alpha components set to <c>1.0</c>.
    /// </value>
    public static readonly Color White = new(1.0, 1.0, 1.0, 1.0);
}