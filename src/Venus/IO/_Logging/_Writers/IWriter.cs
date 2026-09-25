namespace Venus.IO;

public interface IWriter
{
    /// <summary>
    ///     Writes a message.
    /// </summary>
    /// <param name="message">
    ///     The message to write.
    /// </param>
    void Write(string message);
}