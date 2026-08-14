using System.Runtime.CompilerServices;

namespace Venus.Graphics;

public static class Vector3Extensions
{
    extension(Vector3 vector)
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector2 ToVector2() => new Vector2(vector.X, vector.Y);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector4 ToVector4(float w = 0f) => new Vector4(vector.X, vector.Y, vector.Z, w);
    }
}