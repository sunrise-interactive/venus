using Venus.Hooks;

namespace Venus;

public static class MainThread
{
    private static int thread;
    
    /// <summary>
    ///     Gets a value indicating whether the current thread is the main thread.
    /// </summary>
    /// <value>
    ///     <see langword="true"/> if the current thread is the main thread; otherwise, <see langword="false"/>.
    /// </value>
    public static bool Current => thread == Thread.CurrentThread.ManagedThreadId;
    
    [GameHooks.Load]
    private static void Load() => thread = Environment.CurrentManagedThreadId;
}