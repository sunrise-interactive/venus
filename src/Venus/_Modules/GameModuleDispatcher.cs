namespace Venus;

public sealed class GameModuleDispatcher
{
    private readonly Dictionary<Type, GameModule> modules = [];

    /// <summary>
    ///     Gets the module of the specified type.
    /// </summary>
    /// <param name="type">
    ///     The type of the module to get.
    /// </param>
    public GameModule this[Type type]
    {
        get => modules[type];
        private set => modules[type] = value;
    }

    internal void Update(GameTime gameTime)
    {
        foreach (var module in modules.Values)
        {
            if (!module.Enabled)
            {
                continue;
            }
            
            module.Update(gameTime);
        }
    }
    
    /// <summary>
    ///     Adds a module to the dispatcher.
    /// </summary>
    /// <param name="module">
    ///     The module to add.
    /// </param>
    /// <typeparam name="TModule">
    ///     The type of the module to add.
    /// </typeparam>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="module"/> is <see langword="null"/>.
    /// </exception>
    public void Add<TModule>(TModule module) where TModule : GameModule => this[typeof(TModule)] = module ?? throw new ArgumentNullException(nameof(module));

    /// <summary>
    ///     Enables the specified module.
    /// </summary>
    /// <typeparam name="TModule">
    ///     The type of the module to enable.
    /// </typeparam>
    public void Enable<TModule>() where TModule : GameModule => this[typeof(TModule)].Enabled = true;
    
    /// <summary>
    ///     Disables the specified module.
    /// </summary>
    /// <typeparam name="TModule">
    ///     The type of the module to disable.
    /// </typeparam>
    public void Disable<TModule>() where TModule : GameModule => this[typeof(TModule)].Enabled = false;
}