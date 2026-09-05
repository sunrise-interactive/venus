using System.Runtime.InteropServices;
using Venus.Graphics;

namespace Venus.Examples;

public sealed class Example : GameInstance
{
    private const int AMOUNT = 10000;
    
    private static readonly Particle[] _particles = new Particle[AMOUNT];

    private static SpriteBatch _batch;
    
    private static Texture2D _texture;

    private static RenderTarget2D _buffer;
    
    protected override void Initialize()
    {
        base.Initialize();

        var random = new Random();
        
        for (var i = 0; i < AMOUNT; i++)
        {
            _particles[i] = new Particle
            {
                Position = new Vector2(random.Next(0, Screen.Width), random.Next(0, Screen.Height)),
                Velocity = new Vector2((float)(random.NextDouble() - 0.5) * 2f, (float)(random.NextDouble() - 0.5) * 2f),
                Color = Color.White
            };
        }
    }

    protected override void LoadContent()
    {
        base.LoadContent();

        _buffer = new RenderTarget2D(GraphicsDevice, Screen.Width / 2, Screen.Height / 2);
        _batch = new SpriteBatch(GraphicsDevice);
        
        _texture = Content.Load<Texture2D>("Assets/Images/Particle");
    }

    protected override void Update(GameTime gameTime)
    {
        base.Update(gameTime);

        var time = (float)gameTime.TotalGameTime.TotalSeconds;
        
        for (var i = 0; i < AMOUNT; i++)
        {
            ref var particle = ref _particles[i];

            particle.Position += particle.Velocity;
            
            particle.Velocity.X += MathF.Cos(time * 2f + i) * 0.01f;
            particle.Velocity.Y += MathF.Sin(time * 2f - i) * 0.01f;
            
            var x = particle.Position.X / Screen.Width;
            var y = particle.Position.Y / Screen.Height;

            particle.Color = new Color(x, y, 1f - x);
        }
    }

    protected override void Draw(GameTime gameTime)
    {
        base.Draw(gameTime);
        
        GraphicsDevice.SetRenderTarget(_buffer);
        GraphicsDevice.Clear(Color.Transparent);
        
        _batch.Begin(default, default, SamplerState.PointClamp, default, RasterizerState.CullNone, default, Matrices.Sizes.Half);

        for (var i = 0; i < AMOUNT; i++)
        {
            ref readonly var particle = ref _particles[i];
            
            _batch.Draw(_texture, particle.Position, particle.Color);
        }
        
        _batch.End();
        
        GraphicsDevice.SetRenderTarget(null);
        GraphicsDevice.Clear(Color.Transparent);
        
        _batch.Begin(default, default, SamplerState.PointClamp, default, RasterizerState.CullNone);
        
        _batch.Draw(_buffer, Screen.Bounds, Color.White);
        
        _batch.End();
    }
}

public struct Particle
{
    public Vector2 Position;

    public Vector2 Velocity;

    public Color Color;
}