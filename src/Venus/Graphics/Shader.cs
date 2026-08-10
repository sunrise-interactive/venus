namespace Venus.Graphics;

public sealed class Shader : GraphicsResource
{
    /// <summary>
    ///     Gets the path of the shader.
    /// </summary>
    public string Path { get; }
    
    public Shader(string path)
    {
        ArgumentException.ThrowIfNullOrEmpty(path);

        Path = path;

        Handle = Graphics.CreateProgram();
        
        Graphics.LinkProgram(Handle);
    }

    public void Set(string name, float value)
    {
        ArgumentException.ThrowIfNullOrEmpty(name);
        
        var location = Graphics.GetUniformLocation(Handle, name);

        if (location == -1)
        {
            throw new ShaderUniformException($"The uniform '{name}' was not found in the shader program.");
        }
        
        Graphics.Uniform1(location, value);
    }

    public void Use() => Graphics.UseProgram(Handle);

    protected override void Dispose(bool disposing) => Graphics.DeleteProgram(Handle);
}