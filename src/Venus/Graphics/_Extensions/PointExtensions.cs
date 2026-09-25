namespace Venus.Graphics;

public static class PointExtensions
{
    extension(Point point)
    {
        /// <summary>
        ///     Converts the point to a <see cref="Vector2"/>.
        /// </summary>
        /// <returns>
        ///     The converted <see cref="Vector2"/>.
        /// </returns>
        public Vector2 ToVector2() => new(point.X, point.Y);
    }
}