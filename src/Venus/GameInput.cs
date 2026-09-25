using JetBrains.Annotations;
using Microsoft.Xna.Framework.Input;

namespace Venus;

public static class GameInput
{
    public static class Keyboard
    {
        /// <summary>
        ///     Gets the current input state of the keyboard.
        /// </summary>
        public static KeyboardState Current { get; private set; }

        /// <summary>
        ///     Gets the previous input state of the keyboard.
        /// </summary>
        public static KeyboardState Previous { get; private set; }

        [GameHooks.Update]
        [UsedImplicitly]
        private static void Update()
        {
            Previous = Current;
            Current = Microsoft.Xna.Framework.Input.Keyboard.GetState();
        }

        /// <summary>
        ///     Checks whether the specified key is released.
        /// </summary>
        /// <param name="key">
        ///     The key to check.
        /// </param>
        /// <returns>
        ///     <see langword="true" /> if the specified key is released; otherwise, <see langword="false" />.
        /// </returns>
        public static bool Released(Keys key) => Current.IsKeyUp(key);

        /// <summary>
        ///     Checks whether the specified key is pressed.
        /// </summary>
        /// <param name="key">
        ///     The key to check.
        /// </param>
        /// <returns>
        ///     <see langword="true" /> if the specified key is pressed; otherwise, <see langword="false" />.
        /// </returns>
        public static bool Pressed(Keys key) => Current.IsKeyDown(key);

        /// <summary>
        ///     Checks whether the specified key was just released in the current frame.
        /// </summary>
        /// <param name="key">
        ///     The key to check.
        /// </param>
        /// <returns>
        ///     <see langword="true" /> if the specified key was just released in the current frame; otherwise,
        ///     <see langword="false" />.
        /// </returns>
        public static bool JustReleased(Keys key) => Current.IsKeyUp(key) && Previous.IsKeyDown(key);

        /// <summary>
        ///     Checks whether the specified key was just pressed in the current frame.
        /// </summary>
        /// <param name="key">
        ///     The key to check.
        /// </param>
        /// <returns>
        ///     <see langword="true" /> if the specified key was just pressed in the current frame; otherwise,
        ///     <see langword="false" />.
        /// </returns>
        public static bool JustPressed(Keys key) => Current.IsKeyDown(key) && !Previous.IsKeyDown(key);
    }

    public static class Mouse
    {
        /// <summary>
        ///     Gets the current position of the mouse.
        /// </summary>
        public static Vector2 Position => new(Current.X, Current.Y);
        
        /// <summary>
        ///     Gets the current input state of the mouse.
        /// </summary>
        public static MouseState Current { get; private set; }
        
        /// <summary>
        ///     Gets the previous input state of the mouse.
        /// </summary>
        public static MouseState Previous { get; private set; }
        
        [GameHooks.Update]
        [UsedImplicitly]
        private static void Update()
        {
            Previous = Current;
            Current = Microsoft.Xna.Framework.Input.Mouse.GetState();
        }
    }
}