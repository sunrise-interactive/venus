namespace Venus.Graphics;

public sealed class ShaderCompilationException : Exception
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="ShaderCompilationException"/> <see langword="class"/>.
    /// </summary>
    /// <param name="message">
    ///     The message that describes the exception.
    /// </param>
    public ShaderCompilationException(string? message) : base(message) { }
}