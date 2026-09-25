using JetBrains.Annotations;

namespace Venus;

public abstract class GameInstance : Game
{
    private static GameInstance _instance = null!;

    /// <summary>
    ///     Gets the current game instance.
    /// </summary>
    /// <exception cref="InvalidOperationException">
    ///     <see cref="_instance"/> is <see langword="null"/>.
    /// </exception>
    public static GameInstance Instance => _instance ?? throw new InvalidOperationException();
    
    /// <summary>
    ///     Gets the graphics device manager of the game.
    /// </summary>
    [UsedImplicitly]
    public GraphicsDeviceManager Graphics { get; }

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
}