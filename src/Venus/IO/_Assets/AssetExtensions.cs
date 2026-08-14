namespace Venus.IO;

public static class AssetExtensions
{
    extension(Asset<Texture2D> asset)
    {
        /// <summary>
        ///     Gets the height of the texture asset, in pixels.
        /// </summary>
        public int Width => asset.Value.Width;
        
        /// <summary>
        ///     Gets the width of the texture asset, in pixels.
        /// </summary>
        public int Height => asset.Value.Height;
        
        /// <summary>
        ///     Gets the size of the texture asset, in pixels.
        /// </summary>
        public Vector2 Size => new Vector2(asset.Value.Width, asset.Value.Height);
    }
}