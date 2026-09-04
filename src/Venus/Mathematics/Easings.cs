using System.Runtime.CompilerServices;

namespace Venus.Mathematics;

public static class Easings
{
    public static class Quadratic
    {
        /// <summary>
        ///     Applies a quadratic easing function to the input value.
        /// </summary>
        /// <param name="t">
        ///     The normalized input value to ease.
        /// </param>
        /// <returns>
        ///     The eased value.
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float In(float t) => t * t;

        /// <summary>
        ///     Applies a quadratic easing function to the input value in reverse.
        /// </summary>
        /// <param name="t">
        ///     The normalized input value to ease.
        /// </param>
        /// <returns>
        ///     The eased value.
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Out(float t) => 1f - In(1f - t);
    }

    public static class Cubic
    {
        /// <summary>
        ///     Applies a cubic easing function to the input value.
        /// </summary>
        /// <param name="t">
        ///     The normalized input value to ease.
        /// </param>
        /// <returns>
        ///     The eased value.
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float In(float t) => t * t * t;

        /// <summary>
        ///     Applies a cubic easing function to the input value in reverse.
        /// </summary>
        /// <param name="t">
        ///     The normalized input value to ease.
        /// </param>
        /// <returns>
        ///     The eased value.
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Out(float t) => 1f - In(1f - t);
    }
}