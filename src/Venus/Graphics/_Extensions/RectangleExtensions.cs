namespace Venus.Graphics;

/// <summary>
///     Provides <see cref="Rectangle"/> extensions.
/// </summary>
public static class RectangleExtensions
{
    extension(Rectangle rectangle)
    {
        /// <summary>
        ///     Gets the size of the rectangle, in pixels.
        /// </summary>
        public Vector2 Size => new Vector2(rectangle.Width, rectangle.Height);
    }
}