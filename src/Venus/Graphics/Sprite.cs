namespace Venus.Graphics;

public readonly record struct Sprite()
{
    public readonly required Vector2 Position { get; init; }

    public readonly Vector2 Scale { get; init; } = Vector2.One;

    public readonly Vector2 Origin { get; init; } = new(0.5f);

    public readonly Color Color { get; init; } = Color.White;

    public readonly float Rotation { get; init; }

    public readonly Rectangle? Frame { get; init; }

    public readonly SpriteEffects Effects { get; init; } = SpriteEffects.None;
}