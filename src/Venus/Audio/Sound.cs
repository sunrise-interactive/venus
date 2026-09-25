using System.Runtime.InteropServices;

namespace Venus.Audio;

public sealed class Sound : IDisposable
{
    private GCHandle _handle;
    
    /// <summary>
    ///     
    /// </summary>
    internal FMOD.Sound Native { get; }

    /// <summary>
    ///     
    /// </summary>
    /// <param name="native">
    ///     
    /// </param>
    internal Sound(FMOD.Sound native)
    {
        _handle = GCHandle.Alloc(this);
        
        Native = native;
        Native.setUserData(GCHandle.ToIntPtr(_handle));
    }

    /// <summary>
    ///     Releases all resources used by the sound.
    /// </summary>
    public void Dispose()
    {
        _handle.Free();
        
        Native.release();
    }
}