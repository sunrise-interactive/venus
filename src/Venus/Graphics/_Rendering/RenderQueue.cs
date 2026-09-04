using System.Runtime.InteropServices;

namespace Venus.Graphics;

public sealed class RenderQueue
{
    private readonly List<RenderCommand> _commands;
    
    /// <summary>
    ///     Gets a read-only span of the render commands in the queue.
    /// </summary>
    public ReadOnlySpan<RenderCommand> Commands => CollectionsMarshal.AsSpan(_commands);
    
    /// <summary>
    ///     Gets the number of render commands in the queue.
    /// </summary>
    public int Count => _commands.Count;

    /// <summary>
    ///     Initializes a new instance of the <see cref="RenderQueue"/> class with the specified capacity.
    /// </summary>
    /// <param name="capacity">
    ///     The initial capacity of the render queue.
    /// </param>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     <paramref name="capacity"/> is negative.
    /// </exception>
    public RenderQueue(int capacity)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(capacity);

        _commands = new List<RenderCommand>(capacity);
    }
    
    /// <summary>
    ///     Clears all render commands from the queue.
    /// </summary>
    public void Clear() => _commands.Clear();
    
    /// <summary>
    ///     Submits a render command to the queue.
    /// </summary>
    /// <param name="command">
    ///     The render command to submit.
    /// </param>
    public void Submit(RenderCommand command) => _commands.Add(command);
}