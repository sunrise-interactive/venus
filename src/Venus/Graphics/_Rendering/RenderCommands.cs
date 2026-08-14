namespace Venus.Graphics;

public static class RenderCommands
{
    public readonly record struct Sprite()
    {
        /// <summary>
        ///     Gets the position of the sprite, in screen coordinates.
        /// </summary>
        public readonly required Vector2 Position { get; init; }

        /// <summary>
        ///     Gets the scale of the sprite.
        /// </summary>
        public readonly Vector2 Scale { get; init; } = Vector2.One;

        /// <summary>
        ///     Gets the normalized origin of the sprite.
        /// </summary>
        /// <value>
        ///     A value in the range of <c>[(0f, 0f) - (1f, 1f)]</c>, where <c>(0f, 0f)</c> represents the top
        ///     left corner of the sprite, and <c>(1f, 1f)</c> represents the bottom right corner of the
        ///     sprite.
        /// </value>
        public readonly Vector2 Origin { get; init; } = new(0.5f);

        /// <summary>
        ///     Gets the color of the sprite.
        /// </summary>
        public readonly Color Color { get; init; } = Color.White;

        /// <summary>
        ///     Gets the opacity of the sprite.
        /// </summary>
        /// <value>
        ///     A value in the range of <c>[0f - 1f]</c>, where <c>0f</c> represents fully transparent, and
        ///     <c>1f</c> represents fully opaque.
        /// </value>
        public readonly float Opacity { get; init; } = 1f;

        /// <summary>
        ///     Gets the rotation of the sprite, in radians.
        /// </summary>
        public readonly float Rotation { get; init; }

        /// <summary>
        ///     Gets the frame of the sprite.
        /// </summary>
        public readonly Rectangle? Frame { get; init; }

        /// <summary>
        ///     Gets the sprite effects of the sprite.
        /// </summary>
        public readonly SpriteEffects Effects { get; init; } = SpriteEffects.None;
    }
}