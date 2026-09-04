using System.Runtime.InteropServices;

namespace Venus.Graphics;

public enum RenderCommandType : byte
{
    /// <summary>
    ///     The command is a sprite.
    /// </summary>
    Sprite
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
}