using System.Runtime.CompilerServices;

namespace Venus.Graphics;

public static class Vector2Extensions
{
    extension(Vector2 vector)
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector3 ToVector3(float z = 0f) => new Vector3(vector.X, vector.Y, z);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector4 ToVector4(float z = 0f, float w = 0f) => new Vector4(vector.X, vector.Y, z, w);
    }
}