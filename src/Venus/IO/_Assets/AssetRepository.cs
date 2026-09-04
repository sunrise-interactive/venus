namespace Venus.IO;

public sealed class AssetRepository : IDisposable
{
    /// <summary>
    ///     Gets a value indicating whether the repository has been disposed.
    /// </summary>
    /// <value>
    ///     <see langword="true"/> if the repository has been disposed; otherwise, <see langword="false"/>.
    /// </value>
    public bool IsDisposed { get; private set; }

    /// <summary>
    ///     Gets a value indicating whether the repository is running on the main thread.
    /// </summary>
    /// <value>
    ///     <see langword="true"/> if the repository is running on the main thread; otherwise, <see langword="false"/>.
    /// </value>
    public bool IsMainThread => GameEngine.IsMainThread;

    /// <summary>
    ///     Releases all resources used by the repository.
    /// </summary>
    public void Dispose()
    {
        if (IsDisposed)
        {
            return;
        }

        IsDisposed = true;
    }
}