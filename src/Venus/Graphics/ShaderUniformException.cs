namespace Venus.Graphics;

public sealed class ShaderUniformException : Exception
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="ShaderUniformException"/> <see langword="class"/>.
    /// </summary>
    /// <param name="message">
    ///     The message that describes the exception.
    /// </param>
    public ShaderUniformException(string? message) : base(message) { }
}