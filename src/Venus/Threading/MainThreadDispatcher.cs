using System.Collections.Concurrent;

namespace Venus.Threading;

public static class MainThreadDispatcher
{
    private static readonly ConcurrentQueue<Action> queue = [];

    /// <summary>
    ///     Enqueues an action to be executed on the main thread.
    /// </summary>
    /// <param name="action">
    ///     The action to be executed on the main thread.
    /// </param>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="action"/> is <see langword="null"/>.
    /// </exception>
    public static void Enqueue(Action action)
    {
        ArgumentNullException.ThrowIfNull(action);
        
        queue.Enqueue(action);
    }

    /// <summary>
    ///     Dispatches all queued actions for execution on the main thread.
    /// </summary>
    /// <exception cref="ArgumentNullException">
    ///     <see cref="queue"/> is <see langword="null"/>.
    /// </exception>
    internal static void Dispatch()
    {
        ArgumentNullException.ThrowIfNull(queue);
        
        MainThread.Verify();
        
        while (queue.TryDequeue(out var action))
        {
            action();
        }
    }
}