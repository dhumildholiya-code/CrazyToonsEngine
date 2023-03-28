using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace CrazyToonsEngine.src.InputSystem
{
    public static class Input
    {
        private static Dictionary<Keys, GameKey> _keys;

        private static KeyboardState _prevKeyboardState;

        static Input()
        {
            _keys = new Dictionary<Keys, GameKey>()
            {
                {Keys.Escape, new GameKey(Keys.Escape) },
                {Keys.Space, new GameKey(Keys.Space) },
            };
            _prevKeyboardState = Keyboard.GetState();
        }

        public static void Update()
        {
            HandleKeyboardInput();
        }

        #region Keyboard Input Methods
        public static bool GetKeyDown(Keys key)
        {
            if (_keys.ContainsKey(key))
            {
                return _keys[key].down;
            }
            return false;
        }
        public static bool GetKeyPressed(Keys key)
        {
            if (_keys.ContainsKey(key))
            {
                return _keys[key].pressed;
            }
            return false;
        }
        public static bool GetKeyReleased(Keys key)
        {
            if (_keys.ContainsKey(key))
            {
                return _keys[key].released;
            }
            return false;
        }
        private static void HandleKeyboardInput()
        {
            KeyboardState keyboardState = Keyboard.GetState();
            foreach (Keys key in _keys.Keys)
            {
                GameKey gameKey = _keys[key];
                if (keyboardState.IsKeyDown(key))
                {
                    gameKey.pressed = true;
                    if (_prevKeyboardState.IsKeyUp(key))
                    {
                        gameKey.down = true;
                    }
                    else
                    {
                        gameKey.down = false;
                    }
                }
                else
                {
                    gameKey.pressed = false;
                    if (_prevKeyboardState.IsKeyDown(key))
                    {
                        gameKey.released = true;
                    }
                    else
                    {
                        gameKey.released = false;
                    }

                }
                _keys[key] = gameKey;
            }
            _prevKeyboardState = keyboardState;
        }
        #endregion

    }
}
