namespace Venus.IO;

public sealed class FileLogger : ILogger, IDisposable
{
    private readonly StreamWriter _writer;
    private readonly FileStream _stream;
    
    /// <summary>
    ///     Gets the path to the file logger.
    /// </summary>
    public string Path { get; }
    
    /// <summary>
    ///     Initializes a new instance of the <see cref="FileLogger"/> class with the specified path.
    /// </summary>
    /// <param name="path">
    ///     The path to the file logger.
    /// </param>
    /// <exception cref="ArgumentException">
    ///     <paramref name="path"/> is <see langword="null"/> or empty.
    /// </exception>
    public FileLogger(string path)
    {
        ArgumentException.ThrowIfNullOrEmpty(path);

        Path = path;
        
        _stream = new FileStream(path, FileMode.Append, FileAccess.Write, FileShare.Read);
        _writer = new StreamWriter(_stream);
    }
    
    /// <inheritdoc/>
    public void Log(string message)
    {
        _writer.WriteLine(message);
        _writer.Flush();
    }

    /// <summary>
    ///     Releases all resources used by the logger.
    /// </summary>
    public void Dispose()
    {
        _writer.Dispose();
        _stream.Dispose();
    }
}