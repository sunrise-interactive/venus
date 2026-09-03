namespace Venus.IO;

public interface IAssetSource
{
    Stream Open(string path);
    
    /// <summary>
    ///     Determines whether the specified asset exists in the source.
    /// </summary>
    /// <param name="path">
    ///     The path to the asset.
    /// </param>
    /// <returns>
    ///     <see langword="true"/> if the asset exists; otherwise, <see langword="false"/>.
    /// </returns>
    bool Exists(string path);
    
    /// <summary>
    ///     Resolves the specified asset name to a full path in the source.
    /// </summary>
    /// <param name="path">
    ///     The name of the asset.
    /// </param>
    /// <returns>
    ///     The full path to the asset.
    /// </returns>
    string Resolve(string path);
}