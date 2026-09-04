namespace Venus.IO;

public readonly struct AssetHandle
{
    /// <summary>
    ///     
    /// </summary>
    public static readonly AssetHandle Invalid = new(ulong.MaxValue);
    
    /// <summary>
    ///     The handle of the asset handle.
    /// </summary>
    public readonly ulong Handle;
    
    /// <summary>
    ///     Gets a value indicating whether the asset handle is valid.
    /// </summary>
    /// <value>
    ///     <see langword="true"/> if the asset handle is valid; otherwise, <see langword="false"/>.
    /// </value>
    public bool Valid => Handle != ulong.MaxValue;

    /// <summary>
    ///     Initializes a new instance of the <see cref="AssetHandle"/> struct with the specified handle.
    /// </summary>
    /// <param name="handle">
    ///     The handle of the asset handle.
    /// </param>
    internal AssetHandle(ulong handle) => Handle = handle;
}