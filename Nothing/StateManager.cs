using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Nothing
{
    public class StateManager
    {
        // keyboard
        public static KeyboardState OldKeyboardState;
        public static KeyboardState NewKeyboardState;

        // mouse
        public static MouseState OldMouseState;
        public static MouseState NewMouseState;

        public static void Update()
        {
            OldKeyboardState = NewKeyboardState;
            OldMouseState = NewMouseState;

            NewKeyboardState = Keyboard.GetState();
            NewMouseState = Mouse.GetState();
        }
    }
}