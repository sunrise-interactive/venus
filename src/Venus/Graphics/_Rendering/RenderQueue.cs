using System.Runtime.InteropServices;

namespace Venus.Graphics;

public sealed class RenderQueue
{
    private readonly List<RenderCommand> _commands = [];
    
    /// <summary>
    ///     Gets a read-only span of the render commands in the queue.
    /// </summary>
    public ReadOnlySpan<RenderCommand> Commands => CollectionsMarshal.AsSpan(_commands);
    
    /// <summary>
    ///     Gets the number of render commands in the queue.
    /// </summary>
    public int Count => _commands.Count;
    
    /// <summary>
    ///     Clears all render commands from the queue.
    /// </summary>
    public void Clear() => _commands.Clear();
    
    /// <summary>
    ///     Adds a render command to the queue.
    /// </summary>
    /// <param name="command">
    ///     The render command to add.
    /// </param>
    public void Add(RenderCommand command) => _commands.Add(command);
}