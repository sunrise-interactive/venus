namespace Venus.Graphics;

public readonly ref struct RenderPassContext
{
    /// <summary>
    ///     Gets the input render target for the render pass.
    /// </summary>
    public readonly required RenderTarget2D Input { get; init; }
    
    /// <summary>
    ///     Gets the output render target for the render pass.
    /// </summary>
    public readonly required RenderTarget2D Output { get; init; }
}