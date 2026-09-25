namespace Venus.Graphics;

public interface IRenderPass
{
    /// <summary>
    ///     Gets or sets a value indicating whether the render pass is enabled.
    /// </summary>
    /// <value>
    ///     <see langword="true"/> if the render pass is enabled; otherwise, <see langword="false"/>.
    /// </value>
    bool IsEnabled { get; set; }

    /// <summary>
    ///     Executes the render pass with the specified context.
    /// </summary>
    /// <param name="context">
    ///     The context for the render pass execution.
    /// </param>
    void Execute(in RenderPassContext context);
}