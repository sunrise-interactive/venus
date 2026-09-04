using System.Runtime.InteropServices;

namespace Venus.Graphics;

public enum RenderCommandType : byte
{
    /// <summary>
    ///     The command is a sprite.
    /// </summary>
    Sprite,
    
    /// <summary>
    ///     The command is a box.
    /// </summary>
    Box
}

[StructLayout(LayoutKind.Explicit)]
public readonly struct RenderCommand
{
    /// <summary>
    ///     The type of the command.
    /// </summary>
    [FieldOffset(0)]
    public readonly RenderCommandType Type;
    
    /// <summary>
    ///     The sprite of the command.
    /// </summary>
    [FieldOffset(4)]
    public readonly Sprite Sprite;

    /// <summary>
    ///     The box of the command.
    /// </summary>
    [FieldOffset(4)]
    public readonly Box Box;
    
    /// <summary>
    ///     Initializes a new instance of the <see cref="RenderCommand"/> struct with the specified sprite.
    /// </summary>
    /// <param name="sprite">
    ///     The sprite of the command.
    /// </param>
    public RenderCommand(in Sprite sprite)
    {
        Sprite = sprite;

        Type = RenderCommandType.Sprite;
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="RenderCommand"/> struct with the specified box.
    /// </summary>
    /// <param name="box">
    ///     The box of the command.
    /// </param>
    public RenderCommand(in Box box)
    {
        Box = box;
        
        Type = RenderCommandType.Box;
    }
}