namespace Venus;

public static class GameEngine
{
    private static int _mainThread;
    
    /// <summary>
    ///     Gets a value indicating whether the game engine is initialized.
    /// </summary>
    /// <value>
    ///     <see langword="true"/> if the game engine is initialized; otherwise, <see langword="false"/>.
    /// </value>
    public static bool IsInitialized { get; private set; }

    /// <summary>
    ///     Gets a value indicating whether the game engine is running on the main thread.
    /// </summary>
    /// <value>
    ///     <see langword="true"/> if the game engine is running on the main thread; otherwise, <see langword="false"/>.
    /// </value>
    public static bool IsMainThread => Thread.CurrentThread.ManagedThreadId == _mainThread;

    /// <summary>
    /// 
    /// </summary>
    /// <exception cref="InvalidOperationException">
    ///
    /// </exception>
    public static void Initialize()
    {
        if (IsInitialized)
        {
            throw new InvalidOperationException();
        }
        
        _mainThread = Thread.CurrentThread.ManagedThreadId;
        
        IsInitialized = true;
    }
}