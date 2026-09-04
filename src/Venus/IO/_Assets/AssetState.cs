namespace Venus.IO;

public enum AssetState : byte
{
    /// <summary>
    ///     The asset failed to load.
    /// </summary>
    Failed,
    
    /// <summary>
    ///     The asset is unloaded.
    /// </summary>
    Unloaded,
    
    /// <summary>
    ///     The asset is loading.
    /// </summary>
    Loading,
    
    /// <summary>
    ///     The asset is loaded.
    /// </summary>
    Loaded,
    
    /// <summary>
    ///     The asset has been disposed.
    /// </summary>
    Disposed
}