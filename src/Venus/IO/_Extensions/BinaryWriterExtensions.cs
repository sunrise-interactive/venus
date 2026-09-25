namespace Venus.IO;

/// <summary>
///     Provides <see cref="BinaryWriter"/> extensions.
/// </summary>
public static class BinaryWriterExtensions
{
    extension(BinaryWriter writer)
    {
        public void Write(Vector2 vector)
        {
            writer.Write(vector.X);
            writer.Write(vector.Y);
        }

        public void Write(Vector3 vector)
        {
            writer.Write(vector.X);
            writer.Write(vector.Y);
            writer.Write(vector.Z);
        }

        public void Write(Vector4 vector)
        {
            writer.Write(vector.X);
            writer.Write(vector.Y);
            writer.Write(vector.Z);
            writer.Write(vector.W);
        }

        public void Write(Rectangle rectangle)
        {
            writer.Write(rectangle.X);
            writer.Write(rectangle.Y);

            writer.Write(rectangle.Width);
            writer.Write(rectangle.Height);
        }
    }
}