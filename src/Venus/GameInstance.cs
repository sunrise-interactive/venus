using JetBrains.Annotations;
using Venus.Graphics;
using Venus.IO;

namespace Venus;

public abstract class GameInstance : Game
{
    private static GameInstance _instance = null!;

    /// <summary>
    ///     Gets the current game instance.
    /// </summary>
    public static GameInstance Instance => _instance ?? throw new InvalidOperationException();
    
    /// <summary>
    ///     Gets the graphics device manager of the game.
    /// </summary>
    [UsedImplicitly]
    public GraphicsDeviceManager Graphics { get; }

    /// <summary>
    ///     Gets the renderer of the game.
    /// </summary>
    public Renderer Renderer { get; private set; } = null!;
    
    /// <summary>
    ///     Gets the asset repository of the game.
    /// </summary>
    public AssetRepository Assets { get; private set; } = null!;
    
    /// <summary>
    ///     Initializes a new instance of the <see cref="GameInstance"/> class.
    /// </summary>
    public GameInstance()
    {
        if (_instance != null)
        {
            throw new InvalidOperationException();
        }

        _instance = this;
        
        Graphics = new GraphicsDeviceManager(this);
    }

    /// <inheritdoc/>
    protected override void Initialize()
    {
        base.Initialize();
        
        GameEngine.Initialize();
    }

    /// <inheritdoc/>
    protected override void LoadContent()
    {
        base.LoadContent();
        
        Assets = new AssetRepository();
        Renderer = new Renderer(new SpriteBatch(GraphicsDevice));
    }

    /// <inheritdoc/>
    protected override void UnloadContent()
    {
        base.UnloadContent();

        Assets.Dispose();
        Renderer.Dispose();
    }

    /// <inheritdoc/>
    protected override void Draw(GameTime gameTime)
    {
        base.Draw(gameTime);
        
        Renderer.Flush();
    }
}