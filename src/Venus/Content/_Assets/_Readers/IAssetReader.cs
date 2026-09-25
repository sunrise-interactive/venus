namespace Venus.Content;

public interface IAssetReader<TValue> where TValue : class
{
    TValue Read(Stream stream);
}