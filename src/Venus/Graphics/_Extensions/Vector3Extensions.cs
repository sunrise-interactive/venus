using System.Runtime.CompilerServices;

namespace Venus.Graphics;

/// <summary>
///     Provides <see cref="Vector3"/> extensions.
/// </summary>
public static class Vector3Extensions
{
    extension(Vector3 vector)
    {
        /// <summary>
        ///     Converts the vector to a <see cref="Vector2"/>.
        /// </summary>
        /// <remarks>
        ///     The z component of the vector will be discarded.
        /// </remarks>
        /// <returns>
        ///     The converted <see cref="Vector2"/>.
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector2 ToVector2() => new Vector2(vector.X, vector.Y);
        
        /// <summary>
        ///     Converts the vector to a <see cref="Vector4"/>.
        /// </summary>
        /// <param name="w">
        ///     The w component of the vector.
        /// </param>
        /// <returns>
        ///     The converted <see cref="Vector4"/>.
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector4 ToVector4(float w = 0f) => new Vector4(vector.X, vector.Y, vector.Z, w);
    }
}