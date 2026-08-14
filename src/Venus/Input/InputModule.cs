using System.Runtime.CompilerServices;
using Microsoft.Xna.Framework.Input;

namespace Venus.Input;

public sealed class InputModule : GameModule
{
    public static class Mouse
    {
        /// <summary>
        ///     Gets the current state of the mouse input.
        /// </summary>
        public static MouseState Current { get; private set; }
        
        /// <summary>
        ///     Gets the previous state of the mouse input.
        /// </summary>
        public static MouseState Previous { get; private set; }

        /// <summary>
        ///     Gets or sets the position of the mouse, in screen coordinates.
        /// </summary>
        public static Vector2 Position
        {
            get => new Vector2(Current.X, Current.Y);
            set => Microsoft.Xna.Framework.Input.Mouse.SetPosition((int)value.X, (int)value.Y);
        }
        
        /// <summary>
        ///     Gets the current value of the mouse scroll wheel.
        /// </summary>
        public static int Wheel => Current.ScrollWheelValue;
        
        internal static void Update()
        {
            Previous = Current;
            Current = Microsoft.Xna.Framework.Input.Mouse.GetState();
        }
    }
    
    public static class Keyboard
    {
        /// <summary>
        ///     Gets the current state of the keyboard input.
        /// </summary>
        public static KeyboardState Current { get; private set; }
        
        /// <summary>
        ///     Gets the previous state of the keyboard input.
        /// </summary>
        public static KeyboardState Previous { get; private set; }

        internal static void Update()
        {
            Previous = Current;
            Current = Microsoft.Xna.Framework.Input.Keyboard.GetState();
        }

        /// <summary>
        ///     Determines whether the specified key is currently pressed.
        /// </summary>
        /// <param name="key">
        ///     The key to check.
        /// </param>
        /// <returns>
        ///     <see langword="true"/> if the specified key is currently pressed; otherwise, <see langword="false"/>.
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Pressed(Keys key) => Current.IsKeyDown(key);

        /// <summary>
        ///     Determines whether the specified key is currently released.
        /// </summary>
        /// <param name="key">
        ///     The key to check.
        /// </param>
        /// <returns>
        ///     <see langword="true"/> if the specified key is currently released; otherwise, <see langword="false"/>.
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Released(Keys key) => Previous.IsKeyUp(key);
        
        /// <summary>
        ///     Determines whether the specified key was just pressed.
        /// </summary>
        /// <param name="key">
        ///     The key to check.
        /// </param>
        /// <returns>
        ///     <see langword="true"/> if the specified key was just pressed; otherwise, <see langword="false"/>.
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool JustPressed(Keys key) => Current.IsKeyDown(key) && Previous.IsKeyUp(key);

        /// <summary>
        ///     Determines whether the specified key was just released.
        /// </summary>
        /// <param name="key">
        ///     The key to check.
        /// </param>
        /// <returns>
        ///     <see langword="true"/> if the specified key was just released; otherwise, <see langword="false"/>.
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool JustReleased(Keys key) => Current.IsKeyUp(key) && Previous.IsKeyDown(key);
    }

    internal override void Update(GameTime gameTime)
    {
        base.Update(gameTime);
        
        Mouse.Update();
        Keyboard.Update();
    }
}