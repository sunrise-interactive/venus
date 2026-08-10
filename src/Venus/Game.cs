using Silk.NET.Windowing;

namespace Venus;

public sealed class Game : IDisposable
{
    /// <summary>
    ///     Gets a value indicating whether the game is disposed.
    /// </summary>
    /// <value>
    ///     <see langword="true"/> if the game has been disposed; otherwise, <see langword="false"/>.
    /// </value>
    public bool Disposed { get; private set; }

    /// <summary>
    /// 
    /// </summary>
    public void Run()
    {
        var window = Window.Create(WindowOptions.Default);

        window.Load += Load;
        window.Closing += Close;

        window.Update += Update;
        window.Render += Render;
        
        window.Run();
    }

    /// <summary>
    ///     
    /// </summary>
    public void Dispose()
    {
        if (Disposed)
        {
            return;
        }
        
        Disposed = true;
        
        Dispose(true);
        
        GC.SuppressFinalize(this);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="disposing">
    ///     
    /// </param>
    public void Dispose(bool disposing)
    {

    }

    /// <summary>
    ///     Raised when the game's window is loaded.
    /// </summary>
    private static void Load()
    {
        
    }
    
    /// <summary>
    ///     Raised when the game's window is closing.
    /// </summary>
    private static void Close()
    {
    }
    
    /// <summary>
    ///     Raised when the game's window is updated.
    /// </summary>
    /// <param name="delta">
    ///     
    /// </param>
    private static void Update(double delta)
    {
    }

    /// <summary>
    ///     Raised when the game's window is rendered.
    /// </summary>
    /// <param name="delta">
    ///     
    /// </param>
    private static void Render(double delta)
    {
    }
    
    ~Game() => Dispose(false);
}