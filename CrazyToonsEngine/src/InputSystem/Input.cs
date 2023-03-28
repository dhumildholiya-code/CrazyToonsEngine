using CrazyToonsEngine.src.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace CrazyToonsEngine.src.InputSystem
{
    public static class Input
    {
        private static Dictionary<Keys, GameKey> _keys;
        private static MouseKey[] _mouseButtons;

        private static KeyboardState _prevKeyboardState;
        private static MouseState _prevMouseState;

        static Input()
        {
            _keys = new Dictionary<Keys, GameKey>()
            {
                {Keys.Escape, new GameKey(Keys.Escape) },
                {Keys.Space, new GameKey(Keys.Space) },
            };
            _mouseButtons = new MouseKey[3] {
                new MouseKey(0), new MouseKey(1), new MouseKey(2),
            };
            _prevKeyboardState = Keyboard.GetState();
            _prevMouseState = Mouse.GetState();
        }

        public static void Update()
        {
            HandleKeyboardInput();
            HandleMouseInput();
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

        #region Mouse Input Methohds
        public static Point GetMousePosition()
        {
            MouseState mouseState = Mouse.GetState();
            Vector2 p = Mathf.RemapVector(Screen.RenderRect, mouseState.Position.ToVector2());
            return p.ToPoint();
        }
        public static bool GetMouseButton(int index)
        {
            return _mouseButtons[index].pressed;
        }
        public static bool GetMouseButtonDown(int index)
        {
            return _mouseButtons[index].down;
        }
        public static bool GetMouseButtonUp(int index)
        {
            return _mouseButtons[index].released;
        }
        private static void HandleMouseInput()
        {
            MouseState mouseState = Mouse.GetState();
            UpdateMouseKeys(mouseState.LeftButton, _prevMouseState.LeftButton, ref _mouseButtons[0]);
            UpdateMouseKeys(mouseState.RightButton, _prevMouseState.RightButton, ref _mouseButtons[1]);
            UpdateMouseKeys(mouseState.MiddleButton, _prevMouseState.MiddleButton, ref _mouseButtons[2]);
            _prevMouseState = mouseState;
        }
        private static void UpdateMouseKeys(ButtonState state, ButtonState prevState, ref MouseKey mouseKey)
        {
            if (state == ButtonState.Pressed)
            {
                mouseKey.pressed = true;
                if (prevState == ButtonState.Released)
                {
                    mouseKey.down = true;
                }
                else
                {
                    mouseKey.down = false;
                }
            }
            else
            {
                mouseKey.pressed = false;
                if (prevState == ButtonState.Pressed)
                {
                    mouseKey.released = true;
                }
                else
                {
                    mouseKey.released = false;
                }
            }
        }
        #endregion
    }
}
