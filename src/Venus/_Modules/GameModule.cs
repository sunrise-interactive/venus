namespace Venus;

public abstract class GameModule
{
    /// <summary>
    ///     Gets or sets a value indicating whether the game module is enabled.
    /// </summary>
    /// <value>
    ///     <see langword="true"/> if the game module is enabled; otherwise, <see langword="false"/>.
    /// </value>
    public bool Enabled { get; set; } = true;
    
    internal virtual void Update(GameTime gameTime) { }
}