namespace Venus.Audio;

public sealed class AudioSystem : IDisposable
{
    private FMOD.Studio.System _system;

    /// <summary>
    ///     Gets the number of channels in the audio system.
    /// </summary>
    public int Channels { get; }
    
    /// <summary>
    ///     Initializes a new instance of the <see cref="AudioSystem"/> class with the specified number of channels.
    /// </summary>
    /// <param name="channels">
    ///     The number of channels in the audio system.
    /// </param>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     <paramref name="channels"/> is negative or zero.
    /// </exception>
    public AudioSystem(int channels)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(channels);

        Channels = channels;
    }

    /// <summary>
    ///     Initializes the audio system.
    /// </summary>
    /// <exception cref="AudioException">
    ///     
    /// </exception>
    public void Initialize()
    {
        var result = FMOD.Studio.System.create(out _system);

        if (result != FMOD.RESULT.OK)
        {
            throw new AudioException();
        }
        
        _system.initialize(Channels, FMOD.Studio.INITFLAGS.NORMAL, FMOD.INITFLAGS.NORMAL, IntPtr.Zero);
    }
    
    /// <summary>
    ///     Updates the audio system.
    /// </summary>
    public void Update() => _system.update();

    /// <summary>
    ///     Releases all resources used by the system.
    /// </summary>
    public void Dispose() => _system.release();
}