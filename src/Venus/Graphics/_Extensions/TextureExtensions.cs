namespace Venus.Graphics;

/// <summary>
///     Provides <see cref="Texture2D"/> extensions.
/// </summary>
public static class TextureExtensions
{
    extension(Texture2D texture)
    {
        /// <summary>
        ///     Gets the size of the texture, in pixels.
        /// </summary>
        public Vector2 Size => new(texture.Width, texture.Height);
    }
}