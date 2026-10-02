using System.Numerics;
using Silk.NET.Input;

namespace Venus;

public readonly ref struct KeyboardInputContext
{
    /// <summary>
    ///     Gets the keyboard that generated the input.
    /// </summary>
    public readonly required IKeyboard Keyboard { get; init; }

    /// <summary>
    ///     Gets the key associated with the input.
    /// </summary>
    public readonly required Key Key { get; init; }

    /// <summary>
    ///     Gets the scan code of the key associated with the input.
    /// </summary>
    public readonly required int Code { get; init; }
}

public sealed class KeyboardInput
{
    /// <summary>
    ///     Represents a callback that handles a keyboard input event.
    /// </summary>
    /// <param name="context">
    ///     The context associated with the keyboard input event.
    /// </param>
    public delegate void KeyboardInputCallback(in KeyboardInputContext context);
    
    /// <summary>
    ///     Occurs when a key is pressed.
    /// </summary>
    public event KeyboardInputCallback? OnKeyPress;
    
    /// <summary>
    ///     Occurs when a key is released.
    /// </summary>
    public event KeyboardInputCallback? OnKeyRelease;
    
    public KeyboardInput(IInputContext context)
    {
        for (var i = 0; i < context.Keyboards.Count; i++)
        {
            var keyboard = context.Keyboards[i];
            
            keyboard.KeyUp += Up;
            keyboard.KeyDown += Down;
        }
    }

    private void Up(IKeyboard keyboard, Key key, int code)
    {
        var context = new KeyboardInputContext
        {
            Keyboard = keyboard,
            Key = key,
            Code = code
        };
        
        OnKeyRelease?.Invoke(context);
    }

    private void Down(IKeyboard keyboard, Key key, int code)
    {
        var context = new KeyboardInputContext
        {
            Keyboard = keyboard,
            Key = key,
            Code = code
        };
        
        OnKeyPress?.Invoke(context);
    }
}

public readonly ref struct MouseInputContext
{
    /// <summary>
    ///     Gets the mouse that generated the input.
    /// </summary>
    public readonly required IMouse Mouse { get; init; }
    
    /// <summary>
    ///     Gets the mouse button associated with the input.
    /// </summary>
    public readonly required MouseButton Button { get; init; }
    
    /// <summary>
    ///     Gets the position of the mouse when the input occurred.
    /// </summary>
    public readonly required Vector2 Position { get; init; }
}

public sealed class MouseInput
{
    /// <summary>
    ///     Represents a callback that handles a mouse input event.
    /// </summary>
    /// <param name="context">
    ///     The context associated with the mouse input event.
    /// </param>
    public delegate void MouseInputCallback(in MouseInputContext context);
    
    /// <summary>
    ///     Occurs when a mouse button is clicked.
    /// </summary>
    public event MouseInputCallback? OnClick;
    
    public MouseInput(IInputContext context)
    {
        for (var i = 0; i < context.Mice.Count; i++)
        {
            var mouse = context.Mice[i];
            
            mouse.Click += Click;
        }
    }
    
    private void Click(IMouse mouse, MouseButton button, Vector2 position)
    {
        var context = new MouseInputContext
        {
            Mouse = mouse,
            Button = button,
            Position = position
        };
        
        OnClick?.Invoke(context);
    }
}