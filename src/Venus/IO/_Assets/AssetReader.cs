namespace Venus.IO;

public abstract class AssetReader<TValue> where TValue : class
{
    public abstract TValue Read(string path);
}