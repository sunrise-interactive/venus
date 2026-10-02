using Silk.NET.WebGPU;

namespace Venus.Graphics;

public sealed unsafe class GraphicsManager : IDisposable
{
    public static WebGPU API
    {
        get;
        private set;
    }
    
    /// <summary>
    ///     Gets the device of the graphics manager.
    /// </summary>
    public GraphicsDevice Device
    {
        get;
        private set;
    } = null!;
    
    /// <summary>
    ///     Gets the instance of the graphics manager.
    /// </summary>
    internal Instance* Instance
    {
        get;
        private set;
    }
    
    /// <summary>
    ///     Gets the surface of the graphics device.
    /// </summary>
    internal Surface* Surface
    {
        get;
        private set;
    }
    
    /// <summary>
    ///     Gets a value indicating whether the graphics manager has been disposed.
    /// </summary>
    /// <value>
    ///     <see langword="true"/> if the graphics manager has been disposed; otherwise, <see langword="false"/>.
    /// </value>
    public bool Disposed
    {
        get;
        private set;
    }

    static GraphicsManager() => API = WebGPU.GetApi();
    
    /// <summary>
    ///     Releases all resources used by the graphics manager.
    /// </summary>
    public void Dispose()
    {
        if (Disposed)
        {
            return;
        }
        
        Disposed = true;
    }
}

public sealed unsafe class GraphicsDevice : IDisposable
{
    /// <summary>
    ///     Gets the adapter of the graphics device.
    /// </summary>
    internal Adapter* Adapter
    {
        get;
        private set;
    }
    
    /// <summary>
    ///     Gets the handle of the graphics device.
    /// </summary>
    internal Device* Handle
    {
        get;
        private set;
    }

    /// <summary>
    ///     Gets the queue of the graphics device.
    /// </summary>
    internal Queue* Queue
    {
        get;
        private set;
    }
    
    /// <summary>
    ///     Gets a value indicating whether the graphics device has been disposed.
    /// </summary>
    /// <value>
    ///     <see langword="true"/> if the graphics device has been disposed; otherwise, <see langword="false"/>.
    /// </value>
    public bool Disposed
    {
        get;
        private set;
    }
    
    /// <summary>
    ///     Releases all resources used by the graphics device.
    /// </summary>
    public void Dispose()
    {
        if (Disposed)
        {
            return;
        }

        Disposed = true;
    }
}