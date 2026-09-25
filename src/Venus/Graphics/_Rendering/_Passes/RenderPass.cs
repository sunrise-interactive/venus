namespace Venus.Graphics;

public abstract class RenderPass : IRenderPass
{
    /// <inheritdoc/> 
    public bool IsEnabled { get; set; } = true;
    
    /// <inheritdoc/> 
    public abstract void Execute(in RenderPassContext context);
}