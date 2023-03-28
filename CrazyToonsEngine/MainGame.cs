using CrazyToonsEngine.src;
using CrazyToonsEngine.src.InputSystem;
using CrazyToonsEngine.src.StateMachine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace CrazyToonsEngine
{
    public class MainGame : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private RenderTarget2D _doubleBuffer;

        private BaseGameState _currentState;

        public MainGame(int renderWidth, int renderHeight, int screenWidth, int screenHeight, BaseGameState initState)
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            Window.AllowUserResizing = true;
            IsMouseVisible = true;

            Screen.Width = renderWidth;
            Screen.Height = renderHeight;
            Screen.ViewportWidth = screenWidth;
            Screen.ViewportHeight = screenHeight;

            _currentState = initState;
            _currentState.RequestStateChange += ChangeState;
        }

        protected override void Initialize()
        {
            Global.GraphicsDevice = GraphicsDevice;
            _doubleBuffer = new RenderTarget2D(GraphicsDevice, Screen.Width, Screen.Height);
            _graphics.PreferredBackBufferWidth = Screen.ViewportWidth;
            _graphics.PreferredBackBufferHeight = Screen.ViewportHeight;
            _graphics.IsFullScreen = false;
            _graphics.ApplyChanges();

            Window.ClientSizeChanged += HandleWindowSizeChange;
            HandleWindowSizeChange(null, null);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _currentState.Enter(Content);
        }

        protected override void Update(GameTime gameTime)
        {
            Input.Update();
            _currentState.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.SetRenderTarget(_doubleBuffer);
            GraphicsDevice.Clear(Color.Black);
            _spriteBatch.Begin();
            _currentState.Draw(_spriteBatch, gameTime);
            _spriteBatch.End();

            GraphicsDevice.SetRenderTarget(null);
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();
            _spriteBatch.Draw(_doubleBuffer, Screen.RenderRect, Color.White);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
        private void ChangeState(object sender, BaseGameState newState)
        {
            _currentState.Exit(Content);
            _currentState = newState;
            _currentState.Enter(Content);
            _currentState.RequestStateChange += ChangeState;
        }
        private void HandleWindowSizeChange(object sender, EventArgs e)
        {
            var width = Window.ClientBounds.Width;
            var height = Window.ClientBounds.Height;
            Screen.ViewportHeight = height;
            Screen.ViewportWidth = width;
            if (height < width / (float)_doubleBuffer.Width * _doubleBuffer.Height)
            {
                width = (int)(height / (float)_doubleBuffer.Height * _doubleBuffer.Width);
            }
            else
            {
                height = (int)(width / (float)_doubleBuffer.Width * _doubleBuffer.Height);
            }
            var x = (Window.ClientBounds.Width - width) / 2;
            var y = (Window.ClientBounds.Height - height) / 2;
            Screen.RenderRect = new Rectangle(x, y, width, height);
        }
    }
}