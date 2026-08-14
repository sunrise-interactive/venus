namespace Venus.IO;

public abstract class Asset
{
    /// <summary>
    ///     Gets the name of the asset.
    /// </summary>
    public string Name { get; }
    
    /// <summary>
    ///     Initializes a new instance of the <see cref="Asset"/> class with the specified name.
    /// </summary>
    /// <param name="name">
    ///     The name of the asset.
    /// </param>
    /// <exception cref="ArgumentException">
    ///     <paramref name="name"/> is <see langword="null"/>.
    /// </exception>
    internal Asset(string name)
    {
        ArgumentException.ThrowIfNullOrEmpty(name);
        
        Name = name;
    }
}

public sealed class Asset<TValue> : Asset, IDisposable where TValue : class
{
    /// <summary>
    ///     Gets the value of the asset.
    /// </summary>
    public TValue Value
    {
        get
        {
            ObjectDisposedException.ThrowIf(Disposed, this);
            
            if (Unloaded)
            {
                throw new AssetLoadException();
            }

            return field;
        }
        internal set => field = value;
    }
    
    /// <summary>
    ///     Gets the state of the asset.
    /// </summary>
    public AssetState State { get; private set; }
    
    /// <summary>
    ///     Gets a value indicating whether the asset is unloaded.
    /// </summary>
    /// <value>
    ///     <see langword="true"/> if the asset is unloaded; otherwise, <see langword="false"/>.
    /// </value>
    public bool Unloaded => State == AssetState.Unloaded;
    
    /// <summary>
    ///     Gets a value indicating whether the asset is loaded.
    /// </summary>
    /// <value>
    ///     <see langword="true"/> if the asset is loaded; otherwise, <see langword="false"/>.
    /// </value>
    public bool Loaded => State == AssetState.Loaded;
    
    /// <summary>
    ///     Gets a value indicating whether the asset is loading.
    /// </summary>
    /// <value>
    ///     <see langword="true"/> if the asset is loading; otherwise, <see langword="false"/>.
    /// </value>
    public bool Loading => State == AssetState.Loading;
    
    /// <summary>
    ///     Gets a value indicating whether the asset is disposed.
    /// </summary>
    /// <value>
    ///     <see langword="true"/> if the asset is disposed; otherwise, <see langword="false"/>.
    /// </value>
    public bool Disposed => State == AssetState.Disposed;

    /// <summary>
    ///     Initializes a new instance of the <see cref="Asset{TValue}"/> class with the specified name.
    /// </summary>
    /// <param name="name">
    ///     The name of the asset.
    /// </param>
    public Asset(string name) : base(name) => Value = null!;

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

        State = AssetState.Disposed;
    }
    
    public static implicit operator TValue(Asset<TValue> asset) => asset.Value;
}