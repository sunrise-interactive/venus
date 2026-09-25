namespace Venus.IO;

public sealed class Log : IDisposable
{
    private readonly IWriter[] _writers;

    /// <summary>
    ///     Initializes a new instance of the <see cref="Log"/> class with the specified writers.
    /// </summary>
    /// <param name="writers">
    ///     
    /// </param>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="writers"/> is <see langword="null"/>.
    /// </exception>
    public Log(params IWriter[] writers)
    {
        ArgumentNullException.ThrowIfNull(writers);
        
        _writers = writers;
    }

    public void Dispose()
    {
        foreach (var writer in _writers)
        {
            if (writer is not IDisposable disposable)
            {
                continue;
            }
            
            disposable.Dispose();
        }
    }
}