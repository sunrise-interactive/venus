namespace Venus.Examples;

public static class Program
{
    public static void Main()
    {
        using var game = new Example()
        {
            IsFixedTimeStep = false
        };
        
        game.Run();
    }
}