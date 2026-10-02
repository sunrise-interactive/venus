using Microsoft.Extensions.DependencyInjection;
using Silk.NET.Windowing;

namespace Venus;

public abstract class Game : IDisposable
{
    private ServiceProvider? _services;
    
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
    ///     
    /// </summary>
    /// <exception cref="InvalidOperationException">
    ///     
    /// </exception>
    public IServiceProvider Services => _services ?? throw new InvalidOperationException();
    
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

        _window.Load += Load_Inner;

        _window.Update += Update_Inner;
        _window.Render += Render_Inner;
        
        _window.Run();
    }
    
    private void Load_Inner()
    {
        var collection = new ServiceCollection();
        
        Configure(ref collection);

        collection.AddSingleton(new Time());

        _services = collection.BuildServiceProvider();

        Load();
    }

    private void Update_Inner(double delta)
    {
        Update();
    }

    private void Render_Inner(double delta)
    {
        Render();
    }
    
    /// <summary>
    ///     Occurs when the game window is loaded.
    /// </summary>
    protected virtual void Load() { }
    
    /// <summary>
    ///     Occurs when the game window is updated.
    /// </summary>
    protected virtual void Update() { }
    
    /// <summary>
    ///     Occurs when the game window is rendered.
    /// </summary>
    protected virtual void Render() { }
    
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

        _services?.Dispose();
        _services = null;

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
    ///     Configures the service collection used to build the game service provider.
    /// </summary>
    /// <param name="services">
    ///     The service collection to configure.
    /// </param>
    protected virtual void Configure(ref ServiceCollection services) { }
    
    /// <summary>
    ///     Finalizes an instance of the <see cref="Game"/> class.
    /// </summary>
    ~Game() => Dispose(false);
}