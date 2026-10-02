using Silk.NET.Maths;
using Silk.NET.Windowing;

namespace Venus.Examples;

public sealed class Venus : Game
{
    protected override void Configure(ref WindowOptions options)
    {
        base.Configure(ref options);

        options.Size = new Vector2D<int>(1280, 720);
        options.Title = "Venus";
    }

    protected override void Render(double delta)
    {
        base.Render(delta);

        
    }
}