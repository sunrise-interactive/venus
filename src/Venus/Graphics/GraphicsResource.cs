using Silk.NET.OpenGL;

namespace Venus.Graphics;

public abstract class GraphicsResource : IDisposable
{
    protected static GL Graphics { get; private set; } = null!;
    
    /// <summary>
    ///     Gets the handle of the graphics resource.
    /// </summary>
    public uint Handle { get; protected set; }
    
    /// <summary>
    ///     Gets a value indicating whether the graphics resource is disposed.
    /// </summary>
    /// <value>
    ///     <see langword="true" /> if the graphics resource has been disposed; otherwise,
    ///     <see langword="false" />.
    /// </value>
    public bool Disposed { get; protected set; }

    /// <summary>
    ///     Initializes an instance of the <see cref="GraphicsResource"/> <see langword="class"/>.
    /// </summary>
    /// <exception cref="ArgumentNullException">
    ///     <see cref="Graphics"/> is <see langword="null"/>.
    /// </exception>
    protected GraphicsResource() => ArgumentNullException.ThrowIfNull(Graphics);
    
    /// <summary>
    ///     Releases the resources used by the graphics resource.
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
    ///     Releases the resources used by the graphics resource.
    /// </summary>
    /// <param name="disposing">
    ///     
    /// </param>
    protected abstract void Dispose(bool disposing);
}