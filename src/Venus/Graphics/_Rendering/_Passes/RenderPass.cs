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

public interface IRenderPass
{
    /// <summary>
    ///     Gets or sets a value indicating whether the render pass is enabled.
    /// </summary>
    /// <value>
    ///     <see langword="true"/> if the render pass is enabled; otherwise, <see langword="false"/>.
    /// </value>
    bool Enabled { get; set; }

    /// <summary>
    ///     Executes the render pass with the specified context.
    /// </summary>
    /// <param name="context">
    ///     The context for the render pass execution.
    /// </param>
    void Execute(in RenderPassContext context);
}

public abstract class RenderPass : IRenderPass
{
    /// <inheritdoc/> 
    public bool Enabled { get; set; } = true;
    
    /// <inheritdoc/> 
    public abstract void Execute(in RenderPassContext context);
}