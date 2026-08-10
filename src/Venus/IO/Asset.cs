namespace Venus.IO;

public sealed class Asset<TValue> : IDisposable where TValue : class
{
    /// <summary>
    ///     Gets the value of the asset.
    /// </summary>
    public TValue Value { get; }
    
    /// <summary>
    ///     Gets the state of the asset.
    /// </summary>
    public AssetState State { get; private set; }
    
    internal Asset(TValue value)
    {
        ArgumentNullException.ThrowIfNull(value);

        Value = value;
    }

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