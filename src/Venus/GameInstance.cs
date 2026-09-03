using JetBrains.Annotations;
using Venus.IO;

namespace Venus;

public abstract class GameInstance : Game
{
    /// <summary>
    ///     Gets the graphics device manager of the game.
    /// </summary>
    [UsedImplicitly]
    public GraphicsDeviceManager Graphics { get; }
    
    /// <summary>
    ///     Gets the asset repository of the game.
    /// </summary>
    public AssetRepository Assets { get; }
    
    /// <summary>
    ///     Gets the sprite batch of the game.
    /// </summary>
    public SpriteBatch Batch { get; private set; } = null!;
    
    /// <summary>
    ///     Initializes a new instance of the <see cref="GameInstance"/> class.
    /// </summary>
    public GameInstance()
    {
        Graphics = new GraphicsDeviceManager(this);
        Assets = new AssetRepository();
    }

    protected override void Initialize()
    {
        base.Initialize();
        
        Assets.Add(new TextureReader(GraphicsDevice));
    }

    protected override void LoadContent()
    {
        base.LoadContent();
        
        Batch = new SpriteBatch(GraphicsDevice);
    }

    protected override void UnloadContent()
    {
        base.UnloadContent();
        
        Batch.Dispose();
    }
}