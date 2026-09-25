namespace Venus.Graphics;

public sealed class Camera
{
    public const float MINIMUM_ZOOM = 0.5f;
    
    public const float MAXIMUM_ZOOM = 2f;
    
    /// <summary>
    ///     The position of the camera.
    /// </summary>
    public Vector2 Position;

    /// <summary>
    ///     The zoom level of the camera.
    /// </summary>
    public float Zoom
    {
        get => field;
        set => field = Math.Clamp(value, MINIMUM_ZOOM, MAXIMUM_ZOOM);
    } = 1f;

    public Matrix World => Matrix.CreateTranslation(new Vector3(Position.X, -Position.Y, 0f));
    
    /// <summary>
    ///     Gets the scale matrix of the camera.
    /// </summary>
    public Matrix View => Matrix.CreateScale(Zoom);
    
    /// <summary>
    ///     Gets the projection matrix of the camera.
    /// </summary>
    public Matrix Projection => Matrix.CreateOrthographicOffCenter
    (
        0f,
        Screen.Width,
        Screen.Height,
        0f,
        0f,
        1f
    );
 
    public Matrix Transform => Matrix.CreateTranslation(-Screen.Width / 2f, -Screen.Height / 2f, 0f) * View * Matrix.CreateTranslation(Screen.Width / 2f, Screen.Height / 2f, 0f) * World;
}