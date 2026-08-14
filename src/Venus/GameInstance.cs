using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using Venus.Input;
using Venus.Threading;

namespace Venus;

public abstract class GameInstance : Game
{
    public SpriteBatch Batch { get; private set; } = null!;
    
    /// <summary>
    ///     Gets the modules of the game.
    /// </summary>
    public GameModuleDispatcher Modules { get; }
    
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
        Modules = new GameModuleDispatcher();
        Graphics = new GraphicsDeviceManager(this);
    }

    protected override void Initialize()
    {
        base.Initialize();
        
        Add(new InputModule());
        
        MainThread.Initialize();
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

    protected override void Update(GameTime gameTime)
    {
        base.Update(gameTime);
        
        Modules.Update(gameTime);
    }

    /// <summary>
    ///     Adds a module to the game.
    /// </summary>
    /// <param name="module">
    ///     The module to add.
    /// </param>
    /// <typeparam name="TModule">
    ///     The type of the module to add.
    /// </typeparam>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Add<TModule>(TModule module) where TModule : GameModule => Modules.Add(module);
    
    /// <summary>
    ///     Enables the specified module.
    /// </summary>
    /// <typeparam name="TModule">
    ///     The type of the module to enable.
    /// </typeparam>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Enable<TModule>() where TModule : GameModule => Modules.Enable<TModule>();
    
    /// <summary>
    ///     Disables the specified module.
    /// </summary>
    /// <typeparam name="TModule">
    ///     The type of the module to disable.
    /// </typeparam>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Disable<TModule>() where TModule : GameModule => Modules.Disable<TModule>();
}