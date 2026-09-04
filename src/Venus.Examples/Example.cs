using Microsoft.Xna.Framework;

namespace Venus.Examples;

public sealed class Example : GameInstance
{
    protected override void Draw(GameTime gameTime)
    {
        base.Draw(gameTime);
        
        GraphicsDevice.Clear(Color.Transparent);

        Batch.Begin();

        Batch.End();
    }
}