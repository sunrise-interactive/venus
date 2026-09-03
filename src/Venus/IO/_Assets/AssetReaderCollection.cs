namespace Venus.IO;

public sealed class AssetReaderCollection : IDisposable
{
    /// <summary>
    ///     Gets a value indicating whether the collection has been disposed.
    /// </summary>
    /// <value>
    ///     <see langword="true"/> if the collection has been disposed; otherwise, <see langword="false"/>.
    /// </value>
    public bool Disposed { get; private set; }
    
    public void Dispose()
    {
        if (Disposed)
        {
            return;
        }
        
        Disposed = true;
    }
}