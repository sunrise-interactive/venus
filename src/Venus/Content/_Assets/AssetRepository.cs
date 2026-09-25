namespace Venus.Content;

public sealed class AssetRepository
{
    private readonly Dictionary<string, ulong> _handles = [];

    public TValue Request<TValue>(string name) => GameInstance.Instance.Content.Load<TValue>(name);
}