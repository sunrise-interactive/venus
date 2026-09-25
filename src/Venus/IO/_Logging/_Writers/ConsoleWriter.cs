namespace Venus.IO;

public sealed class ConsoleWriter : IWriter
{
    /// <summary>
    ///     Writes a message to the console.
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

        Console.WriteLine(message);
    }
}