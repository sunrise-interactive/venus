using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Venus.IO;

namespace Venus.Examples;

public sealed class Example : GameInstance
{
    protected override void Initialize()
    {
        base.Initialize();
        
        Assets.Add(new FileSystemAssetSource("Assets"));
    }
    
    protected override void Draw(GameTime gameTime)
    {
        base.Draw(gameTime);
        
        GraphicsDevice.Clear(Color.Transparent);

        Batch.Begin();

        Batch.Draw(Assets.Request<Texture2D>("Assets/Images/Cursor.png"), new Vector2(0f), Color.White);
        
        Batch.End();
    }
}