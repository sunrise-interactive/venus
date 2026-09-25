namespace Venus.Mathematics;

public static class Interpolation
{
    /// <summary>
    ///     Interpolates between two values using linear interpolation.
    /// </summary>
    /// <param name="start">
    ///     The starting value.
    /// </param>
    /// <param name="end">
    ///     The ending value.
    /// </param>
    /// <param name="amount">
    ///     The amount of interpolation.
    /// </param>
    /// <returns>
    ///     The interpolated value.
    /// </returns>
    public static float Linear(float start, float end, float amount) => start + (end - start) * Math.Clamp(amount, 0f, 1f);
}