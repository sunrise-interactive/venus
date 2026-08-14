using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Venus.Graphics;
using Venus.Input;

namespace Venus.Examples;

public sealed class Example : GameInstance
{
    public Texture2D Cursor;

    private float rotation;

    private Vector2 velocity;

    private Vector2 position;
    private Vector2 oldPosition;

    private readonly Vector2[] afterimages = new Vector2[8];

    protected override void LoadContent()
    {
        base.LoadContent();

        Cursor = Texture2D.FromStream(GraphicsDevice, File.OpenRead("Assets/Images/Cursor.png"));
        
        buffer = new RenderTarget2D(GraphicsDevice, GraphicsDevice.PresentationParameters.BackBufferWidth / 2, GraphicsDevice.PresentationParameters.BackBufferHeight / 2);
    }

    protected override void Update(GameTime gameTime)
    {
        base.Update(gameTime);

        oldPosition = position;
        position = Vector2.SmoothStep(position, InputModule.Mouse.Position, 1f);

        velocity = position - oldPosition;

        if (velocity.LengthSquared() > 0.001f)
        {
            rotation = MathF.Atan2(velocity.Y, velocity.X) + MathHelper.PiOver2;
        }

        for (int i = afterimages.Length - 1; i > 0; i--)
        {
            afterimages[i] = afterimages[i - 1];
        }

        afterimages[0] = position;
    }

    private RenderTarget2D buffer = null!;

    protected override void Draw(GameTime gameTime)
    {
        base.Draw(gameTime);

        GraphicsDevice.SetRenderTarget(buffer);
        GraphicsDevice.Clear(Color.Transparent);
        
        Batch.Begin(SpriteSortMode.Deferred, default, SamplerState.PointClamp, default, default, default, Matrices.Sizes.Half);

        Batch.Draw
        (
            Cursor,
            position,
            null,
            Color.White,
            gameTime.TotalGameTime.Ticks * 0.0001f,
            Cursor.Size / 2f,
            4f,
            SpriteEffects.None,
            0f
        );

        Batch.End();
        
        GraphicsDevice.SetRenderTarget(null);
        GraphicsDevice.Clear(Color.Transparent);

        Batch.Begin(SpriteSortMode.Deferred, default, SamplerState.PointClamp, default, default);

        Batch.Draw(buffer, new Rectangle(0, 0, GraphicsDevice.PresentationParameters.BackBufferWidth, GraphicsDevice.PresentationParameters.BackBufferHeight), Color.White);

        Batch.End();
    }
}