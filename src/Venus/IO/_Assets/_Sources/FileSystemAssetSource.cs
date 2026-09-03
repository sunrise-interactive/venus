namespace Venus.IO;

public sealed class FileSystemAssetSource : IAssetSource
{
    private const NotifyFilters NOTIFY_FILTERS = NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName | NotifyFilters.Size;

    /// <summary>
    ///     Gets the path to the asset source.
    /// </summary>
    public string Root { get; }
    
    /// <summary>
    ///     Gets a value indicating whether the asset source is disposed.
    /// </summary>
    /// <value>
    ///     <see langword="true"/> if the asset source is disposed; otherwise, <see langword="false"/>.
    /// </value>
    public bool Disposed { get; private set; }
    
    /// <summary>
    ///     Initializes a new instance of the <see cref="FileSystemAssetSource"/> class with the specified path.
    /// </summary>
    /// <param name="root">
    ///     The path to the asset source.
    /// </param>
    /// <exception cref="ArgumentException">
    ///     <paramref name="root"/> is <see langword="null"/> or empty.
    /// </exception>
    public FileSystemAssetSource(string root)
    {
        ArgumentException.ThrowIfNullOrEmpty(root);
        
        Root = root;
    }

    /// <inheritdoc/>
    public Stream Open(string path) => File.Open(Resolve(path), FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
    
    /// <inheritdoc/>
    public bool Exists(string path) => File.Exists(Resolve(path));

    /// <inheritdoc/>
    public string Resolve(string path) => path;
}