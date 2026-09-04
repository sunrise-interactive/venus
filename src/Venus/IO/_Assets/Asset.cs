namespace Venus.IO;

public sealed class Asset<TValue> : IDisposable where TValue : class
{
    /// <summary>
    ///     Gets a value indicating whether the asset has failed to load.
    /// </summary>
    /// <value>
    ///     <see langword="true"/> if the asset has failed to load; otherwise, <see langword="false"/>.
    /// </value>
    public bool Failed => State == AssetState.Failed;
    
    /// <summary>
    ///     Gets a value indicating whether the asset is unloaded.
    /// </summary>
    /// <value>
    ///     <see langword="true"/> if the asset is unloaded; otherwise, <see langword="false"/>.
    /// </value>
    public bool IsUnloaded => State == AssetState.Unloaded;
    
    /// <summary>
    ///     Gets a value indicating whether the asset is loaded.
    /// </summary>
    /// <value>
    ///     <see langword="true"/> if the asset is loaded; otherwise, <see langword="false"/>.
    /// </value>
    public bool IsLoaded => State == AssetState.Loaded;
    
    /// <summary>
    ///     Gets a value indicating whether the asset is loading.
    /// </summary>
    /// <value>
    ///     <see langword="true"/> if the asset is loading; otherwise, <see langword="false"/>.
    /// </value>
    public bool IsLoading => State == AssetState.Loading;
    
    /// <summary>
    ///     Gets a value indicating whether the asset has been disposed.
    /// </summary>
    /// <value>
    ///     <see langword="true"/> if the asset is disposed; otherwise, <see langword="false"/>.
    /// </value>
    public bool IsDisposed => State == AssetState.Disposed;
    
    /// <summary>
    ///     Gets the name of the asset.
    /// </summary>
    public string Name { get; }

    /// <summary>
    ///     Gets the value of the asset.
    /// </summary>
    public TValue? Value { get; internal set; }
    
    /// <summary>
    ///     Gets the state of the asset.
    /// </summary>
    public AssetState State { get; internal set; } = AssetState.Unloaded;

    /// <summary>
    ///     Initializes a new instance of the <see cref="Asset{TValue}"/> class with the specified name.
    /// </summary>
    /// <param name="name">
    ///     The name of the asset.
    /// </param>
    /// <exception cref="ArgumentException">
    ///     <paramref name="name"/> is <see langword="null"/> or empty.
    /// </exception>
    internal Asset(string name)
    {
        ArgumentException.ThrowIfNullOrEmpty(name);

        Name = name;
    }

    /// <summary>
    ///     Releases all resources used by the asset.
    /// </summary>
    public void Dispose()
    {
        if (State == AssetState.Disposed)
        {
            return;
        }
        
        if (Value is IDisposable disposable)
        {
            disposable.Dispose();
        }

        Value = null;
        State = AssetState.Disposed;
    }
}