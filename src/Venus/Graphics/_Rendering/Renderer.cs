namespace Venus.Graphics;

public sealed class Renderer : IDisposable
{
    private readonly RenderQueue _queue = new(1024);
    
    /// <summary>
    ///     Gets the number of render commands in the renderer's queue.
    /// </summary>
    public int Count => _queue.Count;
    
    /// <summary>
    ///     Gets the graphics device used for rendering.
    /// </summary>
    public GraphicsDevice Device { get; }
    
    /// <summary>
    ///     Gets the sprite batch used for rendering.
    /// </summary>
    public SpriteBatch Batch { get; }
    
    /// <summary>
    ///     Gets a value indicating whether the renderer has been disposed.
    /// </summary>
    /// <value>
    ///     <see langword="true"/> if the renderer has been disposed; otherwise, <see langword="false"/>.
    /// </value>
    public bool Disposed { get; private set; }

    /// <summary>
    ///     Initializes a new instance of the <see cref="Renderer"/> class with the specified sprite batch.
    /// </summary>
    /// <param name="batch">
    ///     The sprite batch to use for rendering.
    /// </param>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="batch"/> is <see langword="null"/>.
    /// </exception>
    public Renderer(SpriteBatch batch)
    {
        ArgumentNullException.ThrowIfNull(batch);

        Batch = batch;
        Device = batch.GraphicsDevice;
    }
    
    /// <summary>
    ///     Submits a sprite to the renderer for rendering.
    /// </summary>
    /// <param name="sprite">
    ///     The sprite to submit for rendering.
    /// </param>
    public void Submit(in Sprite sprite) => _queue.Submit(new RenderCommand(in sprite));
    
    public void Flush()
    {
        foreach (ref readonly var command in _queue.Commands)
        {
            switch (command.Type)
            {
                case RenderCommandType.Sprite:
                    Draw(in command.Sprite);
                    break;
            }
        }
    }

    /// <summary>
    ///     Clears all render commands from the renderer.
    /// </summary>
    public void Clear() => _queue.Clear();

    /// <summary>
    ///     Releases all resources used by the renderer.
    /// </summary>
    public void Dispose()
    {
        if (Disposed)
        {
            return;
        }
        
        _queue.Clear();
        
        Disposed = true;
    }

    private void Draw(in Sprite sprite) => Batch.Draw(null, sprite.Position, sprite.Frame, sprite.Color * sprite.Opacity, sprite.Rotation, sprite.Origin, sprite.Scale, sprite.Effects, 0f);
}