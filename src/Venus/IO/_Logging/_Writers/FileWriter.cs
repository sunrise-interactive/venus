namespace Venus.IO;

public sealed class FileWriter : IWriter, IFlush, IDisposable
{
    private readonly StreamWriter _writer;
    
    /// <summary>
    ///     Initializes a new instance of the <see cref="FileWriter"/> class with the specified path.
    /// </summary>
    /// <param name="path">
    ///     The path to the file to write to.
    /// </param>
    /// <exception cref="ArgumentException">
    ///     <paramref name="path"/> is null or empty.
    /// </exception>
    public FileWriter(string path)
    {
        ArgumentException.ThrowIfNullOrEmpty(path);

        _writer = new StreamWriter(path, false);
    }

    /// <summary>
    ///     Writes a message to the file.
    /// </summary>
    /// <param name="message">
    ///     The message to write.
    /// </param>
    /// <exception cref="ArgumentException">
    ///     <paramref name="message"/> is <see langword="null"/> or empty.
    /// </exception>
    public void Write(string message)
    {
        ArgumentException.ThrowIfNullOrEmpty(message);
        
        _writer.Write(message);
    }
    
    /// <summary>
    /// 
    /// </summary>
    public void Flush() => _writer.Flush();

    /// <summary>
    ///     Releases all resources used by the writer.
    /// </summary>
    public void Dispose() => _writer.Dispose();
}