using System.Runtime.CompilerServices;

namespace Venus.Graphics;

/// <summary>
///     Provides <see cref="Vector2"/> extensions.
/// </summary>
public static class Vector2Extensions
{
    extension(Vector2 vector)
    {
        /// <summary>
        ///     Converts the vector to a <see cref="Vector3"/>.
        /// </summary>
        /// <param name="z">
        ///     The z component of the vector.
        /// </param>
        /// <returns>
        ///     The converted <see cref="Vector3"/>.
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector3 ToVector3(float z = 0f) => new Vector3(vector.X, vector.Y, z);
        
        /// <summary>
        ///     Converts the vector to a <see cref="Vector4"/>.
        /// </summary>
        /// <param name="z">
        ///     The z component of the vector.
        /// </param>
        /// <param name="w">
        ///     The w component of the vector.
        /// </param>
        /// <returns>
        ///     The converted <see cref="Vector4"/>.
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector4 ToVector4(float z = 0f, float w = 0f) => new Vector4(vector.X, vector.Y, z, w);
    }
}