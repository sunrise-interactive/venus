using Microsoft.Xna.Framework;
using Venus.Graphics;

namespace Venus.Examples;

public sealed class Example : GameInstance
{
    protected override void Draw(GameTime gameTime)
    {
        base.Draw(gameTime);
        
        GraphicsDevice.Clear(Color.Transparent);
        
        Renderer.Submit(new Sprite()
        {
            Position = new Vector2(0.5f)
        });
    }
}