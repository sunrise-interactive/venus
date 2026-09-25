namespace Venus;

public static class GameHooks
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public sealed class UpdateAttribute : Attribute;
}
