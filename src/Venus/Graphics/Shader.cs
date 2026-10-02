namespace Venus.Graphics;

public sealed class Shader : IDisposable
{
    /// <summary>
    ///     Gets a value indicating whether the shader has been disposed.
    /// </summary>
    /// <value>
    ///     <see langword="true"/> if the shader has been disposed; otherwise, <see langword="false"/>.
    /// </value>
    public bool Disposed
    {
        get;
        private set;
    }
    
    /// <summary>
    ///     Gets the name of the shader.
    /// </summary>
    public string Name
    {
        get;
    }

    /// <summary>
    ///     Gets the source code of the shader.
    /// </summary>
    public string Source
    {
        get;
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="Shader"/> class.
    /// </summary>
    /// <param name="name">
    ///     The name of the shader.
    /// </param>
    /// <param name="source">
    ///     The source code of the shader.
    /// </param>
    /// <exception cref="ArgumentException">
    ///     <paramref name="source"/> is <see langword="null"/> or empty.
    /// </exception>
    public Shader(string name, string source)
    {
        ArgumentException.ThrowIfNullOrEmpty(source);

        Name = name;
        Source = source;
    }
    
    /// <summary>
    ///     Releases all resources used by the shader.
    /// </summary>
    public void Dispose()
    {
        if (Disposed)
        {
            return;
        }

        Disposed = true;
    }

    /// <inheritdoc/>
    public override string ToString() => Name;
}