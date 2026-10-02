using Silk.NET.Windowing;

namespace Venus;

public abstract class Game : IDisposable
{
    private IWindow? _window;

    /// <summary>
    ///     Gets a value indicating whether the game has been disposed.
    /// </summary>
    /// <value>
    ///     <see langword="true"/> if the game has been disposed; otherwise, <see langword="false"/>.
    /// </value>
    public bool Disposed
    {
        get; 
        private set;
    }

    /// <summary>
    ///     Releases all resources used by the game.
    /// </summary>
    public void Dispose()
    {
        if (Disposed)
        {
            return;
        }
        
        Dispose(true);
        
        Disposed = true;
        
        GC.SuppressFinalize(this);
    }
    
    /// <summary>
    ///     Runs the game.
    /// </summary>
    public void Run()
    {
        var options = WindowOptions.Default;
        
        Configure(ref options);
        
        _window = Window.Create(options);
        
        _window.Load += Load;
        
        _window.Update += Update;
        _window.Render += Render;
        
        _window.Run();
    }

    protected virtual void Load() { }

    protected virtual void Update(double delta) { }

    protected virtual void Render(double delta) { }

    /// <summary>
    ///     Releases the unmanaged resources used by the game and optionally releases the managed resources.
    /// </summary>
    /// <param name="disposing">
    ///     <see langword="true"/> to release both managed and unmanaged resources; <see langword="false"/> to release only unmanaged resources.
    /// </param>
    protected virtual void Dispose(bool disposing)
    {
        if (!disposing)
        {
            return;
        }

        _window?.Dispose();
        _window = null;
    }
    
    /// <summary>
    ///     Configures the window options used to create the game window.
    /// </summary>
    /// <param name="options">
    ///     The window options to configure.
    /// </param>
    protected virtual void Configure(ref WindowOptions options) { }
    
    /// <summary>
    ///     Finalizes an instance of the <see cref="Game"/> class.
    /// </summary>
    ~Game() => Dispose(false);
}