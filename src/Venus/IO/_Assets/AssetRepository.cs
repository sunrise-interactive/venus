namespace Venus.IO;

public sealed class AssetRepository : IDisposable
{
    private static class AssetData<TValue> where TValue : class
    {
        public static readonly Dictionary<string, Asset<TValue>> Assets = [];

        public static IAssetReader<TValue> Reader;
    }

    private readonly List<IAssetSource> sources = [];
    
    /// <summary>
    ///     Gets a value indicating whether the asset repository has been disposed.
    /// </summary>
    /// <value>
    ///     <see langword="true"/> if the asset repository has been disposed; otherwise, <see langword="false"/>.
    /// </value>
    public bool Disposed { get; private set; }
    
    /// <summary>
    ///     Gets the list of asset sources in the repository.
    /// </summary>
    public IReadOnlyList<IAssetSource> Sources => sources;
    
    /// <summary>
    ///     Adds an asset source to the repository.
    /// </summary>
    /// <param name="source">
    ///     The asset source to add.
    /// </param>
    /// <typeparam name="TSource">
    ///     The type of the asset source to add.
    /// </typeparam>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="source"/> is <see langword="null"/>.
    /// </exception>
    public void Add<TSource>(TSource source) where TSource : IAssetSource
    {
        ArgumentNullException.ThrowIfNull(source);
        
        sources.Add(source);
    }

    public void Add<TValue>(IAssetReader<TValue> reader) where TValue : class
    {
        ArgumentNullException.ThrowIfNull(reader);
        
        AssetData<TValue>.Reader = reader;
    }
    
    /// <summary>
    ///     Requests an asset with the specified name from the repository.
    /// </summary>
    /// <param name="name">
    ///     The name of the asset to request.
    /// </param>
    /// <typeparam name="TValue">
    ///     The type of the asset to request.
    /// </typeparam>
    /// <returns>
    ///     
    /// </returns>
    /// <exception cref="ArgumentException">
     ///     <paramref name="name"/> is <see langword="null"/> or empty.
    /// </exception>
    public Asset<TValue> Request<TValue>(string name) where TValue : class
    {
        ArgumentException.ThrowIfNullOrEmpty(name);

        return AssetData<TValue>.Assets.TryGetValue(name, out var asset) ? asset : Load<TValue>(name);
    }

    public Asset<TValue> Load<TValue>(string name) where TValue : class
    {
        ArgumentException.ThrowIfNullOrEmpty(name);
        
        var reader = AssetData<TValue>.Reader;
        
        foreach (var source in Sources)
        {
            if (!source.Exists(name))
            {
                continue;
            }

            var asset = new Asset<TValue>(name)
            {
                Value = reader.Read(source.Open(name))
            };
            
            return AssetData<TValue>.Assets[name] = asset;
        }

        return null;
    }
    
    public void Dispose()
    {
        if (Disposed)
        {
            return;
        }

        Disposed = true;
    }
}