namespace Venus.Graphics;

public static class Screen
{
    private static GraphicsDevice Device => GameInstance.Instance.GraphicsDevice;

    /// <summary>
    ///     Gets the width of the screen, in pixels.
    /// </summary>
    public static int Width => Device.Viewport.Width;
    
    /// <summary>
    ///     Gets the height of the screen, in pixels.
    /// </summary>
    public static int Height => Device.Viewport.Height;
    
    /// <summary>
    ///     Gets the size of the screen, in pixels.
    /// </summary>
    public static Vector2 Size => new(Width, Height);
}